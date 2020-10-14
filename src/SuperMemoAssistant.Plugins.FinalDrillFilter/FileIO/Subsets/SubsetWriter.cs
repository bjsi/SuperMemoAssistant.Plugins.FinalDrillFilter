using Anotar.Serilog;
using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using System.Collections.Generic;
using System.IO;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets
{
  public class SubsetWriter
  {

    private List<int> ElementIds { get; }

    public SubsetWriter(List<int> elementIds)
    {
      this.ElementIds = elementIds;
      elementIds.ThrowIfNullOrEmpty("Failed to create subset writer because element ids were null or empty");
    }

    protected bool WriteSubsetFile(FilePath file)
    {
      try
      {
        using (var writer = new BinaryWriter(File.OpenWrite(file.FullPath)))
        {
          foreach (int id in ElementIds)
          {
            writer.Write(id);
          }
        }

        return true;
      }
      catch (IOException e)
      {
        LogTo.Debug(e, "Failed to write subset file due to IOException");
        return false;
      }
    }
  }
}
