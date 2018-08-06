using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            //new[]
            //{
            //    //new ChatItem("이승엽", "안녕", "SY", "334455"),
            //    //new ChatItem("이승엽2", "안녕2", "SZ", "1212FF"),
            //    //new ChatItem("이승엽3", "안녕3", "SX", "FF00FF"),
            //    //new ChatItem("이승엽4", "안녕4", "SE", "3322EE"),
            //    //new ChatItem("이승엽5", "안녕5", "ST", "EEFFEE")
            //}
        );

        public ChatListController()
        {
            string server = "localhost";
            string database = "gg";
            string user = "user2";
            string pass = "user2";

            string myConnectionString = string.Format(
                "Server={0};Database={1};Uid={2};Pwd={3}",
                server,
                database,
                user,
                pass);

            using (var connection = new MySqlConnection(myConnectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * From chat";
                    var dataAdapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    //Console.WriteLine(dataSet.GetXml());
                    items.Clear();
                    for (int i=0; i< dataSet.Tables[0].Rows.Count; i++)
                    {
                        var row = dataSet.Tables[0].Rows[i];
                        var name = row["name"].ToString();
                        var message = row["message"].ToString();
                        var initials = row["initials"].ToString();
                        var profile = row["profilePictureRGB"].ToString();
                        items.Add(new ChatItem( name, message, initials, profile
                                                ));

                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                }
                //Console.ReadLine();
            }
        }
    


        //모든 챗 목록 실행
        public HttpResponseMessage Get()
        {
            var results = items.
                //Where(x => x.Name.StartsWith("이"));
                AsEnumerable();

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}
