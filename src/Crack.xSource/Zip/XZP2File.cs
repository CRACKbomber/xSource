using Crack.xSource.IO;
using Crack.xSource.Security;
using Crack.xSource.Zip.Headers;
using NLog;
using ObjectPrinter;
using System.Text.RegularExpressions;

namespace Crack.xSource.Zip
{
    public class XZP2File : IDisposable
    {
        private static readonly Logger s_logger = LogManager.GetCurrentClassLogger();
        private readonly EndianReader _zipReader;
        private bool disposedValue;

        public string FileName { get; private set; }
        public PreloadSection ZipPreloadSection { get; private set; }

        public Dictionary<string, IZipFile> Files { get; private set; }

        public XZP2File(string zipPath, bool create = false, FileAccess fileAccess = FileAccess.Read)
        {
            Files = new Dictionary<string, IZipFile>();
            FileName = zipPath;
            _zipReader = new EndianReader(File.Open(FileName, FileMode.Open, fileAccess), false);
            OpenZip();
        }

        /// <summary>
        /// TODO: Gentrify this ghetto method
        /// </summary>
        public static void Create(string zipPath, string localDirectory, int pad = 0, string searchPattern = "*", uint alignment = 0x800)
        {
            s_logger.Info($"Creating {zipPath} from {localDirectory}");
            var localFiles = new List<LocalFileEntry>();
            var zipDirectory = new List<ZipFileEntry>();

            // build local file list
            Directory.GetFiles(localDirectory, searchPattern, SearchOption.AllDirectories)
                     .ToList()
                     .ForEach(x => localFiles.Add(new LocalFileEntry(x, localDirectory)));

            // order list
            localFiles = localFiles.OrderBy(x => x.RelativeZipPath).ToList();

            using (EndianWriter writer = new EndianWriter(CreateOutputFile(zipPath), false))
            {
                // write file entries
                foreach (var localFile in localFiles)
                {
                    var fileData = File.ReadAllBytes(localFile.FileName);
                    var zipHdr = localFile.ToZipFileHeader((uint)writer.BaseStream.Position, CRC32.Compute(fileData));
                    zipHdr.ToLocalHeader().Write(writer);
                    writer.Write(new byte[zipHdr.ExtraFieldLength]);
                    writer.Write(fileData);

                    zipDirectory.Add(new ZipFileEntry(zipHdr));
                    s_logger.Info($"Wrote {localFile.FileName} to {zipPath}");
                }

                s_logger.Trace($"End of local file entries at 0x{writer.Offset.ToString("X")}");

                zipDirectory.Sort();

                // pad start of central directory
                var cdirStart = writer.Align();

                s_logger.Trace($"Writing central directory at {writer.Offset.ToString("X")}");
                // write directory
                foreach (var dirEntry in zipDirectory)
                {
                    dirEntry.FileHeader.Write(writer);
                }

                // pad end of central directory
                var cdirEnd = writer.Align();

                // calculate aligned size
                var cdirSize = cdirEnd - cdirStart;

                s_logger.Trace($"End of local file entries at 0x{writer.Offset.ToString("X")}");

                var zipEOF = new ZipEOF((ushort)zipDirectory.Count, cdirSize, cdirStart);
                zipEOF.Write(writer);

                s_logger.Trace(zipEOF.Dump());
            }

            s_logger.Info($"Successfully created {zipPath}");
        }

        public void ExtractWildCard(string localDirectory, string searchPattern)
        {
            // build regular expression for an wildcards
            ExtractRegex(localDirectory, RegexHelpers.WildCardToRegex(searchPattern));
        }

        public void ExtractRegex(string localDirectory, string regexPattern)
        {
            Files.Keys.ToList()
                      .FindAll(x => Regex.IsMatch(x, regexPattern, RegexOptions.IgnoreCase))
                      .ForEach(match => ExtractFile(Path.Join(localDirectory, match), match));
        }

        public void ExtractFile(string localFileName, string zipFileName)
        {
            using (EndianWriter writer = new EndianWriter(CreateOutputFile(localFileName), false))
                writer.Write(GetFileBytes(zipFileName));
        }

        public byte[] GetFileBytes(string fileName)
        {
            return Files[fileName].GetBytes(_zipReader);
        }

        public void OpenZip()
        {
            s_logger.Trace($"Reading zip {FileName}");
            ZipFileEntry zipFileEntry;
            ZipEOF eof = new ZipEOF(_zipReader);
            s_logger.Trace(eof.Dump());
            // seek to central directory
            _zipReader.BaseStream.Seek(eof.DirectoryOffset, SeekOrigin.Begin);

            // read in directory
            for (int i = 0; i < eof.DirectoryEntries; i++)
            {
                zipFileEntry = new ZipFileEntry(new ZipFileHeader(_zipReader));
                Files.Add(zipFileEntry.FileName, zipFileEntry);
                s_logger.Trace($"Found {zipFileEntry.FileName} in {FileName}");
            }
        }

        private static FileStream CreateOutputFile(string path)
        {
            // check if directory exists, create otherwise
            var parentDir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(parentDir) && !Directory.Exists(parentDir))
                Directory.CreateDirectory(parentDir);

            return File.Create(path);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_zipReader != null)
                        _zipReader.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
