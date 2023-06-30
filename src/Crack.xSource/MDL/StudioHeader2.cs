using Crack.xSource.IO;
using System.Runtime.InteropServices;

namespace Crack.xSource.MDL
{
    [StructLayout(LayoutKind.Sequential, Size = 256)]
    public class StudioHeader2 : IEndianObject
    {
        public int SrcBoneTransformCount { get; set; }
        public int SrcBoneTransformOffset { get; set; }
        public int IllumPositionAttachmentOffset { get; set; }
        public float MaxEyeDeflection { get; set; }
        public int LinearBoneOffset { get; set; }
        public int[] Reserved { get; set; } = new int[59];

        public void FromReader(EndianReader reader)
        {
            SrcBoneTransformCount = reader.ReadInt32();
            SrcBoneTransformOffset = reader.ReadInt32();
            IllumPositionAttachmentOffset = reader.ReadInt32();
            MaxEyeDeflection = reader.ReadSingle();
            LinearBoneOffset = reader.ReadInt32();
            for (int i = 0; i < Reserved.Length; i++)
                Reserved[i] = reader.ReadInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(SrcBoneTransformCount);
            writer.Write(SrcBoneTransformOffset);
            writer.Write(IllumPositionAttachmentOffset);
            writer.Write(MaxEyeDeflection);
            writer.Write(LinearBoneOffset);
            for (int i = 0; i < Reserved.Length; i++)
                writer.Write(Reserved[i]);
        }
    }
}
