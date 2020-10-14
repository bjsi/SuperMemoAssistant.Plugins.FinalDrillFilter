using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills;
using System;
using System.Collections.Generic;
using Xunit;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Tests
{
  public class FileWriterTests
  {

    private static DirectoryPath FixtureDir = new DirectoryPath(Environment.CurrentDirectory).Combine("Fixture");
    private FilePath TestFile { get; } = FixtureDir.CombineFile(@"write_tests.sub");

    [Fact]
    public void FileWriterWritesCorrectData()
    {
      var list = new List<int> { 1, 2, 3, 4, 5 };
      var writer = new FilteredDrillWriter(list);
      var ret = writer.WriteDrillFile();
      Assert.True(ret);

      // Read back to check
    }
  }
}
