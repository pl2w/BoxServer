using ProtoBuf;
using System;
using System.ComponentModel;

namespace BoxServer.Protocols.Server
{
    [Serializable]
    [ProtoContract(Name = "smsg_login")]
    public class smsg_login
    {
        [DefaultValue("")]
        [ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
        public string openid { get; set; }

        [DefaultValue("")]
        [ProtoMember(2, IsRequired = false, Name = "openkey", DataFormat = DataFormat.Default)]
        public string openkey { get; set; }

        [ProtoMember(7, IsRequired = false, Name = "visitor", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int visitor;

        [DefaultValue(0)]
        [ProtoMember(9, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
        public int level;

        [ProtoMember(10, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int exp;

        [ProtoMember(18, IsRequired = false, Name = "guide", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int guide;
    }
}
