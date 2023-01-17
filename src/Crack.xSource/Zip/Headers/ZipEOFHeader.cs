using Crack.xSource.IO;
using System.Runtime.InteropServices;

namespace Crack.xSource.Zip.Headers
{
    [StructLayout(LayoutKind.Sequential, Size = 0x16)]
    public class ZipEOF
    {
        private const uint __Signature = 0x6054B50;
        public uint Signature { get; private set; } = __Signature;
        public ushort NumberOfThisDisk { get; private set; } = 0;
        public ushort NumberOfTheDiskWithStartOfCentralDirectory { get; private set; } = 0;
        public ushort DirectoryEntries { get; private set; }
        public ushort DirectoryEntriesTotal { get; private set; }
        public uint DirectorySize { get; private set; }
        public uint DirectoryOffset { get; private set; }
        public ushort CommentLength { get; private set; } = 32;
        public string Comment { get; private set; } = "XZP2 2048";

        public ZipEOF(EndianReader reader)
        {
            reader.BaseStream.Seek(-0x36, SeekOrigin.End);
            Signature = reader.ReadUInt32();
            if (Signature != __Signature)
                throw new Exception("Invalid signature on zip");
            NumberOfThisDisk = reader.ReadUInt16();
            NumberOfTheDiskWithStartOfCentralDirectory = reader.ReadUInt16();
            DirectoryEntries = reader.ReadUInt16();
            DirectoryEntriesTotal = reader.ReadUInt16();
            DirectorySize = reader.ReadUInt32();
            DirectoryOffset = reader.ReadUInt32();
            CommentLength = reader.ReadUInt16();
            Comment = reader.ReadFixedLengthString(CommentLength);
        }

        public ZipEOF(ushort numDirEntries, uint dirSize, uint dirOffset)
        {
            DirectoryEntries = numDirEntries;
            DirectoryEntriesTotal = numDirEntries;
            DirectoryOffset = dirOffset;
            DirectorySize = dirSize;
        }

        public void Write(EndianWriter writer)
        {
            writer.Write(Signature);
            writer.Write(NumberOfThisDisk);
            writer.Write(NumberOfTheDiskWithStartOfCentralDirectory);
            writer.Write(DirectoryEntries);
            writer.Write(DirectoryEntriesTotal);
            writer.Write(DirectorySize);
            writer.Write(DirectoryOffset);
            writer.Write(CommentLength);
            writer.Write(Comment);

            var commentPad = CommentLength - Comment.Length;

            if (commentPad > 0)
                writer.Pad(commentPad);

        }
    }
}
