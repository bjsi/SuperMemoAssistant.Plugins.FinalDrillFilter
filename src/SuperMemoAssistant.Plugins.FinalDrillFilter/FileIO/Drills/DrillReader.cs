using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets;
using SuperMemoAssistant.Services;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills
{
  public class DrillReader : SubsetReader
  {

    public DrillReader(): base(GetDrillPath()) { }
    public DrillReader(FilePath path): base(path) { }

    private static FilePath GetDrillPath()
    {
      var infoDir = new DirectoryPath(Svc.SM.Collection.Path).Combine("info");
      return infoDir.CombineFile("drill.dat");
    }
  }
}
