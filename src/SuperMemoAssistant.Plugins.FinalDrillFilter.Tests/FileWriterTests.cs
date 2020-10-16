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
    public void FileWriterWritesData()
    {
      var list = new List<int> { 1, 2, 3, 4, 5 };
      var writer = new FilteredDrillWriter(list, TestFile);
      var ret = writer.WriteDrillFile();
      Assert.True(ret);
    }

    [Fact]
    public void FileWriterWritesCorrectData()
    {
      var expected = new List<int> { 1, 2, 3, 4, 5 };
      var writer = new FilteredDrillWriter(expected, TestFile);
      var ret = writer.WriteDrillFile();
      Assert.True(ret);

      var reader = new DrillReader(TestFile);
      var actual = reader.ReadSubsetFile();
      Assert.Equal(expected, actual);
    }
  }
}
