using AnyCalc.Common.CalcMath;
using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Common
{
    public class CalcsStorage
    {
        // Consts & Configs
        private static readonly object padlock = new object();

        // Static instance
        private static CalcsStorage calcStorage;
        public static CalcsStorage Instance
        {
            get
            {
                if (calcStorage == null)
                {
                    lock (padlock)
                    {
                        calcStorage = new CalcsStorage();
                    }
                }
                return calcStorage;
            }
        }

        // Fields
        private static ConcurrentDictionary<Type, ICalcModel> _registred_calcs { get; set; }

        // Properties

        // ctors
        public CalcsStorage()
        {
            _registred_calcs = new ConcurrentDictionary<Type, ICalcModel>();
        }

        // Methods
        public void InitAllCalcs()
        {
            var allCalcs = Assembly.GetExecutingAssembly().ExportedTypes.Where(x => x.GetInterfaces().Contains(typeof(ICalcModel)));
            foreach (var calc in allCalcs)
            {
                ICalcModel calcToRegister = Activator.CreateInstance(calc) as ICalcModel;
                _registred_calcs.TryAdd(calcToRegister.CalcMathType, calcToRegister);
            }
        }

        public IEnumerable<ICalcModel> GetAllRegistredCalcs()
        {
            return _registred_calcs.Values;
        }

        public ICalcModel GetCalcModelViewByType(Type calcType)
        {
            if (_registred_calcs.ContainsKey(calcType))
            {
                return _registred_calcs[calcType];
            }

            return null;
        }
    }
}
