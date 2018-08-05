using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class ChatListController : ApiController
    {
        //모든 챗 리스트
        private static List<ChatItem> items =
            new List<ChatItem>(
            new[]
            {
                new ChatItem("이승엽", "안녕", "SY", "334455"),
                new ChatItem("이승엽2", "안녕2", "SZ", "1212FF"),
                new ChatItem("이승엽3", "안녕3", "SX", "FF00FF"),
                new ChatItem("이승엽4", "안녕4", "SE", "3322EE"),
                new ChatItem("이승엽5", "안녕5", "ST", "EEFFEE")
            }
        );

        //모든 챗 목록 실행
        public HttpResponseMessage Get()
        {
            var results = items.
                Where(x => x.Name.StartsWith("이"));

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}
