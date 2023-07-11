using CurrencyConverterServer.Helper;
using System.Text;

namespace CurrencyConverterServer.Converter
{
    public class NumberConverter : INumberConverter
    {
        public Task<ConvertReply> Convert(ConvertRequest convertRequest)
        {

            string str = convertRequest.NumberString.Trim();
            string[] splittedByType = str.Split(',');

            StringBuilder stringBuilder = new();
            string[] splittedByGrade = splittedByType[0].Split(' ');
            var integerNum = System.Convert.ToInt32(splittedByType[0].Replace(" ", ""));
            if (integerNum > 999999999)
                throw new Exception("invalid integer part");

            if (splittedByGrade[0].Length < 1 || splittedByGrade[0].Length > 3)
                throw new Exception("invalid integer part");

            var gradeCounter = 0;
            var gradeCount = splittedByGrade.Count();
            var digits = new string[] { };
            switch (gradeCount)
            {
                case 3:
                    digits = StaticDetails.GradesForThree;
                    break;
                case 2:
                    digits = StaticDetails.GradesForTwo;
                    break;
                default:
                    digits = StaticDetails.GradesForThree;
                    break;
            }


            for (int i = 0; i < gradeCount; i++)
            {

                var strGrade = splittedByGrade[i];

                if (System.Convert.ToInt32(strGrade) <= 0 && gradeCounter < gradeCount -1 )
                {
                    gradeCounter++;
                    continue;
                }
                    
                HelperMethods.PrintGrade(ref stringBuilder, strGrade);
                if (gradeCounter < gradeCount - 1)
                {
                    stringBuilder.Append($" {digits[gradeCounter]} ");
                    gradeCounter++;
                }
                

            }
            
            if (integerNum == 1)
                stringBuilder.Append($" {StaticDetails.SingleIntPartCurrency}");
            else
                stringBuilder.Append($" {StaticDetails.PluralIntPartCurrency}");

            if (splittedByType.Count() > 1)
            {
                if(splittedByType[1].Length >2 )
                    throw new Exception("invalid decimal part ");
                if (splittedByType[1].Length == 1)
                    splittedByType[1] += "0";
                var decimalNum = System.Convert.ToInt32(splittedByType[1]);


                if (decimalNum > 99)
                    throw new Exception("invalid decimal part ");
                stringBuilder.Append($" {StaticDetails.AndWord}");
                if(decimalNum > 0)
                    HelperMethods.Print2DigitsGrade(ref stringBuilder, splittedByType[1]);
                else
                    stringBuilder.Append($"{StaticDetails.SingleDigits[decimalNum]}");

                if (decimalNum == 1)
                    stringBuilder.Append($" {StaticDetails.SingleDecimalPartCurrency}");
                else
                    stringBuilder.Append($" {StaticDetails.PluralDecimalPartCurrency}");
            }
            return Task.FromResult(
                    new ConvertReply() { Message = stringBuilder.ToString() });
        }
    }
}
