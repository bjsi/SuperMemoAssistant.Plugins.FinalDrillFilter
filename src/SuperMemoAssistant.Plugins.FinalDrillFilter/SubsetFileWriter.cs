using Anotar.Serilog;
using Extensions.System.IO;
using Serilog;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using SuperMemoAssistant.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter
{
  public class SubsetFileWriter
  {

    private List<int> ElementIds { get; }
    private static DirectoryPath SubsetsDir { get; } = new DirectoryPath(Svc.SM.Collection.Path).Combine("subsets");
    private DirectoryPath FilteredDrillsDir { get; } = SubsetsDir.Combine("filtered_drills");

    public SubsetFileWriter(List<int> elementIds, DirectoryPath filteredDrillsDir = null)
    {
    }

  }
}
