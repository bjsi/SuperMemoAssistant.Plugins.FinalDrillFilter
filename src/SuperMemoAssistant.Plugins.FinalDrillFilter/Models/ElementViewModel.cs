using SuperMemoAssistant.Extensions;
using SuperMemoAssistant.Interop.SuperMemo.Content.Components;
using SuperMemoAssistant.Interop.SuperMemo.Content.Models;
using SuperMemoAssistant.Interop.SuperMemo.Elements.Types;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Models
{
  public class ElementViewModel
  {

    private readonly IElement _element;

    public ElementViewModel(IElement element)
    {
      element.ThrowIfArgumentNull("Failed to create view model because IElement is null");
      _element = element;
    }

    public int Id => _element.Id;
    public string CategoryPathString => string.Join(", ", _element.GetCategoryPath());
    public List<string> CategoryPath => _element.GetCategoryPath();

    private string GetFirstTextValueByAtFlag(AtFlags atFlag)
    {
      string ret = string.Empty;
      var compGrp = _element.ComponentGroup;
      for (int i = 0; i < compGrp.Count; i++)
      {
        var comp = compGrp[i] as IComponentHtml;
        if (comp == null)
          continue;

        var disp = comp.DisplayAt;
        if (disp == atFlag)
          ret = comp.Text?.Value?.StripHtmlTags();
      }

      return ret ?? string.Empty;
    }

    public string Question 
    {
      get
      {
        return GetFirstTextValueByAtFlag(AtFlags.All);
      }
    }

    public string Answer
    {
      get
      {
        return GetFirstTextValueByAtFlag(AtFlags.NonQuestion);
      }
    }
  }
}
