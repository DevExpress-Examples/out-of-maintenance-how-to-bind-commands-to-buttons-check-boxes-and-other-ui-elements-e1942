using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using HowToBindCommands.Adapters;
using DevExpress.XtraRichEdit.Commands;
using HowToBindCommands.CommandUIBindings.Adapters;

namespace HowToBindCommands
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            richEditControl.ApplyTemplate();

            CommandButtonAdapter undoAdapter = new CommandButtonAdapter();
            undoAdapter.Button = btnUndo;
            undoAdapter.Command = new UndoCommand(richEditControl.RichControl);
            undoAdapter.RichEditControl = richEditControl.RichControl;

            CommandButtonAdapter redoAdapter = new CommandButtonAdapter();
            redoAdapter.Button = btnRedo;
            redoAdapter.Command = new RedoCommand(richEditControl.RichControl);
            redoAdapter.RichEditControl = richEditControl.RichControl;

            CommandButtonAdapter insertPictureAdapter = new CommandButtonAdapter();
            insertPictureAdapter.Command = new InsertPictureCommand(richEditControl.RichControl);
            insertPictureAdapter.Button = btnInsertPicture;
            insertPictureAdapter.RichEditControl = richEditControl.RichControl;

            CommandCheckBoxAdapter fontBoldAdapter = new CommandCheckBoxAdapter();
            fontBoldAdapter.Command = new ToggleFontBoldCommand(richEditControl.RichControl);
            fontBoldAdapter.RichEditControl = richEditControl.RichControl;
            fontBoldAdapter.CheckBox = chkToggleFontBold;

        }

    }

}
