
namespace CurrencyConverterServer.Converter
{
    public interface INumberConverter
    {
        Task<ConvertReply> Convert(ConvertRequest convertRequest);
    }
}
