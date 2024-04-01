using ProtoBuf;
using System;
using System.ComponentModel;

namespace BoxServer.Protocols.Client
{
    [ProtoContract(Name = "cmsg_login_android")]
    [Serializable]
    public class cmsg_login_android
    {
        [ProtoMember(1, IsRequired = false, Name = "userid", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string userid;

        [ProtoMember(2, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string token;

        [ProtoMember(3, IsRequired = false, Name = "channel", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string channel;

        [ProtoMember(4, IsRequired = false, Name = "nationality", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string nationality;

        [DefaultValue("")]
        [ProtoMember(5, IsRequired = false, Name = "ver", DataFormat = DataFormat.Default)]
        public string ver;
    }
}
