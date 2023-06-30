using Crack.xSource.IO;

namespace Crack.xSource.Zip.XZP1.Headers
{
    public class xZipFooter : IEndianObject
    {
        public uint Size { get; set; }
        public uint Magic { get; set; }
        public void FromReader(EndianReader reader)
        {
            Size = reader.ReadUInt32();
            Magic = reader.ReadUInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            writer.Write(Size);
            writer.Write(Magic);
        }
    }
}
