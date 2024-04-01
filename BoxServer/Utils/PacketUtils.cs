using BoxServer.Protocols;
using BoxServer.Protocols.Server;
using ProtoBuf;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace BoxServer.Utils
{
    public static class PacketUtils
    {
        public static T ParsePacket<T>(byte[] bytes)
        {
            MemoryStream source = new MemoryStream(bytes);
            object obj = new object();
            obj = Serializer.DeserializeWithLengthPrefix<T>(source, PrefixStyle.None);
            return (T)((object)obj);
        }

        public static void SendResponseToClient<T>(T response, Stream outputStream)
        {
            Console.WriteLine($"Sending packet {response.GetType().Name}");
            MemoryStream memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, response);
            byte[] bytes = memoryStream.ToArray();
            outputStream.Write(bytes, 0, bytes.Length);
            outputStream.Close();
        }

        public static void SendPacketToClient<T>(T data, Stream outputStream)
        {
            msg_response response = new msg_response();
            byte[] msgBytes = Serialization.Serialize(data);

            response.res = 0;
            response.msg = msgBytes;
            response.error = null;

            SendResponseToClient(response, outputStream);
        }
    }
}
