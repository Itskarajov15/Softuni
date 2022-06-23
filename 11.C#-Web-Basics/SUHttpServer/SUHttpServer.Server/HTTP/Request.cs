namespace SUHttpServer.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var startLine = lines
                .First()
                .Split(" ");

            var method = ParseMethod(startLine[0]);
            var url = startLine[1];
            var headers = ParseHeaders(lines.Skip(1));
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join("\r\n", bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headers = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":");

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request headers is not valid");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1];

                headers.Add(headerName, headerValue.Trim());
            }

            return headers;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
