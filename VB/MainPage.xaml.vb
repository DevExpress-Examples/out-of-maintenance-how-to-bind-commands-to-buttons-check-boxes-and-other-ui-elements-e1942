Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports DevExpress.XtraRichEdit.Commands
Imports SilverlightApplication102.CommandUIBindings.Adapters

Namespace SilverlightApplication102
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			richEditControl.ApplyTemplate()

			Dim undoAdapter As New CommandButtonAdapter()
			undoAdapter.Button = btnUndo
			undoAdapter.Command = New UndoCommand(richEditControl)
			undoAdapter.RichEditControl = richEditControl

			Dim redoAdapter As New CommandButtonAdapter()
			redoAdapter.Button = btnRedo
			redoAdapter.Command = New RedoCommand(richEditControl)
			redoAdapter.RichEditControl = richEditControl

			Dim insertPictureAdapter As New CommandButtonAdapter()
			insertPictureAdapter.Command = New InsertPictureCommand(richEditControl)
			insertPictureAdapter.Button = btnInsertPicture
			insertPictureAdapter.RichEditControl = richEditControl

			Dim fontBoldAdapter As New CommandCheckBoxAdapter()
			fontBoldAdapter.Command = New ToggleFontBoldCommand(richEditControl)
			fontBoldAdapter.RichEditControl = richEditControl
			fontBoldAdapter.CheckBox = chkToggleFontBold

		End Sub

	End Class

End Namespace
