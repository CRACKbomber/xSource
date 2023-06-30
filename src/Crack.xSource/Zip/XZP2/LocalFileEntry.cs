using Crack.xSource.IO;
using Crack.xSource.Zip.XZP2.Headers;

namespace Crack.xSource.Zip.XZP2
{
    public class LocalFileEntry : IZipFile
    {
        public string SourceRoot { get; private set; }
        public string FileName { get; private set; }
        public string ExtLessName => Path.GetFileNameWithoutExtension(FileName);
        public string? Directory => Path.GetDirectoryName(FileName);
        public string Extension => Path.GetExtension(FileName);
        public string RelativeZipPath => FileName.Replace(SourceRoot + "\\", string.Empty);
        public FileInfo LocalFileInfo { get; private set; }

        public LocalFileEntry(string filePath, string srcRoot)
        {
            SourceRoot = srcRoot;
            FileName = filePath;
            LocalFileInfo = new FileInfo(filePath);
        }

        public ZipFileHeader ToZipFileHeader(uint offset, uint crc32)
        {
            return new ZipFileHeader(RelativeZipPath,
                                     crc32,
                                     (uint)LocalFileInfo.Length,
                                     offset);
        }

        public byte[] GetBytes()
        {
            return File.ReadAllBytes(FileName);
        }

        public byte[] GetBytes(EndianReader zipReader)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IZipFile? other)
        {
            return string.Compare(FileName, other.FileName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
