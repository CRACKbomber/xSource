using Crack.xSource.IO;

namespace Crack.xSource.Zip.XZP1.Headers
{
    public class xZipFileNameEntry : IEndianObject
    {
        public uint FileNameCRC { get; set; }
        public uint FileNameOffset { get; set; }
        public uint TimeStamp { get; set; }
        public void FromReader(EndianReader reader)
        {
            throw new NotImplementedException();
        }

        public void ToWriter(EndianWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
