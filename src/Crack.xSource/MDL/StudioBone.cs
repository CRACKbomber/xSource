using Crack.xSource.IO;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Crack.xSource.MDL
{
    [StructLayout(LayoutKind.Sequential, Size = 216)]
    public class StudioBone : IEndianObject
    {
        public int NameOffset { get; set; }
        public string Name { get; set; } = "";
        public int Parent { get; set; }
        public int[] BoneController { get; set; } = new int[6];
        public Vector3 Pos { get; set; }
        public Quaternion Quat { get; set; }
        public Vector3 Rot { get; set; }
        public Vector3 PosScale { get; set; }
        public Vector3 RotScale { get; set; }
        public float[] PoseToBone { get; set; } = new float[12];
        public Quaternion QAlignment { get; set; }
        public int Flags { get; set; }
        public int ProcType { get; set; }
        public int ProcIndex { get; set; }
        public int PhysicsBone { get; set; }
        public int SurfacePropOffset { get; set; }
        public string SurfaceProp { get; set; } = "";
        public int Contents { get; set; }
        public int[] Unused { get; set; } = new int[8];

        public void FromReader(EndianReader reader)
        {
            NameOffset = reader.ReadInt32();
            Parent = reader.ReadInt32();

            for (int i = 0; i < BoneController.Length; i++)
                BoneController[i] = reader.ReadInt32();

            Pos = reader.ReadVector3();
            Quat = reader.ReadQuaternion();
            Rot = reader.ReadVector3();
            PosScale = reader.ReadVector3();
            RotScale = reader.ReadVector3();
            for (int i = 0; i < PoseToBone.Length; i++)
                PoseToBone[i] = reader.ReadSingle();

            QAlignment = reader.ReadQuaternion();
            Flags = reader.ReadInt32();
            ProcType = reader.ReadInt32();
            ProcIndex = reader.ReadInt32();
            PhysicsBone = reader.ReadInt32();
            SurfacePropOffset = reader.ReadInt32();
            Contents = reader.ReadInt32();

            for (int i = 0; i < Unused.Length; i++)
                Unused[i] = reader.ReadInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(NameOffset);
            writer.Write(Parent);
            for (int i = 0; i < 6; i++)
                writer.Write(BoneController[i]);
            writer.Write(Pos);
            writer.Write(Quat);
            writer.Write(Rot);
            writer.Write(PosScale);
            writer.Write(RotScale);
            for (int i = 0; i < PoseToBone.Length; i++)
                writer.Write(PoseToBone[i]);
            writer.Write(QAlignment);
            writer.Write(Flags);
            writer.Write(ProcType);
            writer.Write(ProcIndex);
            writer.Write(SurfacePropOffset);
            writer.Write(Contents);
            for (int i = 0; i < Unused.Length; i++)
                writer.Write(Unused[i]);
        }
    }

}
