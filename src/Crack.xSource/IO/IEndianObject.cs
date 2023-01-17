namespace Crack.xSource.IO
{
    public interface IEndianObject
    {
        public IEndianObject FromReader(EndianReader reader);
        public void ToWriter(EndianWriter writer);
    }
}
