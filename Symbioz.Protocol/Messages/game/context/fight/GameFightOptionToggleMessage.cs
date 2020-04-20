using System;
using System.Collections.Generic;
using System.Linq;
using Symbioz.Protocol.Types;
using SSync.IO;
using SSync.Messages;

namespace Symbioz.Protocol.Messages {
    public class GameFightOptionToggleMessage : Message {
        public const ushort Id = 707;

        public override ushort MessageId {
            get { return Id; }
        }

        public sbyte option;


        public GameFightOptionToggleMessage() { }

        public GameFightOptionToggleMessage(sbyte option) {
            this.option = option;
        }


        public override void Serialize(ICustomDataOutput writer) {
            writer.WriteSByte(this.option);
        }

        public override void Deserialize(ICustomDataInput reader) {
            this.option = reader.ReadSByte();

            if (this.option < 0)
                throw new Exception("Forbidden value on option = " + this.option + ", it doesn't respect the following condition : option < 0");
        }
    }
}