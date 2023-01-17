using Crack.xSource.Compression;
using Crack.xSource.IO;
using NLog;

namespace Crack.xSource.MDL
{
    public class MDLFile
    {
        private static readonly Logger s_logger = LogManager.GetCurrentClassLogger();
        public StudioHeader Header { get; private set; }
        public StudioHeader2 Header2 { get; private set; }
        public List<StudioBone> Bones { get; private set; }
        public Dictionary<int, string> StringTable { get; private set; }
        public MDLFile(byte[] inputBuffer) => ParseFromBuffer(inputBuffer);

        /// <summary>
        /// Parse the MDL file based on the platform type
        /// </summary>
        /// <param name="mdlBytes"></param>
        private void ParseFromBuffer(byte[] inputBuffer)
        {
            byte[] mdlBuffer = inputBuffer;
            AssetAttributes mdlAttribs = mdlBuffer.GetAssetAttributes();
            Bones = new List<StudioBone>();

            // Compressed MDL
            if (mdlAttribs.HasFlag(AssetAttributes.COMPRESSION_LZMA))
                mdlBuffer = mdlBuffer.DecompressLZMA();

            using (var reader = new EndianReader(new MemoryStream(mdlBuffer), mdlAttribs.HasFlag(AssetAttributes.ENDIAN_BIG)))
            {
                int testingBytesRead = 0;

                ParseHeader(reader);
                // Bones
                ParseBones(reader);

                Console.WriteLine($"MDL READER READ {testingBytesRead}/{mdlBuffer.Length}");
            }

        }

        private void ParseHeader(EndianReader reader)
        {
            Header = StudioHeader.FromReader(reader);

            s_logger.Info($"Name: {Header.Name}");
            s_logger.Info($"Version: {Header.Version}");
            s_logger.Info($"Checksum: {Header.Checksum}");
            s_logger.Info($"Number of Bones: {Header.BonesCount}");

            if (Header.StudioHdr2Index > 0)
            {
                reader.BaseStream.Seek(Header.StudioHdr2Index, SeekOrigin.Begin);
                Header2 = new StudioHeader2();
                Header2.Read(reader);
            }
        }

        private string IndexStringTable(int offset, EndianReader reader)
        {
            if (!StringTable.Keys.Contains(offset))
            {
                s_logger.Trace($"offset {offset} is not indexed in the string table");
                reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                StringTable.Add(offset, reader.ReadString());
            }
            else
                s_logger.Trace($"offset {offset} is indexed in the string table as '{StringTable[offset]}'");
            return StringTable[offset];
        }

        private void ParseBones(EndianReader reader)
        {
            reader.BaseStream.Position = Header.BonesOffset;

            for (int i = 0; i < Header.BonesCount; i++)
            {
                var bone = new StudioBone();
                bone.Read(reader);
                Bones.Add(bone);
                // TODO: AXIS-INTERP BONES
                // TODO: QUAT-INTERP BONES
                // TODO: QUAT-INTERP TRIGGERS
                // TODO: JIGGLE BONES
                // TODO: AIM AT BONES
            }

            // build string table for surface prop names and bone names
            foreach (StudioBone bone in Bones)
            {
                bone.Name = IndexStringTable(bone.NameOffset, reader);
                bone.SurfaceProp = IndexStringTable(bone.SurfacePropOffset, reader);
            }
        }
    }
}
