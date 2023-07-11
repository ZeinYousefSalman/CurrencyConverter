namespace CurrencyConverterServer.Helper
{
    public static class StaticDetails
    {
        public static string[] GradesForTwo { get; set; } = new string[2];
        public static string[] GradesForThree { get; set; } = new string[2];
        public static string[] SingleDigits { get; set; } = new string[20];
        public static string[] DoubleDigits { get; set; } = new string[10];
        public static string HundredWord { get; set; } = string.Empty;
        public static string AndWord { get; set; } = string.Empty;
        public static string SingleIntPartCurrency { get; set; } = string.Empty;
        public static string SingleDecimalPartCurrency { get; set; } = string.Empty;
        public static string PluralIntPartCurrency { get; set; } = string.Empty;
        public static string PluralDecimalPartCurrency { get; set; } = string.Empty;
    }
}
