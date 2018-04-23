using System;
using System.Windows;
using DevExpress.Utils.Commands;
using DevExpress.Xpf.Editors;

namespace HowToBindCommands.CommandUIBindings.UIState
{
    #region CommandCheckBoxUIState
    public class CommandCheckBoxUIState : ICommandUIState
    {
        readonly CheckEdit checkBox;
        public CommandCheckBoxUIState(CheckEdit checkBox)
        {
            this.checkBox = checkBox;
        }
        #region ICommandUIState Members
        public bool Checked
        {
            get
            {
                if (checkBox.IsChecked.HasValue)
                    return checkBox.IsChecked.Value;
                return false;
            }
            set { checkBox.IsChecked = value; }
        }

        public bool Enabled { get { return checkBox.IsEnabled; } set { checkBox.IsEnabled = value; } }
        public bool Visible
        {
            get { return checkBox.Visibility != Visibility.Collapsed; }
            set
            {
                if (value)
                    checkBox.Visibility = Visibility.Visible;
                else
                    checkBox.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
    #endregion

}