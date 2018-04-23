using System;
using System.Windows.Controls;
using DevExpress.XtraRichEdit.Commands;
using SilverlightApplication102.CommandUIBindings.Adapters;

namespace SilverlightApplication102
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            richEditControl.ApplyTemplate();

            CommandButtonAdapter undoAdapter = new CommandButtonAdapter();
            undoAdapter.Button = btnUndo;
            undoAdapter.Command = new UndoCommand(richEditControl);
            undoAdapter.RichEditControl = richEditControl;

            CommandButtonAdapter redoAdapter = new CommandButtonAdapter();
            redoAdapter.Button = btnRedo;
            redoAdapter.Command = new RedoCommand(richEditControl);
            redoAdapter.RichEditControl = richEditControl;

            CommandButtonAdapter insertPictureAdapter = new CommandButtonAdapter();
            insertPictureAdapter.Command = new InsertPictureCommand(richEditControl);
            insertPictureAdapter.Button = btnInsertPicture;
            insertPictureAdapter.RichEditControl = richEditControl;

            CommandCheckBoxAdapter fontBoldAdapter = new CommandCheckBoxAdapter();
            fontBoldAdapter.Command = new ToggleFontBoldCommand(richEditControl);
            fontBoldAdapter.RichEditControl = richEditControl;
            fontBoldAdapter.CheckBox = chkToggleFontBold;    

        }

    }

}
