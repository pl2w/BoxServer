using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxServer.Protocols
{
    [ProtoContract(Name = "edit_data")]
    [Serializable]
    public class edit_data
    {
        [ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int id;

        [DefaultValue("")]
        [ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
        public string name;

        [ProtoMember(3, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public byte[] url;

        [DefaultValue("")]
        [ProtoMember(4, IsRequired = false, Name = "date", DataFormat = DataFormat.Default)]
        public string date;

        [ProtoMember(5, IsRequired = false, Name = "upload", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int upload;
    }
}
