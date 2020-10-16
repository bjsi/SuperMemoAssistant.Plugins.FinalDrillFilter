using Forge.Forms.Annotations;
using Newtonsoft.Json;
using SuperMemoAssistant.Services.UI.Configuration;
using SuperMemoAssistant.Sys.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter
{
  [Form(Mode = DefaultFields.None)]
  [Title("Dictionary Settings",
       IsVisible = "{Env DialogHostContext}")]
  [DialogAction("cancel",
      "Cancel",
      IsCancel = true)]
  [DialogAction("save",
      "Save",
      IsDefault = true,
      Validates = true)]
  public class FinalDrillFilterCfg : CfgBase<FinalDrillFilterCfg>, INotifyPropertyChangedEx
  {
    [Title("Final Drill Filter")]

    [Heading("By Jamesb | Experimental Learning")]

    [Heading("Features:")]
    [Text(@"- Filter the final drill based on the category path of items.")]

    [Heading("Default Filter Settings")]
    [Field(Name = "Default Filter")]
    public string DefaultFilter { get; set; }

    [JsonIgnore]
    public bool IsChanged { get; set; }

    public override string ToString()
    {
      return "Final Drill Filter Settings";
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
