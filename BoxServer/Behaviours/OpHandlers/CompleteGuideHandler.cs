using BoxServer.Behaviours.Accounts;
using BoxServer.Protocols;
using BoxServer.Protocols.Client;
using BoxServer.Utils;
using ProtoBuf;
using System;
using System.Net;

namespace BoxServer.Behaviours.OpHandlers
{
    public class CompleteGuideHandler : IOperation
    {
        public void OperationReceived(byte[] data, HttpListenerContext ctx, HttpListenerRequest req, HttpListenerResponse resp)
        {
            Console.WriteLine($"Complete guide started by: '{ctx.Request.RemoteEndPoint}'");

            Console.WriteLine(Serialization.Deserialize<cmsg_complete_guide>(data).common.userid);
            //
            //AccountManagement.GetAccount(Serialization.Deserialize<cmsg_complete_guide>(data).common.userid, out AccountData account);
            //account.tutorialComplete = true;
            //AccountManagement.SaveAccountData(account);
            //
            //msg_response response = new msg_response();
            //response.res = 0;
            //response.msg = null;
            //response.error = null;
            //PacketUtils.SendResponseToClient(response, resp.OutputStream);
        }
    }
}
