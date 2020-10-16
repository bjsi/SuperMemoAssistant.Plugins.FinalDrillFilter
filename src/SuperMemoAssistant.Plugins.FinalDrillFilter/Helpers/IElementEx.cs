using SuperMemoAssistant.Interop.SuperMemo.Elements.Models;
using SuperMemoAssistant.Interop.SuperMemo.Elements.Types;
using System.Collections.Generic;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers
{
  public static class IElementEx
  {
    public static List<string>  GetCategoryPath(this IElement element)
    {
      var ret = new List<string>();
      while (element != null)
      {
        var parent = element.Parent;
        if (parent != null && parent.Type == ElementType.ConceptGroup)
        {
          // TODO: Is this correct?
          ret.Add(parent.Title);
        }
        element = parent;
      }
      return ret;
    }
  }
}
