namespace Crack.xSource.IO
{
    using Crack.xSource.Math;
    using System;
    using System.Numerics;
    using System.Text;

    public static class EndianExtensions
    {
        public static short Swap(this short value)
        {
            return BitConverter.ToInt16(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static int Swap(this int value)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static long Swap(this long value)
        {
            return BitConverter.ToInt64(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static ushort Swap(this ushort value)
        {
            return BitConverter.ToUInt16(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static uint Swap(this uint value)
        {
            return BitConverter.ToUInt32(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static ulong Swap(this ulong value)
        {
            return BitConverter.ToUInt64(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static float Swap(this float value)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static double Swap(this double value)
        {
            return BitConverter.ToDouble(BitConverter.GetBytes(value).Swap(), 0);
        }

        public static byte[] Swap(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }

        public static Vector3 Swap(this Vector3 vector)
        {
            return new Vector3(vector.X.Swap(), vector.Y.Swap(), vector.Z.Swap());
        }

        public static Quaternion Swap(this Quaternion quaternion)
        {
            return new Quaternion(
                quaternion.X.Swap(),
                quaternion.Y.Swap(),
                quaternion.Z.Swap(),
                quaternion.W.Swap()
            );
        }
        public static Matrix3x4 Swap(this Matrix3x4 matrix)
        {
            return new Matrix3x4(
                matrix.M11.Swap(), matrix.M12.Swap(), matrix.M13.Swap(), matrix.M14.Swap(),
                matrix.M21.Swap(), matrix.M22.Swap(), matrix.M23.Swap(), matrix.M24.Swap(),
                matrix.M31.Swap(), matrix.M32.Swap(), matrix.M33.Swap(), matrix.M34.Swap()
            );
        }
        public static Matrix4x4 Swap(this Matrix4x4 matrix)
        {
            return new Matrix4x4(
                matrix.M11.Swap(), matrix.M12.Swap(), matrix.M13.Swap(), matrix.M14.Swap(),
                matrix.M21.Swap(), matrix.M22.Swap(), matrix.M23.Swap(), matrix.M24.Swap(),
                matrix.M31.Swap(), matrix.M32.Swap(), matrix.M33.Swap(), matrix.M34.Swap(),
                matrix.M41.Swap(), matrix.M42.Swap(), matrix.M43.Swap(), matrix.M44.Swap()
            );
        }

        public static string ReadFixedLengthString(this EndianReader reader, int length)
        {
            byte[] buffer = reader.ReadBytes(length);
            string str = Encoding.ASCII.GetString(buffer);
            int nullTerminatorIndex = str.IndexOf('\0');

            if (nullTerminatorIndex >= 0)
                str = str.Substring(0, nullTerminatorIndex);

            return str;
        }
    }
}
