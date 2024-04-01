using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxServer.Protocols.Client
{
    [ProtoContract(Name = "cmsg_view_comment")]
    [Serializable]
    public class cmsg_view_comment
    {
        [ProtoMember(1, IsRequired = true, Name = "common", DataFormat = DataFormat.Default)]
        public msg_common common;

        [ProtoMember(2, IsRequired = true, Name = "id", DataFormat = DataFormat.TwosComplement)]
        public int id;
    }
}
