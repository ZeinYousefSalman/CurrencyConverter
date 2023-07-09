
using Grpc.Core;
using Grpc.Net.Client;
using CurrencyConverterClient;


namespace CurrencyConverter
{
    public class ApiClientGrpc
    {

        public static async Task<ConvertReply> Send(string numberString)
        {

            var channel = GrpcChannel.ForAddress(StaticDetails.ServerUrl);

            var client = new Greeter.GreeterClient(channel);
            try
            {
                var data = await client.ConvertNumberAsync(new ConvertRequest() { NumberString = numberString});
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;

            }

        }


    }
}