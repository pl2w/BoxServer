using BoxServer.Protocols.Client;
using BoxServer.Utils;
using System;
using System.Net;
using System.Text;

namespace BoxServer.Behaviours.OpHandlers
{
    public class ViewCommentHandler : IOperation
    {
        public void OperationReceived(byte[] data, HttpListenerContext ctx, HttpListenerRequest req, HttpListenerResponse resp)
        {
            cmsg_view_comment viewComment = Serialization.Deserialize<cmsg_view_comment>(data);
            Console.WriteLine(viewComment.common.userid);
        }
    }
}
