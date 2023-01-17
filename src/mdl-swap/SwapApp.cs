using Crack.xSource.MDL;

namespace mdl_swap
{
    public static class SwapApp
    {
        public static void SwapMDL(string sourceFile, string destinationFile)
        {
            MDLFile inputMDL = new MDLFile(File.ReadAllBytes(sourceFile));
        }
    }
}
