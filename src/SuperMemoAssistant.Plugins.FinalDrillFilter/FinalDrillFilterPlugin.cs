using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;
using Anotar.Serilog;
using SuperMemoAssistant.Extensions;
using SuperMemoAssistant.Interop.SuperMemo.Elements.Types;
using SuperMemoAssistant.Plugins.FinalDrillFilter.FileIO.Drills;
using SuperMemoAssistant.Plugins.FinalDrillFilter.Helpers;
using SuperMemoAssistant.Plugins.FinalDrillFilter.UI;
using SuperMemoAssistant.Services;
using SuperMemoAssistant.Services.IO.HotKeys;
using SuperMemoAssistant.Services.IO.Keyboard;
using SuperMemoAssistant.Services.Sentry;
using SuperMemoAssistant.Services.UI.Configuration;
using SuperMemoAssistant.Sys.IO.Devices;

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
// Created On:   10/14/2020 10:00:40 PM
// Modified By:  james

#endregion




namespace SuperMemoAssistant.Plugins.FinalDrillFilter
{
  // ReSharper disable once UnusedMember.Global
  // ReSharper disable once ClassNeverInstantiated.Global
  [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
  public class FinalDrillFilterPlugin : SentrySMAPluginBase<FinalDrillFilterPlugin>
  {
    #region Constructors

    /// <inheritdoc />
    public FinalDrillFilterPlugin() : base("Enter your Sentry.io api key (strongly recommended)") { }

    #endregion




    #region Properties Impl - Public

    /// <inheritdoc />
    public override string Name => "FinalDrillFilter";

    /// <inheritdoc />
    public override bool HasSettings => true;

    /// <summary>Plugin's config</summary>
    public FinalDrillFilterCfg Config { get; private set; }

    /// <summary>Current filter window instance</summary>
    private FilterWdw CurrentInstance { get; set; }

    #endregion


    #region Methods Impl

    /// <inheritdoc />
    protected override void PluginInit()
    {
      LoadConfig();
      RegisterHotkeys();
    }

    private void RegisterHotkeys()
    {
      Svc.HotKeyManager.RegisterGlobal(
        "OpenFinalDrillFilter",
        "Opens the final drill filter window",
        HotKeyScopes.SMBrowser,
        new HotKey(Key.M, KeyModifiers.CtrlAltShift),
        OpenFinalDrillFilter
      );
    }

    [LogToErrorOnException]
    private void OpenFinalDrillFilter()
    {
      var ids = ReadDrillElementIds();
      if (ids.IsNullOrEmpty())
      {
        NotifyUserDrillIsEmpty();
        return;
      }

      var elements = GetDrillElements(ids);
      if (elements.IsNullOrEmpty())
      {
        string msg = "Failed to open final drill filter because there was an error converting element ids to IElement objects";
        MessageBox.Show(msg, "Error");
        LogTo.Warning(msg);
        return;
      }

      LaunchFinalDrillFilterWdw(elements);
    }

    private List<IElement> GetDrillElements(List<int> ids)
    {
      List<IElement> ret = new List<IElement>();
      foreach (var id in ids)
      {
        var element = Svc.SM.Registry.Element[id];
        ret.Add(element);
      }
      return ret;
    }

    /// <summary>Show a message box that the drill queue is empty</summary>
    private void NotifyUserDrillIsEmpty()
    {
      var msg = "Failed to open the Final Drill Filter window because the final drill queue is empty";
      var title = "Final Drill is Empty";
      MessageBox.Show(msg, title);
    }

    /// <summary>Read the list of drill item ids</summary>
    private List<int> ReadDrillElementIds()
    {
      var reader = new DrillReader();
      return reader.ReadFile();
    }

    /// <summary>Open the filter window if it is not already open</summary>
    private void LaunchFinalDrillFilterWdw(List<IElement> elements)
    {
      if (CurrentInstance != null && !CurrentInstance.IsClosed)
      {
        CurrentInstance.Activate();
        return;
      }

      Application.Current.Dispatcher.Invoke(() =>
      {
        var wdw = new FilterWdw(elements);
        wdw.ShowAndActivate();
      });
    }

    /// <inheritdoc />
    public override void ShowSettings()
    {
      ConfigurationWindow.ShowAndActivate(HotKeyManager.Instance, Config);
    }

    /// <summary>Set the plugin's config</summary>
    private void LoadConfig()
    {
      Config = Svc.Configuration.Load<FinalDrillFilterCfg>() ?? new FinalDrillFilterCfg();
    }

    #endregion


    #region Methods

    #endregion
  }
}
