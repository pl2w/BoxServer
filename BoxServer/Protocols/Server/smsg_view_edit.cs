using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BoxServer.Protocols.Server
{
    [ProtoContract(Name = "smsg_view_edit")]
    [Serializable]
    public class smsg_view_edit
    {
        [ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
        public List<edit_data> infos;

        [ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int exp;

        [ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int level;
    }
}
