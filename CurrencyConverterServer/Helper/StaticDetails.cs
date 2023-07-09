namespace CurrencyConverterServer.Helper
{
    public static class StaticDetails
    {
        public static string[] GradesForTwo { get; set; } = new string[2];
        public static string[] GradesForThree { get; set; } = new string[2];
        public static string[] SingleDigits { get; set; } = new string[20];
        public static string[] DoubleDigits { get; set; } = new string[10];
        public static string HundreadWord { get; set; } = string.Empty;
        public static string AndWord { get; set; } = string.Empty;
        public static string SingleDollar { get; set; } = string.Empty;
        public static string SingleCent { get; set; } = string.Empty;
        public static string PluralDollar { get; set; } = string.Empty;
        public static string PluralCent { get; set; } = string.Empty;
    }
}
