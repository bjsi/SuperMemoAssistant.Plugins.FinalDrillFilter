using System.Collections.Generic;
using System.Linq;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers
{
  public static class IEnumerableEx
  {
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> e)
    {
      return e == null || !e.Any();
    }
  }
}
