using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Subsets
{
  /// <summary>
  /// Enables reading Supermemo .sub files and the drill.dat file.
  /// </summary>
  public class SubsetReader
  {

    private FilePath SubsetFile { get; }

    public SubsetReader(FilePath file)
    {
      file.ThrowIfNotExists("Failed to create subset file reader because the file does not exist");
      SubsetFile = file;
    }

    /// <summary>
    /// Read the binary file as a list of ints
    /// </summary>
    /// <returns>List of ints</returns>
    public List<int> ReadFile()
    {
      using (Stream stream = File.OpenRead(SubsetFile.FullPath))
        return ParseSubsetFileStream(stream);
    }

    private List<int> ParseSubsetFileStream(Stream stream)
    {

      var ret = new List<int>();

      using (BinaryReader binStream = new BinaryReader(stream, Encoding.Default))
      {
        while (binStream.BaseStream.Position < binStream.BaseStream.Length)
        {
          var num = binStream.ReadInt32();
          ret.Add(num);
        }
      }

      return ret;
    }
  }
}
