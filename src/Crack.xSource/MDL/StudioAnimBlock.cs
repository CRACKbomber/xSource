using Crack.xSource.IO;

namespace Crack.xSource.MDL
{
    internal class StudioAnimBlock : IEndianObject
    {
        public int DataStart { get; set; }
        public int DataEnd { get; set; }

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
