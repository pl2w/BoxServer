using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxServer.Protocols
{
    [Serializable]
    [ProtoContract(Name = "msg_common")]
    public class msg_common
    {
        [ProtoMember(1, IsRequired = true, Name = "userid", DataFormat = DataFormat.TwosComplement)]
        public int userid { get; set; }

        [ProtoMember(2, IsRequired = true, Name = "pck_id", DataFormat = DataFormat.TwosComplement)]
        public int pck_id;

        [ProtoMember(3, IsRequired = true, Name = "sig", DataFormat = DataFormat.Default)]
        public string sig;
    }
}
