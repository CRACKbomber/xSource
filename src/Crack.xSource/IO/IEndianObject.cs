namespace Crack.xSource.IO
{
    public interface IEndianObject
    {
        public void FromReader(EndianReader reader);
        public void ToWriter(EndianWriter writer);
    }
}
