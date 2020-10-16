using SuperMemoAssistant.Interop.SuperMemo.Elements.Types;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Models;
using SuperMemoAssistant.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.SessionState;
using System.Windows;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.UI
{
  /// <summary>Collection of IElements in the drill</summary>
  public class ElementCollection : ObservableCollection<ElementViewModel>
  {
  }

  /// <summary>
  /// Interaction logic for FilterWdw.xaml
  /// </summary>
  public partial class FilterWdw : Window
  {

    public List<ElementViewModel> OriginalDrillQueue { get; private set; }
    private static FinalDrillFilterCfg Config => Svc<FinalDrillFilterPlugin>.Plugin.Config;
    public string Filter { get; set; } = Config.DefaultFilter;
    public bool IsClosed { get; set; } = false;

    public FilterWdw(List<ElementViewModel> elements)
    {
      elements.ThrowIfNullOrEmpty("Failed to create filter window because element list was null or empty");

      InitializeComponent();
      OriginalDrillQueue = elements;
      Closing += (s, e) => IsClosed = true;
      this.AddElements(elements);

      DataContext = this;
    }

    private void AddElements(List<ElementViewModel> cards)
    {
      ElementCollection _elements = (ElementCollection)this.Resources["elements"];
      _elements.Clear();
      foreach (var card in cards)
        _elements.Add(card);
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private List<string> ParseFilter(string filter)
    {
      var split = filter
        ?.Split(',')
        ?.Select(x => x.Trim())
        ?.ToList();

      return split ?? new List<string>();
    }

    private void CreateSubsetFile(object sender, RoutedEventArgs e)
    {

      var remaining = GetFilteredElements();
      List<int> elementIds = remaining
        ?.Select(x => x.Id)
        ?.ToList();

      if (elementIds.IsNullOrEmpty())
      {
        NotifyUserDrillQueueIsEmpty();
        return;
      }

      var writer = new FilteredDrillWriter(elementIds);
      var ret = writer.WriteDrillFile();
      if (ret)
        NotifyUserSuccess();
      else
        NotifyUserFailure();

    }

    private void NotifyUserFailure()
    {
      var msg = "There was an error writing the filtered subset file.";
      var title = "Error";
      MessageBox.Show(msg, title);
    }

    private void NotifyUserSuccess()
    {
      var msg = "Load the subset as the final drill:\n" +
                "1) Go to View -> Subsets.\n" +
                "2) Open the filtered_drills folder and open the most recent file.\n" +
                "3) Press Shift+F10 and select Tools -> Save Drill";
      var title = "Success";
      MessageBox.Show(msg, title);
    }

    private void NotifyUserDrillQueueIsEmpty()
    {
      var msg = "Failed to write the filtered final drill subset file because the filtered queue is empty.";
      var title = "Filtered final drill queue is empty";
      MessageBox.Show(msg, title);
    }

    private List<ElementViewModel> GetFilteredElements()
    {
      var filter = ParseFilter(FilterString.Text);
      return OriginalDrillQueue
        .Where(x => x.CategoryPath.Any(x => filter.Contains(x)))
        .ToList();
    }

    private void PreviewFilterBtnClick(object sender, RoutedEventArgs e)
    {
      var remaining = GetFilteredElements();
      AddElements(remaining);
    }

    private void ResetBtnClick(object sender, RoutedEventArgs e)
    {
      AddElements(OriginalDrillQueue);
    }
  }
}
