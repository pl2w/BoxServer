using BoxServer.Protocols;
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
            try
            {
                cmsg_view_comment viewComment = Serialization.Deserialize<cmsg_view_comment>(data);
                Console.WriteLine(viewComment.common.userid);
            } catch (Exception e)
            {
                Console.WriteLine($"Exception while deserializing data: {e.Message}");
                msg_response errResp = new msg_response();
                errResp.res = -1;
                PacketUtils.SendPacketToClient(errResp, resp.OutputStream);
            }
        }
    }
}
