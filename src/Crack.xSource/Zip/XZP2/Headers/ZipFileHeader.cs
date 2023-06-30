using Crack.xSource.IO;
using System.Runtime.InteropServices;

namespace Crack.xSource.Zip.XZP2.Headers
{
    [StructLayout(LayoutKind.Sequential, Size = 0x2E)]
    public class ZipFileHeader
    {
        public const int NativeSize = 0x2E;
        private const uint __Signature = 0x2014B50;
        public uint Signature { get; set; } = __Signature;
        public ushort VersionMadeBy { get; set; } = 0x14;
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
        public ushort FileCommentLength { get; set; } = 0;
        public ushort DiskNumberStart { get; set; } = 0;
        public ushort InternalFileAttribs { get; set; } = 0;
        public uint ExternalFileAttribs { get; set; } = 0;
        public uint RelativeOffsetOfLocalHeader { get; set; }
        public string FileName { get; set; }
        public string Comment { get; set; } = string.Empty;
        public ZipFileHeader(EndianReader reader)
        {
            Signature = reader.ReadUInt32();

            if (Signature != __Signature)
                throw new Exception("Invalid zip file header signature");

            VersionMadeBy = reader.ReadUInt16();
            VersionNeededToExtract = reader.ReadUInt16();
            Flags = reader.ReadUInt16();
            CompressionMethod = reader.ReadUInt16();
            LastModifiedTime = reader.ReadUInt16();
            LastModifiedDate = reader.ReadUInt16();
            Checksum = reader.ReadUInt32();
            CompressedSize = reader.ReadUInt32();
            UncompressedSize = reader.ReadUInt32();
            FileNameLength = reader.ReadUInt16();
            ExtraFieldLength = reader.ReadUInt16();
            FileCommentLength = reader.ReadUInt16();
            DiskNumberStart = reader.ReadUInt16();
            InternalFileAttribs = reader.ReadUInt16();
            ExternalFileAttribs = reader.ReadUInt32();
            RelativeOffsetOfLocalHeader = reader.ReadUInt32();
            FileName = reader.ReadFixedLengthString(FileNameLength);
            Comment = reader.ReadFixedLengthString(FileCommentLength);
        }

        public ZipFileHeader(string internalName, uint crc32, uint size, uint offset, uint alignment = 0x800)
        {
            var dataStart = offset + internalName.Length + ZipLocalFileHeader.NativeSize;
            Checksum = crc32;
            RelativeOffsetOfLocalHeader = offset;
            FileName = internalName;
            CompressedSize = size;
            UncompressedSize = size;
            FileNameLength = (ushort)internalName.Length;
            ExtraFieldLength = (ushort)(alignment - dataStart % alignment);
        }

        public ZipLocalFileHeader ToLocalHeader()
        {
            return new ZipLocalFileHeader()
            {
                Checksum = Checksum,
                CompressedSize = CompressedSize,
                UncompressedSize = UncompressedSize,
                FileNameLength = FileNameLength,
                ExtraFieldLength = ExtraFieldLength,
                FileName = FileName
            };
        }

        public void Write(EndianWriter writer)
        {
            writer.Write(Signature);
            writer.Write(VersionMadeBy);
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
            writer.Write(FileCommentLength);
            writer.Write(DiskNumberStart);
            writer.Write(InternalFileAttribs);
            writer.Write(ExternalFileAttribs);
            writer.Write(RelativeOffsetOfLocalHeader);
            writer.Write(FileName);
            writer.Write(Comment);
        }

        public uint GetObjectSize()
        {
            return (uint)(NativeSize + FileNameLength + FileCommentLength);
        }
    }
}
