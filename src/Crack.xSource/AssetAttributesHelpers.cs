namespace Crack.xSource
{
    public static class AssetAttributesHelpers
    {
        /// <summary>
        /// Determine the asset properties based on the magic of the buffer (file)
        /// </summary>
        /// <param name="buffer">asset file buffer</param>
        /// <returns></returns>
        public static AssetAttributes GetAssetAttributes(this byte[] buffer)
        {
            AssetAttributes fileType = AssetAttributes.UNKNOWN;
            var magic = System.Text.Encoding.ASCII.GetString(buffer, 0, 4);

            switch (magic)
            {
                case "IDST": // PC format
                    fileType |= AssetAttributes.ENDIAN_LITTLE | AssetAttributes.COMPRESSION_NONE;
                    break;
                case "LZMA": // Compressed Console File
                    fileType |= AssetAttributes.ENDIAN_BIG | AssetAttributes.COMPRESSION_LZMA;
                    break;
                case "TSDI": // Uncompressed Console File
                    fileType |= AssetAttributes.ENDIAN_BIG | AssetAttributes.COMPRESSION_NONE;
                    break;
                default: // Invalid file
                    fileType = AssetAttributes.UNKNOWN;
                    break;

            }
            return fileType;
        }
    }
}
