#region License & Metadata

// The MIT License (MIT)
// 
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// 
// 
// Created On:   10/14/2020 10:00:46 PM
// Modified By:  james

#endregion




using Extensions.System.IO;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Tests
{
  public class FileReaderTests
  {

    private static DirectoryPath FixtureDir = new DirectoryPath(Environment.CurrentDirectory).Combine("Fixture");

    /// <summary>
    /// Test .sub file containing the integers 1, 2, 3, 4, 5
    /// </summary>
    private readonly FilePath TestFile = FixtureDir.CombineFile("test_file.sub");

    [Fact]
    public void FileReaderReadsCorrectData()
    {
      var expected = new List<int> { 1, 2, 3, 4, 5 };
      var reader = new DrillReader(TestFile);
      var list = reader.ReadSubsetFile();

      Assert.Equal(expected, list);
    }

    [Fact]
    public void FileReaderThrowsIfFileNotExists()
    {
      Assert.Throws<InvalidOperationException>(() => new DrillReader("sdasdsad38479328s0jdoqmd03m"));
    }
  }
}
