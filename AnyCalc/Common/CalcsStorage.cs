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
        private static ConcurrentDictionary<Type, ICalcVM> _registred_calcs { get; set; }

        // Properties

        // ctors
        public CalcsStorage()
        {
            _registred_calcs = new ConcurrentDictionary<Type, ICalcVM>();
        }

        // Methods
        public void InitAllCalcs()
        {
            var allCalcs = Assembly.GetExecutingAssembly().ExportedTypes.Where(x => x.GetInterfaces().Contains(typeof(ICalcVM)));
            foreach (var calc in allCalcs)
            {
                ICalcVM calcToRegister = Activator.CreateInstance(calc) as ICalcVM;
                _registred_calcs.TryAdd(calcToRegister.CalcMathType, calcToRegister);
            }
        }

        public IEnumerable<ICalcVM> GetAllRegistredCalcs()
        {
            return _registred_calcs.Values;
        }

        public ICalcVM GetCalcVMViewByType(Type calcType)
        {
            if (_registred_calcs.ContainsKey(calcType))
            {
                return _registred_calcs[calcType];
            }

            return null;
        }

        public Type GetCalcViewTypeByType(Type calcType)
        {
            if (_registred_calcs.ContainsKey(calcType))
            {
                return _registred_calcs[calcType].CalcViewType;
            }
            
            return null;
        }
    }
}
