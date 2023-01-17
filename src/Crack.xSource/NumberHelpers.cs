namespace Crack.xSource
{
    public static class NumberHelpers
    {
        public static uint AlignValue(this uint val, uint alignment)
        {
            return (val + alignment - 1) & ~(alignment - 1);
        }
    }
}
