using Crack.xSource.IO;

namespace Crack.xSource.Zip
{
    public interface IZipFile : IComparable<IZipFile>
    {
        string FileName { get; }
        byte[] GetBytes();
        byte[] GetBytes(EndianReader zipReader);
    }
}
