using CurrencyConverterServer.Converter;
using Grpc.Core;

namespace CurrencyConverterServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly INumberConverter _numberConverter;
        public GreeterService(ILogger<GreeterService> logger, INumberConverter numberConverter)
        {
            _logger = logger;
            _numberConverter = numberConverter;
        }

        public override async Task<ConvertReply> ConvertNumber(ConvertRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"request to convert number received on {DateTime.Now}");
            return await _numberConverter.Convert(request);
        }
    }
}