using Crack.xSource.IO;
using Crack.xSource.Zip.XZP2.Headers;

namespace Crack.xSource.Zip.XZP2
{
    public class ZipFileEntry : IZipFile
    {
        public ZipFileHeader FileHeader { get; private set; }
        public string FileName => FileHeader.FileName;
        public int DataSize => (int)FileHeader.CompressedSize;
        public int EntrySize { get; set; }
        public uint DataOffset
        {
            get
            {
                return (uint)(ZipLocalFileHeader.NativeSize +
                    FileHeader.FileNameLength +
                    FileHeader.ExtraFieldLength +
                    FileHeader.RelativeOffsetOfLocalHeader);
            }
        }

        public ZipFileEntry(ZipFileHeader fileHeader)
        {
            FileHeader = fileHeader;
        }

        public byte[] GetBytes(EndianReader zipReader)
        {
            zipReader.BaseStream.Seek(DataOffset, SeekOrigin.Begin);
            return zipReader.ReadBytes(DataSize);
        }

        public byte[] GetBytes() => throw new NotImplementedException();

        public int CompareTo(IZipFile? other)
        {
            return string.Compare(FileName, other.FileName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
