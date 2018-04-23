using System;
using System.Windows.Controls;
using DevExpress.Utils.Commands;
using DevExpress.XtraRichEdit;
using HowToBindCommands.CommandUIBindings.UIState;

namespace HowToBindCommands.CommandUIBindings.Controls
{
    #region #commandbutton
    public class CommandButton : Button
    {
        Command command;
        RichEditControl control;

        public RichEditControl RichEditControl
        {
            get { return control; }
            set
            {
                if (control == value)
                    return;
                UnsubscribeControlEvents();
                control = value;
                SubscribeControlEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        public new Command Command
        {
            get { return command; }
            set
            {
                if (command == value)
                    return;
                command = value;
                OnUpdateUI(this, EventArgs.Empty);
            }
        }

        void SubscribeControlEvents()
        {
            if (control == null)
                return;
            control.UpdateUI += OnUpdateUI;
        }
        void UnsubscribeControlEvents()
        {
            if (control == null)
                return;
            control.UpdateUI -= OnUpdateUI;
        }

        void OnUpdateUI(object sender, EventArgs e)
        {
            Command command = CreateCommand();
            if (command != null)
            {
                CommandButtonUIState state = new CommandButtonUIState(this);
                command.UpdateUIState(state);
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            Command command = CreateCommand();
            if (command != null)
                command.Execute();
        }

        // You may override this method to create a command
        protected virtual Command CreateCommand()
        {
            return command;
        }
    }
    #endregion #commandbutton
}
