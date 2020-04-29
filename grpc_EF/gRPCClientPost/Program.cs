using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace gRPCClientPost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new PostComment.Comment();
            var reply = client.Id;
            Console.WriteLine("Id of the new Comment created: " + reply);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
