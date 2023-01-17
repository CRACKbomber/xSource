namespace Crack.xSource.IO
{
    using Crack.xSource.Math;
    using System.IO;
    using System.Numerics;
    using System.Text;

    public class EndianWriter : BinaryWriter
    {
        private readonly bool shouldSwapBytes;

        public uint Offset => (uint)BaseStream.Position;

        public EndianWriter(Stream output, bool swapBytes) : base(output)
        {
            shouldSwapBytes = swapBytes;
        }

        public override void Write(short value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(int value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(long value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(ushort value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(uint value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(ulong value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(float value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(double value)
        {
            if (shouldSwapBytes)
                base.Write(value.Swap());
            else
                base.Write(value);
        }

        public override void Write(string value)
        {
            Write(Encoding.ASCII.GetBytes(value));
        }

        public void Write(Vector3 value)
        {
            Vector3 tmpVector;
            if (shouldSwapBytes)
                tmpVector = value.Swap();
            else
                tmpVector = value;

            Write(tmpVector.X);
            Write(tmpVector.Y);
            Write(tmpVector.Z);
        }

        public void Write(Quaternion value)
        {
            Quaternion tmpQuaternion;
            if (shouldSwapBytes)
                tmpQuaternion = value.Swap();
            else
                tmpQuaternion = value;

            Write(tmpQuaternion.X);
            Write(tmpQuaternion.Y);
            Write(tmpQuaternion.Z);
            Write(tmpQuaternion.W);
        }
        public void Write(Matrix3x4 value)
        {
            Matrix3x4 tmpMatrix;
            if (shouldSwapBytes)
                tmpMatrix = value.Swap();
            else
                tmpMatrix = value;

            Write(tmpMatrix.M11);
            Write(tmpMatrix.M12);
            Write(tmpMatrix.M13);
            Write(tmpMatrix.M14);
            Write(tmpMatrix.M21);
            Write(tmpMatrix.M22);
            Write(tmpMatrix.M23);
            Write(tmpMatrix.M24);
            Write(tmpMatrix.M23);
            Write(tmpMatrix.M24);
            Write(tmpMatrix.M31);
            Write(tmpMatrix.M32);
            Write(tmpMatrix.M33);
            Write(tmpMatrix.M34);
        }
        public void Write(Matrix4x4 value)
        {
            Matrix4x4 tmpMatrix;
            if (shouldSwapBytes)
                tmpMatrix = value.Swap();
            else
                tmpMatrix = value;

            Write(tmpMatrix.M11);
            Write(tmpMatrix.M12);
            Write(tmpMatrix.M13);
            Write(tmpMatrix.M14);
            Write(tmpMatrix.M21);
            Write(tmpMatrix.M22);
            Write(tmpMatrix.M23);
            Write(tmpMatrix.M24);
            Write(tmpMatrix.M23);
            Write(tmpMatrix.M24);
            Write(tmpMatrix.M31);
            Write(tmpMatrix.M32);
            Write(tmpMatrix.M33);
            Write(tmpMatrix.M34);
            Write(tmpMatrix.M41);
            Write(tmpMatrix.M42);
            Write(tmpMatrix.M43);
            Write(tmpMatrix.M44);
        }

        public uint Align(uint alignment = 0x800)
        {
            uint curOffs = Offset;
            uint newOffs = curOffs.AlignValue(alignment);
            uint padSize = newOffs - curOffs;

            Pad((int)padSize);

            return Offset;
        }

        public uint Pad(int length)
        {
            Write(new byte[length]);
            return Offset;
        }
    }
}
