using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using SuperMemoAssistant.Services;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills
{
  public class DrillReader : SubsetReader
  {

    public DrillReader(): base(GetDrillPath()) { }
    public DrillReader(FilePath path): base(path) { }

    private static FilePath GetDrillPath()
    {
      return Svc.SM.Collection.GetInfoFilePath("drill.dat");
    }
  }
}
