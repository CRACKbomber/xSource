using Crack.xSource.IO;
using System.Numerics;

namespace Crack.xSource.MDL
{
    public class StudioAimAtBone : IEndianObject
    {
        public int Parent { get; set; }
        public int Aim { get; set; }
        public Vector3 AimVector { get; set; }
        public Vector3 UpVector { get; set; }
        public Vector3 BasePos { get; set; }

        public void FromReader(EndianReader reader)
        {
            Parent = reader.ReadInt32();
            Aim = reader.ReadInt32();
            AimVector = reader.ReadVector3();
            UpVector = reader.ReadVector3();
            BasePos = reader.ReadVector3();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(Parent);
            writer.Write(Aim);
            writer.Write(AimVector);
            writer.Write(UpVector);
            writer.Write(BasePos);
        }
    }
}
