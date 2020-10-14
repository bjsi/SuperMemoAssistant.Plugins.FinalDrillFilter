using Extensions.System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers
{
  public static class ExceptionEx
  {
    public static void ThrowIfNotExists(this FilePath path, string errMsg)
    {
      if (!path.Exists())
        throw new InvalidOperationException(errMsg);
    }

    public static void ThrowIfNotExists(this DirectoryPath path, string errMsg)
    {
      if (!path.Exists())
        throw new InvalidOperationException(errMsg);
    }

    public static void ThrowIfNullOrEmpty<T>(this List<T> list, string errMsg)
    {
      if (list == null || !list.Any())
        throw new InvalidOperationException(errMsg);
    }
  }
}
