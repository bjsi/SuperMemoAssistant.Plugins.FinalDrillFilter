using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets;
using SuperMemoAssistant.Services;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills
{
  public class DrillReader : SubsetReader
  {
    private static DirectoryPath InfoDir { get; } = new DirectoryPath(Svc.SM.Collection.Path).Combine("info");
    private static FilePath DrillFile { get; } = InfoDir.CombineFile("drill.dat");

    public DrillReader(): base(DrillFile) { }
    public DrillReader(FilePath path): base(path) { }
  }
}
