using ProtoBuf;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BoxServer.Utils
{
    public static class Serialization
    {
        public static byte[] Serialize<T>(T t)
        {
            var stream = new MemoryStream();
            Serializer.Serialize(stream, t);
            var bytes = stream.ToArray();
            stream.Flush();
            stream.Close();
            stream.Dispose();
            return bytes;
        }

        public static T Deserialize<T>(byte[] fullData)
        {
            MemoryStream memoryStream = new MemoryStream(fullData);
            memoryStream.Seek(0, SeekOrigin.Begin);
            T t = Serializer.Deserialize<T>(memoryStream);
            memoryStream.Flush();
            memoryStream.Close();
            memoryStream.Dispose();
            return t;
        }
    }
}
