namespace AnyCalc.Common.CalcMath
{
    public interface ICalc
    {
        string Add(string left, string right);
        string Substruct(string left, string right);
        string Multiple(string left, string right);
        string Devide(string left, string right);
        double ConvertToNum(string input);
        string ConvertToNotation(double input);

        string GetNullSymbol();
    }
}
