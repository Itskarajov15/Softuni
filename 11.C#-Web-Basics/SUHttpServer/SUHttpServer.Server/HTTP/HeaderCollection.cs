﻿using System.Collections;

namespace SUHttpServer.Server.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
            => this.headers = new();

        public int Count => this.headers.Count;
        
        public void Add(string name, string value)
        {
            this.headers.Add(name, new Header(name, value));
        }

        public IEnumerator<Header> GetEnumerator()
            => this.headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
