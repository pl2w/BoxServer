using BoxServer.Protocols.Server;
using BoxServer.Protocols;
using BoxServer.Utils;
using System;
using System.Net;
using BoxServer.Protocols.Client;
using BoxServer.Behaviours.Accounts;

namespace BoxServer.Behaviours.OpHandlers
{
    public class AndroidLoginHandler : IOperation
    {
        public void OperationReceived(byte[] data, HttpListenerContext ctx, HttpListenerRequest req, HttpListenerResponse resp)
        {
            Console.WriteLine($"Login process started by: '{ctx.Request.RemoteEndPoint.Address}'");

            cmsg_login_android androidLoginRequest = Serialization.Deserialize<cmsg_login_android>(data);

            AccountManagement.GetAccount(androidLoginRequest.userid, out AccountData accountData);
            
            smsg_login login = new smsg_login();
            login.openid = accountData.userId.ToString();
            login.openkey = accountData.userId.ToString();
            
            login.guide = accountData.tutorialComplete ? 200 : 0;
            login.level = accountData.accountLevel;
            login.exp = accountData.accountExperience;
            
            PacketUtils.SendPacketToClient(login, resp.OutputStream);
        }
    }
}