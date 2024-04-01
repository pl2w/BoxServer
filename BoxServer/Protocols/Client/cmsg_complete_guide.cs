using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxServer.Protocols.Client
{
    [ProtoContract(Name = "cmsg_complete_guide")]
    [Serializable]
    public class cmsg_complete_guide 
    {
        [ProtoMember(1, IsRequired = true, Name = "common", DataFormat = DataFormat.Default)]
        public msg_common common;

        [ProtoMember(2, IsRequired = true, Name = "url", DataFormat = DataFormat.Default)]
        public byte[] url;

        [ProtoMember(3, IsRequired = true, Name = "data", DataFormat = DataFormat.Default)]
        public byte[] data;
    }
}
