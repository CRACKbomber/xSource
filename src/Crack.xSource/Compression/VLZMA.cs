using Crack.xSource.IO.Extensions;
using LZMADecoder = SevenZip.Compression.LZMA.Decoder;
using LZMAEncoder = SevenZip.Compression.LZMA.Encoder;

namespace Crack.xSource.Compression
{
    public static class VLZMA
    {
        /// <summary>
        /// Header magic char(LZMA)
        /// </summary>
        public const int VALVE_LZMA_ID = 0x414D5A4C;

        public struct VLZMAFormat
        {
            public const int HEADER_SIZE = 17;
            public int ID { get; set; }
            public int Size { get; set; }
            public int CompressedSize { get; set; }
            public byte[] LZMAProperties { get; set; }
            public byte[] CompressedData { get; set; }

            public byte[] Serialize()
            {
                byte[] finalBuf;
                using (var stream = new MemoryStream())
                {
                    stream.Write(ID);
                    stream.Write(Size);
                    stream.Write(CompressedSize);
                    stream.Write(LZMAProperties);
                    stream.Write(CompressedData);
                    finalBuf = stream.ToArray();
                }
                return finalBuf;
            }
        }

        public static byte[] GetEncoderProps(this LZMAEncoder encoder)
        {
            using (var tempStream = new MemoryStream())
            {
                encoder.WriteCoderProperties(tempStream);
                return tempStream.GetBuffer();
            }
        }

        public static byte[] CompressVLZMA(this byte[] buffer)
        {
            var lzmaEncoder = new LZMAEncoder();
            VLZMAFormat vlzmaObj;

            using (var compressedStream = new MemoryStream(buffer.Length / 8))
            {
                using (var inputStream = new MemoryStream(buffer))
                {
                    // compress the input stream
                    lzmaEncoder.Code(inputStream, compressedStream,
                        inputStream.Length, compressedStream.Length, null);
                }

                // assemble final struct
                vlzmaObj = new VLZMAFormat()
                {
                    ID = VALVE_LZMA_ID,
                    Size = buffer.Length,
                    CompressedSize = (int)compressedStream.Length,
                    LZMAProperties = lzmaEncoder.GetEncoderProps(),
                    CompressedData = compressedStream.ToArray()
                };
            }

            return vlzmaObj.Serialize();
        }

        public static byte[] DecompressLZMA(this byte[] buffer)
        {
            var vlzmaObj = new VLZMAFormat();
            var lzmaDecoder = new LZMADecoder();
            MemoryStream decompStream;

            // invalid size. less than header size
            if (buffer.Length < VLZMAFormat.HEADER_SIZE) return buffer;

            using (var compressedStream = new MemoryStream(buffer))
            {
                vlzmaObj.ID = compressedStream.ReadInt();
                vlzmaObj.Size = compressedStream.ReadInt();
                vlzmaObj.CompressedSize = compressedStream.ReadInt();
                vlzmaObj.LZMAProperties = compressedStream.ReadBytes(5);
                vlzmaObj.CompressedData = compressedStream.ReadBytes(vlzmaObj.CompressedSize);
            }

            decompStream = new MemoryStream(vlzmaObj.Size);
            lzmaDecoder.SetDecoderProperties(vlzmaObj.LZMAProperties);
            lzmaDecoder.Code(new MemoryStream(vlzmaObj.CompressedData), decompStream, vlzmaObj.CompressedSize, vlzmaObj.Size, null);

            return decompStream.ToArray();
        }
    }
}
