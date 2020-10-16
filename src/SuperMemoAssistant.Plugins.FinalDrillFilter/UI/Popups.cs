using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMemoAssistant.Plugins.FinalDrillFilter.UI
{
  public static class Popups
  {
    public static void Alert(string title, string msg)
    {
      MessageBox.Show(msg, title);
    }
  }
}
