using Crack.xSource.IO;

namespace Crack.xSource.Zip.XZP1.Headers
{
    public class xZipHeader : IEndianObject
    {
        private const int __Magic = 0x70695A78;
        public uint Magic { get; set; } = __Magic;
        public uint Version { get; set; }
        public uint PreloadDirCount { get; set; }
        public uint DirCount { get; set; }
        public uint PreloadSize { get; set; }
        public uint FileNameCount { get; set; }
        public uint FileNameTableOffset { get; set; }
        public uint FileNameTableLength { get; set; }

        public void FromReader(EndianReader reader)
        {
            Magic = reader.ReadUInt32();
            Version = reader.ReadUInt32();
            PreloadDirCount = reader.ReadUInt32();
            DirCount = reader.ReadUInt32();
            PreloadSize = reader.ReadUInt32();
            FileNameCount = reader.ReadUInt32();
            FileNameTableOffset = reader.ReadUInt32();
            FileNameTableLength = reader.ReadUInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(Magic);
            writer.Write(Version);
            writer.Write(PreloadDirCount);
            writer.Write(DirCount);
            writer.Write(PreloadSize);
            writer.Write(FileNameCount);
            writer.Write(FileNameTableOffset);
            writer.Write(FileNameTableLength);
        }
    }
}
