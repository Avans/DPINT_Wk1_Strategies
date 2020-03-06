namespace DPINT_Wk1_Strategies
{
    interface INumberConverter
    {
        string ToLocalString(int fromNumber);

        int ToNumerical(string fromString);


    }
}
