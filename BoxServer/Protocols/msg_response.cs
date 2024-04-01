using ProtoBuf;
using System;

namespace BoxServer.Protocols
{
    [Serializable]
    [ProtoContract(Name = "msg_response")]
    public class msg_response
    {
        [ProtoMember(1, IsRequired = false, Name = "res", DataFormat = DataFormat.TwosComplement)]
        public int res;

        [ProtoMember(2, IsRequired = false, Name = "error", DataFormat = DataFormat.Default)]
        public byte[] error;

        [ProtoMember(3, IsRequired = false, Name = "msg", DataFormat = DataFormat.Default)]
        public byte[] msg;
    }
}
