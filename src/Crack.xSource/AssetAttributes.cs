namespace Crack.xSource
{
    [Flags]
    public enum AssetAttributes
    {
        UNKNOWN = 0,
        COMPRESSION_NONE = 1 << 0,
        COMPRESSION_LZMA = 1 << 1,
        ENDIAN_LITTLE = 1 << 2,
        ENDIAN_BIG = 1 << 3
    }
}
