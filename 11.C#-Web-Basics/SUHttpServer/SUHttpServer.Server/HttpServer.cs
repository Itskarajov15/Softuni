using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, port);
        }

        public async Task Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();
                var networkStream = connection.GetStream();
                var request = this.ReadRequest(networkStream);
                Console.WriteLine(request);
                await WriteResponse(networkStream, "Hello from the server!");
                connection.Close();
            }
        }

        private static async Task WriteResponse(NetworkStream networkStream, string content)
        {
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            byte[] buffer = new byte[1024];
            var requestBuilder = new StringBuilder();
            int totalBytes = 0;

            do
            {
                int bytesRead = await networkStream.ReadAsync (buffer, totalBytes, 1024);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request it too large");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
