using Crack.xSource.IO;
using System.Runtime.InteropServices;

namespace Crack.xSource.Zip.XZP2.Headers
{
    [StructLayout(LayoutKind.Sequential, Size = 0x1E)]
    public class ZipLocalFileHeader
    {
        public const int NativeSize = 0x1E;
        public uint Signature { get; set; } = 0x4034B50;
        public ushort VersionNeededToExtract { get; set; } = 0x0A;
        public ushort Flags { get; set; } = 0;
        public ushort CompressionMethod { get; set; } = 0;
        public ushort LastModifiedTime { get; set; } = 0;
        public ushort LastModifiedDate { get; set; } = 0;
        public uint Checksum { get; set; }
        public uint CompressedSize { get; set; }
        public uint UncompressedSize { get; set; }
        public ushort FileNameLength { get; set; }
        public ushort ExtraFieldLength { get; set; }
        public string FileName { get; set; }

        public void Write(EndianWriter writer)
        {
            writer.Write(Signature);
            writer.Write(VersionNeededToExtract);
            writer.Write(Flags);
            writer.Write(CompressionMethod);
            writer.Write(LastModifiedTime);
            writer.Write(LastModifiedDate);
            writer.Write(Checksum);
            writer.Write(CompressedSize);
            writer.Write(UncompressedSize);
            writer.Write(FileNameLength);
            writer.Write(ExtraFieldLength);
            writer.Write(FileName);
        }
    }
}
