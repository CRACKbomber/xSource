using Crack.xSource.Zip.XZP2.Headers;

namespace Crack.xSource.Zip.XZP2
{
    public class PreloadSection
    {
        private readonly MemoryStream _stream;
        public PreloadHeader Header { get; private set; }
        //public List<PreloadDirectoryEntry> RemapDirectory { get; private set; }

        public bool IsFilePreloadable(LocalFileEntry localFile)
        {
            // small files, always add
            switch (localFile.Extension)
            {
                case ".bnf":
                case ".cfg":
                case ".dat":
                case ".inf":
                case ".lst":
                case ".pcf":
                case ".rc":
                case ".res":
                case ".txt":
                case ".vbf":
                case ".vfe":
                case ".vmt":
                    return true;
            }

            // TODO: WAV preloads
            // TODO: Basically all assets

            return false;
        }
    }
}
