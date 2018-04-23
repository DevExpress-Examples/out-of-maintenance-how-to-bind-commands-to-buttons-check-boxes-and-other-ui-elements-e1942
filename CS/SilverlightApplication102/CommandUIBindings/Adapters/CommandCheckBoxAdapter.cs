using System;
using DevExpress.Utils.Commands;
using DevExpress.AgEditors;
using DevExpress.XtraRichEdit;
using SilverlightApplication102.CommandUIBindings.UIState;

namespace SilverlightApplication102.CommandUIBindings.Adapters
{
    #region CommandCheckBoxAdapter
    public class CommandCheckBoxAdapter
    {
        Command command;
        RichEditControl control;
        CheckEdit checkBox;

        public CheckEdit CheckBox
        {
            get { return checkBox; }
            set
            {
                if (checkBox == value)
                    return;

                UnsubscribeCheckBoxEvents();
                checkBox = value;
                SubscribeCheckBoxEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        void SubscribeCheckBoxEvents()
        {
            if (checkBox == null)
                return;

            checkBox.EditValueChanged += OnEditValueChanged;
        }
        void UnsubscribeCheckBoxEvents()
        {
            if (checkBox == null)
                return;

            checkBox.EditValueChanged -= OnEditValueChanged;
        }
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
            if (checkBox == null)
                return;
            UnsubscribeCheckBoxEvents();
            try
            {
                Command command = CreateCommand();
                if (command != null)
                {
                    CommandCheckBoxUIState state = new CommandCheckBoxUIState(checkBox);
                    command.UpdateUIState(state);
                }
            }
            finally
            {
                SubscribeCheckBoxEvents();
            }
        }


        void OnEditValueChanged(object sender, DevExpress.AgEditors.EditValueChangedEventArgs e)
        {
            UnsubscribeCheckBoxEvents();
            try
            {
                Command command = CreateCommand();
                if (command != null)
                    command.Execute();
            }
            finally
            {
                SubscribeCheckBoxEvents();
            }
        }

        // You may override this method to create command
        protected virtual Command CreateCommand()
        {
            return command;
        }
    }
    #endregion
}
