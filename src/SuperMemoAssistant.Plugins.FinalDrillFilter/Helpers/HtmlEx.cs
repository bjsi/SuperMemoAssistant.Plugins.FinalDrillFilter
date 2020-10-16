using HtmlAgilityPack;

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
  }
}
