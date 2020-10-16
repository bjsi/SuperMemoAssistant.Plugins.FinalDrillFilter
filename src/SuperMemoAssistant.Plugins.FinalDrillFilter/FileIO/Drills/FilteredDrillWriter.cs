using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Interfaces;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets;
using SuperMemoAssistant.Services;
using System;
using System.Collections.Generic;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills
{
  public class FilteredDrillWriter : SubsetWriter, IDrillWriter
  {

    private FilePath SubsetFile { get; } 

    public FilteredDrillWriter(List<int> elementIds, FilePath outputFile = null) : base(elementIds) 
    {
      SubsetFile = outputFile == null
        ? GenerateDrillPath()
        : outputFile;
    }

    public bool WriteDrillFile()
    {
      return WriteSubsetFile(SubsetFile);
    }

    private static FilePath GenerateDrillPath()
    {
      var SubsetsDir = new DirectoryPath(Svc.SM.Collection.Path).Combine("subsets");
      var FilteredDrillsDir = SubsetsDir.Combine("drills");
      var fileName = DateTime.Now.ToString("yyyyMMddTHHmmss") + "_drill.sub";
      return FilteredDrillsDir.CombineFile(fileName);
    }
  }
}
