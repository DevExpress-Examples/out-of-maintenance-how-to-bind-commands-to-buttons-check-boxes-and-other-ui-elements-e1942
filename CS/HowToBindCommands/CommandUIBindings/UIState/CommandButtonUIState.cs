using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Utils.Commands;

namespace HowToBindCommands.CommandUIBindings.UIState
{
    #region #commandbuttonuistate
    public class CommandButtonUIState : ICommandUIState
    {
        readonly Button button;
        public CommandButtonUIState(Button button)
        {
            this.button = button;
        }
        #region ICommandUIState Members
        public bool Checked { get { return false; } set { } }

	    public object EditValue { get { return null; } set { } }

        public bool Enabled { get { return button.IsEnabled; } set { button.IsEnabled = value; } }
        public bool Visible
        {
            get { return button.Visibility != Visibility.Collapsed; }
            set
            {
                if (value)
                    button.Visibility = Visibility.Visible;
                else
                    button.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
    #endregion #commandbuttonuistate

}