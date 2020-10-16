using SuperMemoAssistant.Extensions;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Interfaces;
using SuperMemoAssistant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.UI
{
  /// <summary>
  /// Interaction logic for FilterWdw.xaml
  /// </summary>
  public partial class FilterWdw : Window
  {

    private FinalDrillFilterCfg Config => Svc<FinalDrillFilterPlugin>.Plugin.Config;
    public bool IsClosed { get; set; } = false;
    private readonly IDrillWriter DrillWriter;

    public FilterWdw(IDrillWriter writer)
    {
      writer.ThrowIfArgumentNull("Failed to create FilterWdw ");
      DrillWriter = writer;
      Closing += (s, e) => IsClosed = true;

      InitializeComponent();
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void CreateSubsetFile(object sender, RoutedEventArgs e)
    {
    }
  }
}
