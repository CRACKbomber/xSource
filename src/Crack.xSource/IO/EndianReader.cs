using Crack.xSource.Math;
using System.Numerics;
namespace Crack.xSource.IO
{
    public class EndianReader : BinaryReader
    {
        private readonly bool shouldSwapBytes;

        public EndianReader(Stream input, bool swapBytes) : base(input) => shouldSwapBytes = swapBytes;

        public override short ReadInt16() => shouldSwapBytes ? base.ReadInt16().Swap() : base.ReadInt16();
        public override int ReadInt32() => shouldSwapBytes ? base.ReadInt32().Swap() : base.ReadInt32();
        public override long ReadInt64() => shouldSwapBytes ? base.ReadInt64().Swap() : base.ReadInt64();
        public override ushort ReadUInt16() => shouldSwapBytes ? base.ReadUInt16().Swap() : base.ReadUInt16();
        public override uint ReadUInt32() => shouldSwapBytes ? base.ReadUInt32().Swap() : base.ReadUInt32();
        public override ulong ReadUInt64() => shouldSwapBytes ? base.ReadUInt64().Swap() : base.ReadUInt64();
        public override float ReadSingle() => shouldSwapBytes ? base.ReadSingle().Swap() : base.ReadSingle();
        public override double ReadDouble() => shouldSwapBytes ? base.ReadDouble().Swap() : base.ReadDouble();

        public Vector3 ReadVector3()
        {
            var tmpVector = new Vector3()
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle()
            };

            return shouldSwapBytes ? tmpVector.Swap() : tmpVector;
        }

        public Quaternion ReadQuaternion()
        {
            var tmpQuaternion = new Quaternion()
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle(),
                W = ReadSingle()
            };

            return shouldSwapBytes ? tmpQuaternion.Swap() : tmpQuaternion;
        }

        public Matrix3x4 ReadMatrix3x4()
        {
            var tmpMatrix = new Matrix3x4()
            {
                M11 = ReadSingle(),
                M12 = ReadSingle(),
                M13 = ReadSingle(),
                M14 = ReadSingle(),
                M21 = ReadSingle(),
                M22 = ReadSingle(),
                M23 = ReadSingle(),
                M24 = ReadSingle(),
                M31 = ReadSingle(),
                M32 = ReadSingle(),
                M33 = ReadSingle(),
                M34 = ReadSingle()
            };
            return shouldSwapBytes ? tmpMatrix.Swap() : tmpMatrix;
        }

        public Matrix4x4 ReadMatrix4x4()
        {
            var tmpMatrix = new Matrix4x4()
            {
                M11 = ReadSingle(),
                M12 = ReadSingle(),
                M13 = ReadSingle(),
                M14 = ReadSingle(),
                M21 = ReadSingle(),
                M22 = ReadSingle(),
                M23 = ReadSingle(),
                M24 = ReadSingle(),
                M31 = ReadSingle(),
                M32 = ReadSingle(),
                M33 = ReadSingle(),
                M34 = ReadSingle(),
                M41 = ReadSingle(),
                M42 = ReadSingle(),
                M43 = ReadSingle(),
                M44 = ReadSingle()
            };
            return shouldSwapBytes ? tmpMatrix.Swap() : tmpMatrix;
        }
    }
}
