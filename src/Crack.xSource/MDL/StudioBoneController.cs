using Crack.xSource.IO;

namespace Crack.xSource.MDL
{
    public class StudioBoneController : IEndianObject
    {
        public int Bone { get; set; }  // -1 == 0

        public int type;
        public float start;
        public float end;
        public int rest;   // byte index value at rest
        public int inputfield; // 0-3 user set controller, 4 mouth
        public int unused1;
        public int unused2;

        public void FromReader(EndianReader reader)
        {
            throw new NotImplementedException();
        }

        public void ToWriter(EndianWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
