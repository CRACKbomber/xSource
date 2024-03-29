﻿using Crack.xSource.IO;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Crack.xSource.MDL
{
    [StructLayout(LayoutKind.Sequential, Size = 408)]
    public class StudioHeader : IEndianObject
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public uint Checksum { get; set; }
        public string Name { get; set; } = "";
        public int Length { get; set; }
        public Vector3 EyePosition { get; set; }
        public Vector3 IllumPosition { get; set; }
        public Vector3 HullMin { get; set; }
        public Vector3 HullMax { get; set; }
        public Vector3 ViewBbMin { get; set; }
        public Vector3 ViewBbMax { get; set; }
        public int Flags { get; set; }
        public int BonesCount { get; set; }
        public int BonesOffset { get; set; }
        public int BoneControllerCount { get; set; }
        public int BoneControllerOffset { get; set; }
        public int HitboxesCount { get; set; }
        public int HitboxesOffset { get; set; }
        public int LocalAnimCount { get; set; }
        public int LocalAnimOffset { get; set; }
        public int NumLocalSeq { get; set; }
        public int LocalSeqIndex { get; set; }
        public int ActivityListVersion { get; set; }
        public int EventsIndexed { get; set; }
        public int TextureCount { get; set; }
        public int TextureOffset { get; set; }
        public int TextureDirCount { get; set; }
        public int TextureDirOffset { get; set; }
        public int SkinRefCount { get; set; }
        public int SkinFamilyCount { get; set; }
        public int SkinRefOffset { get; set; }
        public int BodyPartCount { get; set; }
        public int BodyPartOffset { get; set; }
        public int LocalAttachmentsCount { get; set; }
        public int LocalAttachmentsOffset { get; set; }
        public int LocalNodesCount { get; set; }
        public int LocalNodesOffset { get; set; }
        public int LocalNodeNameOffset { get; set; }
        public int FlexDescCount { get; set; }
        public int FlexDescOffset { get; set; }
        public int FlexControllerCount { get; set; }
        public int FlexControllerOffset { get; set; }
        public int FlexRuleCount { get; set; }
        public int FlexRuleOffset { get; set; }
        public int IkChainCount { get; set; }
        public int IkChainOffset { get; set; }
        public int MouthsCount { get; set; }
        public int MouthsOffset { get; set; }
        public int LocalPoseParamCount { get; set; }
        public int LocalPostParamOffset { get; set; }
        public int SurfacePropOffset { get; set; }
        public int KeyValueOffset { get; set; }
        public int KeyValueCount { get; set; }
        public int LocalIkAutoplayLocksCount { get; set; }
        public int LocalIkAutoplayLocksOffset { get; set; }
        public float Mass { get; set; }
        public int Contents { get; set; }
        public int IncludeModelCount { get; set; }
        public int IncludeModelOffset { get; set; }
        public int VirtualModel { get; set; }
        public int AnimBlockNameOffset { get; set; }
        public int AnimBlockCount { get; set; }
        public int AnimBlockOffset { get; set; }
        public int AnimBlockModel { get; set; }
        public int BoneTableByNameOffset { get; set; }
        public int VertexBase { get; set; }
        public int OffsetBase { get; set; }
        public byte DirectionalDotProduct { get; set; }
        public byte RootLod { get; set; }
        public int NumAllowedRootLods { get; set; }
        public byte Unused0 { get; set; }
        public int Unused1 { get; set; }
        public int FlexControllerUICount { get; set; }
        public int FlexControllerUIOffset { get; set; }
        public float VertAnimFixedPointScale { get; set; }
        public int Unused2 { get; set; }
        public int Unused3 { get; set; }
        /// <summary>
        /// Offset for additional header information.
        /// May be zero if not present, or also 408 if it immediately follows this header
        /// </summary>
        public int StudioHdr2Index { get; set; }

        public void FromReader(EndianReader reader)
        {
            Id = reader.ReadInt32();
            Version = reader.ReadInt32();
            Checksum = reader.ReadUInt32();
            Name = reader.ReadFixedLengthString(64);
            Length = reader.ReadInt32();
            EyePosition = reader.ReadVector3();
            IllumPosition = reader.ReadVector3();
            HullMin = reader.ReadVector3();
            HullMax = reader.ReadVector3();
            ViewBbMin = reader.ReadVector3();
            ViewBbMax = reader.ReadVector3();
            Flags = reader.ReadInt32();
            BonesCount = reader.ReadInt32();
            BonesOffset = reader.ReadInt32();
            BoneControllerCount = reader.ReadInt32();
            BoneControllerOffset = reader.ReadInt32();
            HitboxesCount = reader.ReadInt32();
            HitboxesOffset = reader.ReadInt32();
            LocalAnimCount = reader.ReadInt32();
            LocalAnimOffset = reader.ReadInt32();
            NumLocalSeq = reader.ReadInt32();
            LocalSeqIndex = reader.ReadInt32();
            ActivityListVersion = reader.ReadInt32();
            EventsIndexed = reader.ReadInt32();
            TextureCount = reader.ReadInt32();
            TextureOffset = reader.ReadInt32();
            TextureDirCount = reader.ReadInt32();
            TextureDirOffset = reader.ReadInt32();
            SkinRefCount = reader.ReadInt32();
            SkinFamilyCount = reader.ReadInt32();
            SkinRefOffset = reader.ReadInt32();
            BodyPartCount = reader.ReadInt32();
            BodyPartOffset = reader.ReadInt32();
            LocalAttachmentsCount = reader.ReadInt32();
            LocalAttachmentsOffset = reader.ReadInt32();
            LocalNodesCount = reader.ReadInt32();
            LocalNodesOffset = reader.ReadInt32();
            LocalNodeNameOffset = reader.ReadInt32();
            FlexDescCount = reader.ReadInt32();
            FlexDescOffset = reader.ReadInt32();
            FlexControllerCount = reader.ReadInt32();
            FlexControllerOffset = reader.ReadInt32();
            FlexRuleCount = reader.ReadInt32();
            FlexRuleOffset = reader.ReadInt32();
            IkChainCount = reader.ReadInt32();
            IkChainOffset = reader.ReadInt32();
            MouthsCount = reader.ReadInt32();
            MouthsOffset = reader.ReadInt32();
            LocalPoseParamCount = reader.ReadInt32();
            LocalPostParamOffset = reader.ReadInt32();
            SurfacePropOffset = reader.ReadInt32();
            KeyValueOffset = reader.ReadInt32();
            KeyValueCount = reader.ReadInt32();
            LocalIkAutoplayLocksCount = reader.ReadInt32();
            LocalIkAutoplayLocksOffset = reader.ReadInt32();
            Mass = reader.ReadSingle();
            Contents = reader.ReadInt32();
            IncludeModelCount = reader.ReadInt32();
            IncludeModelOffset = reader.ReadInt32();
            VirtualModel = reader.ReadInt32();
            AnimBlockNameOffset = reader.ReadInt32();
            AnimBlockCount = reader.ReadInt32();
            AnimBlockOffset = reader.ReadInt32();
            AnimBlockModel = reader.ReadInt32();
            BoneTableByNameOffset = reader.ReadInt32();
            VertexBase = reader.ReadInt32();
            OffsetBase = reader.ReadInt32();
            DirectionalDotProduct = reader.ReadByte();
            RootLod = reader.ReadByte();
            NumAllowedRootLods = reader.ReadInt32();
            Unused0 = reader.ReadByte();
            Unused1 = reader.ReadByte();
            FlexControllerUICount = reader.ReadInt32();
            FlexControllerUIOffset = reader.ReadInt32();
            VertAnimFixedPointScale = reader.ReadSingle();
            Unused2 = reader.ReadInt32();
            StudioHdr2Index = reader.ReadInt32();
            Unused3 = reader.ReadInt32();
        }

        public void ToWriter(EndianWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
