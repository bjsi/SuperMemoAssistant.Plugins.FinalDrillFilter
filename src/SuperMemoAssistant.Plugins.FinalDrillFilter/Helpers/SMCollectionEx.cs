using SuperMemoAssistant.Interop;
using SuperMemoAssistant.Interop.SuperMemo.Core;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers
{
  public static class SMCollectionEx
  {
    public static string GetInfoFilePath(
      this SMCollection collection,
      string fileName)
    {
      return collection.CombinePath(SMConst.Paths.InfoFolder,
                                    fileName);
    }
  }
}
