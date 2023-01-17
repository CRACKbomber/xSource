using System.Numerics;

namespace Crack.xSource.MDL.Tests
{
    [TestClass()]
    public class MDLTests
    {
        private readonly StudioHeader TestFileHeader

            = new StudioHeader(
                0x54534449, // Id
                46, // Version
                0xDBAB8737, // Checksum
                "Combine_Soldier.mdl", // Name
                0x5458, // Length
                new Vector3(0.0f, -0.0f, 73), // EyePosition
                new Vector3(-2.2546973f, 6.6979408e-002f, 35.509533f), // IllumPosition
                new Vector3(-13, -13, 0), // HullMin
                new Vector3(13, 13, 72), // HullMax
                new Vector3(0, 0, 0), // ViewBbMin
                new Vector3(0, 0, 0), // ViewBbMax
                0x00000044, // Flags
                44, // BonesCount
                0x00000298, // BonesOffset
                0, // BoneControllerCount
                0x000027B8, // BoneControllerOffset
                1, // HitboxesCount
                0x000029E0, // HitboxesOffset
                1, // LocalAnimCount
                0x00002EE0, // LocalAnimOffset
                1, // NumLocalSeq
                0x000031C4, // LocalSeqIndex
                0, // ActivityListVersion
                0, // EventsIndexed
                2, // TextureCount
                0x0000363C, // TextureOffset
                1, // TextureDirCount
                0x000036BC, // TextureDirOffset
                2, // SkinRefCount
                2, // SkinFamilyCount
                0x000036C0, // SkinRefOffset
                1, // BodyPartCount
                0x0000334C, // BodyPartOffset
                6, // LocalAttachmentsCount
                0x000027B8, // LocalAttachmentsOffset
                0, // LocalNodesCount
                0x0000334C, // LocalNodesOffset
                0x0000334C, // LocalNodeNameOffset
                0, // FlexDescCount
                0x000033F0, // FlexDescOffset
                0, // FlexControllerCount
                0x000033F0, // FlexControllerOffset
                0, // FlexRuleCount
                0x000033F0, // FlexRuleOffset
                4, // IkChainCount
                0x000033F0, // IkChainOffset
                0, // MouthsCount
                0x000035C0, // MouthsOffset
                0, // LocalPoseParamCount
                0x000035C0, // LocalPostParamOffset
                0x00004EDD, // SurfacePropOffset
                0x000036C8, // KeyValueOffset
                0x00000074, // KeyValueCount
                2, // LocalIkAutoplayLocksCount
                0x00003580, // LocalIkAutoplayLocksOffset
                100.0f, // Mass
                1, // Contents
                1, // IncludeModelCount
                0x00003634, // IncludeModelOffset
                0, // VirtualModel
                0x00004EDC, // AnimBlockNameOffset
                0, // AnimBlockCount
                0x0000363C, // AnimBlockOffset
                0x00002EB4, // BoneTableByNameOffset
                0, // VertexBase
                0, // OffsetBase
                0, // DirectionalDotProduct
                0, // RootLod
                0, // NumAllowedRootLods
                0, // Unused0
                0, // Unused1
                0, // VertAnimFixedPointScale
                0, // Unused2
                408, // Unused3
                0, // FlexControllerUICount
                0x000033F0, // FlexControllerUIOffset
                0, // AnimBlockModel
                0 // StudioHdr2Index
                );

        [TestMethod()]
        public void MDLFileTest()
        {

            MDLFile testPCFile = new MDLFile(File.ReadAllBytes("D:\\temp\\mdl-swap\\pc-samples\\combine_soldier.mdl"));

        }

        public void TestStudioHeader(StudioHeader testHeader)
        {
            // IDST
            Assert.IsTrue(testHeader.Id == TestFileHeader.Id);
            Assert.IsTrue(testHeader.Version == TestFileHeader.Version);
            Assert.IsTrue(testHeader.Checksum == TestFileHeader.Checksum);
            Assert.IsTrue(testHeader.Length == TestFileHeader.Length);
            Assert.IsTrue(testHeader.Name == TestFileHeader.Name);

            // Eye position
            Assert.IsTrue(testHeader.EyePosition.X
                == TestFileHeader.EyePosition.X);
            Assert.IsTrue(testHeader.EyePosition.Y
                == TestFileHeader.EyePosition.Y);
            Assert.IsTrue(testHeader.EyePosition.Z
                == TestFileHeader.EyePosition.Z);

            // IllumPosition
            Assert.IsTrue(testHeader.IllumPosition.X
                == TestFileHeader.IllumPosition.X);
            Assert.IsTrue(testHeader.IllumPosition.Y
                == TestFileHeader.IllumPosition.Y);
            Assert.IsTrue(testHeader.IllumPosition.Z
                == TestFileHeader.IllumPosition.Z);

            Assert.IsTrue(testHeader.Flags == TestFileHeader.Flags);
            Assert.IsTrue(testHeader.BonesCount == TestFileHeader.BonesCount);
            Assert.IsTrue(testHeader.BonesOffset == TestFileHeader.BonesOffset);
            Assert.IsTrue(testHeader.BoneControllerCount == TestFileHeader.BoneControllerCount);
            Assert.IsTrue(testHeader.BoneControllerOffset == TestFileHeader.BoneControllerOffset);
            Assert.IsTrue(testHeader.HitboxesCount == TestFileHeader.HitboxesCount);
            Assert.IsTrue(testHeader.HitboxesOffset == TestFileHeader.HitboxesOffset);
            Assert.IsTrue(testHeader.LocalAnimCount == TestFileHeader.LocalAnimCount);
            Assert.IsTrue(testHeader.LocalAnimOffset == TestFileHeader.LocalAnimOffset);
            Assert.IsTrue(testHeader.NumLocalSeq == TestFileHeader.NumLocalSeq);
            Assert.IsTrue(testHeader.LocalSeqIndex == TestFileHeader.LocalSeqIndex);
            Assert.IsTrue(testHeader.ActivityListVersion == TestFileHeader.ActivityListVersion);
            Assert.IsTrue(testHeader.EventsIndexed == TestFileHeader.EventsIndexed);
            Assert.IsTrue(testHeader.TextureCount == TestFileHeader.TextureCount);
            Assert.IsTrue(testHeader.TextureOffset == TestFileHeader.TextureOffset);
            Assert.IsTrue(testHeader.TextureDirCount == TestFileHeader.TextureDirCount);
            Assert.IsTrue(testHeader.TextureDirOffset == TestFileHeader.TextureDirOffset);
            Assert.IsTrue(testHeader.SkinRefCount == TestFileHeader.SkinRefCount);
            Assert.IsTrue(testHeader.SkinFamilyCount == TestFileHeader.SkinFamilyCount);
            Assert.IsTrue(testHeader.SkinRefOffset == TestFileHeader.SkinRefOffset);
            Assert.IsTrue(testHeader.BodyPartCount == TestFileHeader.BodyPartCount);
            Assert.IsTrue(testHeader.BodyPartOffset == TestFileHeader.BodyPartOffset);
            Assert.IsTrue(testHeader.LocalAttachmentsCount == TestFileHeader.LocalAttachmentsCount);
            Assert.IsTrue(testHeader.LocalAttachmentsOffset == TestFileHeader.LocalAttachmentsOffset);
            Assert.IsTrue(testHeader.LocalNodesCount == TestFileHeader.LocalNodesCount);
            Assert.IsTrue(testHeader.LocalNodesOffset == TestFileHeader.LocalNodesOffset);
            Assert.IsTrue(testHeader.LocalNodeNameOffset == TestFileHeader.LocalNodeNameOffset);
            Assert.IsTrue(testHeader.FlexDescCount == TestFileHeader.FlexDescCount);
            Assert.IsTrue(testHeader.FlexDescOffset == TestFileHeader.FlexDescOffset);
            Assert.IsTrue(testHeader.FlexControllerCount == TestFileHeader.FlexControllerCount);
            Assert.IsTrue(testHeader.FlexControllerOffset == TestFileHeader.FlexControllerOffset);
            Assert.IsTrue(testHeader.FlexRuleCount == TestFileHeader.FlexRuleCount);
            Assert.IsTrue(testHeader.FlexRuleOffset == TestFileHeader.FlexRuleOffset);
            Assert.IsTrue(testHeader.IkChainCount == TestFileHeader.IkChainCount);
            Assert.IsTrue(testHeader.IkChainOffset == TestFileHeader.IkChainOffset);
            Assert.IsTrue(testHeader.MouthsCount == TestFileHeader.MouthsCount);
            Assert.IsTrue(testHeader.MouthsOffset == TestFileHeader.MouthsOffset);
            Assert.IsTrue(testHeader.LocalPoseParamCount == TestFileHeader.LocalPoseParamCount);
            Assert.IsTrue(testHeader.LocalPostParamOffset == TestFileHeader.LocalPostParamOffset);
            Assert.IsTrue(testHeader.SurfacePropOffset == TestFileHeader.SurfacePropOffset);
            Assert.IsTrue(testHeader.KeyValueOffset == TestFileHeader.KeyValueOffset);
            Assert.IsTrue(testHeader.KeyValueCount == TestFileHeader.KeyValueCount);
            Assert.IsTrue(testHeader.LocalIkAutoplayLocksCount == TestFileHeader.LocalIkAutoplayLocksCount);
            Assert.IsTrue(testHeader.LocalIkAutoplayLocksOffset == TestFileHeader.LocalIkAutoplayLocksOffset);
            Assert.IsTrue(testHeader.Mass == TestFileHeader.Mass);
            Assert.IsTrue(testHeader.Contents == TestFileHeader.Contents);
            Assert.IsTrue(testHeader.IncludeModelCount == TestFileHeader.IncludeModelCount);
            Assert.IsTrue(testHeader.IncludeModelOffset == TestFileHeader.IncludeModelOffset);
            Assert.IsTrue(testHeader.VirtualModel == TestFileHeader.VirtualModel);
            Assert.IsTrue(testHeader.AnimBlockOffset == TestFileHeader.AnimBlockOffset);
            Assert.IsTrue(testHeader.AnimBlockModel == TestFileHeader.AnimBlockModel);
            Assert.IsTrue(testHeader.BoneTableByNameOffset == TestFileHeader.BoneTableByNameOffset);
            Assert.IsTrue(testHeader.VertexBase == TestFileHeader.VertexBase);
            Assert.IsTrue(testHeader.OffsetBase == TestFileHeader.OffsetBase);
            Assert.IsTrue(testHeader.DirectionalDotProduct == TestFileHeader.DirectionalDotProduct);
            Assert.IsTrue(testHeader.RootLod == TestFileHeader.RootLod);
            Assert.IsTrue(testHeader.NumAllowedRootLods == TestFileHeader.NumAllowedRootLods);
            Assert.IsTrue(testHeader.Unused0 == TestFileHeader.Unused0);
            Assert.IsTrue(testHeader.Unused1 == TestFileHeader.Unused1);
            Assert.IsTrue(testHeader.FlexControllerUICount == TestFileHeader.FlexControllerUICount);
            Assert.IsTrue(testHeader.FlexControllerUIOffset == TestFileHeader.FlexControllerUIOffset);
            Assert.IsTrue(testHeader.VertAnimFixedPointScale == TestFileHeader.VertAnimFixedPointScale);
            Assert.IsTrue(testHeader.Unused2 == TestFileHeader.Unused2);
            Assert.IsTrue(testHeader.Unused3 == TestFileHeader.Unused3);
            Assert.IsTrue(testHeader.StudioHdr2Index == TestFileHeader.StudioHdr2Index);
        }
    }
}