Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports HowToBindCommands.Adapters
Imports DevExpress.XtraRichEdit.Commands
Imports HowToBindCommands.CommandUIBindings.Adapters

Namespace HowToBindCommands
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			richEditControl.ApplyTemplate()

			Dim undoAdapter As New CommandButtonAdapter()
			undoAdapter.Button = btnUndo
			undoAdapter.Command = New UndoCommand(richEditControl.RichControl)
			undoAdapter.RichEditControl = richEditControl.RichControl

			Dim redoAdapter As New CommandButtonAdapter()
			redoAdapter.Button = btnRedo
			redoAdapter.Command = New RedoCommand(richEditControl.RichControl)
			redoAdapter.RichEditControl = richEditControl.RichControl

			Dim insertPictureAdapter As New CommandButtonAdapter()
			insertPictureAdapter.Command = New InsertPictureCommand(richEditControl.RichControl)
			insertPictureAdapter.Button = btnInsertPicture
			insertPictureAdapter.RichEditControl = richEditControl.RichControl

			Dim fontBoldAdapter As New CommandCheckBoxAdapter()
			fontBoldAdapter.Command = New ToggleFontBoldCommand(richEditControl.RichControl)
			fontBoldAdapter.RichEditControl = richEditControl.RichControl
			fontBoldAdapter.CheckBox = chkToggleFontBold

		End Sub

	End Class

End Namespace
