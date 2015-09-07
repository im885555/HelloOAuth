using Microsoft.AspNet.SignalR;
using System;
using System.Web;

namespace HelloSignalR
{
    public class codingChatHub : Hub
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
        }
        public void Hello(string name)
        {
            // 這邊會傳入 name 參數
            // 呼叫所有連線狀態中頁面上的 javascript function => hello
            // 透過 server 端呼叫 client 的 javascript function
            string message = " 歡迎使用者 " + name + " 加入聊天室 ";
            Clients.All.hello(message);
        }

        public void SendMessage(string name, string message)
        {
            // 這邊會傳入 name 和 message 參數
            // 並且會呼叫所有連線狀態中頁面上的 javascript function => sendAllMessage
            // 透過 server 端呼叫 client 的 javascript function
            message = name + ":" + message;
            Clients.All.sendAllMessge(message);
        }

        #endregion
    }
}
