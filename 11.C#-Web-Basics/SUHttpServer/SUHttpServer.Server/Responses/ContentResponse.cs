﻿using SUHttpServer.Common;
using SUHttpServer.HTTP;

namespace SUHttpServer.Server.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content , string contentType)
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            this.Headers.Add(Header.ContentType, contentType);

            this.Body = content;
        }
    }
}