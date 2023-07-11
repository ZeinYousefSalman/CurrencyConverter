using System.Text;

namespace CurrencyConverterServer.Helper
{
    public static class HelperMethods
    {

        public static void Print3DigitsGrade(ref StringBuilder sb, string numberString)
        {


            if (Convert.ToInt16(numberString.Substring(0, 1)) > 0)
            {
                Print1DigitGrade(ref sb, numberString.Substring(0, 1));
                sb.Append($" {StaticDetails.HundredWord}");
            }

            Print2DigitsGrade(ref sb, numberString.Substring(1, 2));



        }
        public static void Print2DigitsGrade(ref StringBuilder sb, string numberString)
        {
            var num = Convert.ToInt16(numberString);
            if (num >= 20)
            {
                sb.Append($" {StaticDetails.DoubleDigits[num / 10]}");
                if (num % 10 != 0)
                {
                    sb.Append('-');
                    sb.Append(StaticDetails.SingleDigits[num % 10]);
                }

            }
            else
            {
                if (num > 0)
                    sb.Append($" {StaticDetails.SingleDigits[num]}");
            }
        }
        public static void Print1DigitGrade(ref StringBuilder sb, string numberString)
        {
            sb.Append(StaticDetails.SingleDigits[Convert.ToInt32(numberString)]);
        }
        public static void PrintGrade(ref StringBuilder sb, string grade)
        {

            var length = grade.Length;

            switch (length)
            {
                case 3:
                    Print3DigitsGrade(ref sb, grade);
                    break;
                case 2:
                    Print2DigitsGrade(ref sb, grade);
                    break;
                case 1:
                    Print1DigitGrade(ref sb, grade);
                    break;
            }

        }
    }
}
