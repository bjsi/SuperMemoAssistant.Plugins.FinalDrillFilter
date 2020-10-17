using HtmlAgilityPack;
using System.Web;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers
{
  public static class HtmlEx
  {
    public static string StripHtmlTags(this string input)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(input);
      return doc.DocumentNode.InnerText;
    }

    public static string DecodeHtml(this string input)
    {
      return HttpUtility.HtmlDecode(input);
    }
  }
}
