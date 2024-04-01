using System.IO;
using System.Net;

namespace BoxServer.Behaviours.OpHandlers
{
    public interface IOperation
    {
        void OperationReceived(byte[] data, HttpListenerContext ctx, HttpListenerRequest req, HttpListenerResponse resp);
    }
}
