using System;
using System.Windows.Controls;
using DevExpress.Utils.Commands;
using DevExpress.XtraRichEdit;
using HowToBindCommands.CommandUIBindings.UIState;

namespace HowToBindCommands.Adapters
{
    #region #commandbuttonadapter
    public class CommandButtonAdapter
    {
        Command command;
        RichEditControl control;
        Button button;

        public RichEditControl RichEditControl
        {
            get { return control; }
            set
            {
                if (control == value)
                    return;
                UnsubscribeControlEvents();
                this.control = value;
                SubscribeControlEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        public Command Command
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

        public Button Button
        {
            get { return button; }
            set
            {
                if (button == value)
                    return;

                UnsubscribeButtonEvents();
                button = value;
                SubscribeButtonEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        void SubscribeButtonEvents()
        {
            if (button == null)
                return;

            button.Click += OnClick;
        }
        void UnsubscribeButtonEvents()
        {
            if (button == null)
                return;

            button.Click -= OnClick;
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
            if (button == null)
                return;

            Command command = CreateCommand();
            if (command != null)
            {
                CommandButtonUIState state = new CommandButtonUIState(button);
                command.UpdateUIState(state);
            }
        }

        void OnClick(object sender, EventArgs e)
        {
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
    #endregion #commandbuttonadapter
}
