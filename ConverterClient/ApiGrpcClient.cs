using CurrencyConverterWPFClient;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ConverterClient
{
    public class ApiClientGrpc
    {

        public static async Task<ConvertReply> Send(string numberString)
        {

            var channel = GrpcChannel.ForAddress("https://localhost:7139/");

            var client = new Greeter.GreeterClient(channel);
            try
            {
                var data = await client.ConvertNumberAsync(new ConvertRequest() { NumberString = numberString });
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
