using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets;
using SuperMemoAssistant.Services;
using System;
using System.Collections.Generic;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills
{
  public class FilteredDrillWriter : SubsetWriter
  {

    private static DirectoryPath SubsetsDir = new DirectoryPath(Svc.SM.Collection.Path).Combine("subsets");
    private static DirectoryPath FilteredDrillsDir = SubsetsDir.Combine("drills");

    public FilteredDrillWriter(List<int> elementIds) : base(elementIds) { }

    public bool WriteDrillFile()
    {
      var file = GenerateDrillPath();
      return WriteSubsetFile(file);
    }

    private static FilePath GenerateDrillPath()
    {
      var fileName = DateTime.Now.ToString("yyyyMMddTHHmmss") + "_drill.sub";
      return FilteredDrillsDir.CombineFile(fileName);
    }
  }
}
