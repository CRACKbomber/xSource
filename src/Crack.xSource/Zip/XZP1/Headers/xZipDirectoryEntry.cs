using Crack.xSource.IO;

namespace Crack.xSource.Zip.XZP1.Headers
{
    public class xZipDirectoryEntry : IEndianObject
    {
        public uint FileNameCRC { get; set; }
        public uint Size { get; set; }
        public uint Offset { get; set; }

        public void FromReader(EndianReader reader)
        {
            FileNameCRC = reader.ReadUInt32();
            Size = reader.ReadUInt32();
            Offset = reader.ReadUInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(FileNameCRC);
            writer.Write(Size);
            writer.Write(Offset);
        }
    }
}
