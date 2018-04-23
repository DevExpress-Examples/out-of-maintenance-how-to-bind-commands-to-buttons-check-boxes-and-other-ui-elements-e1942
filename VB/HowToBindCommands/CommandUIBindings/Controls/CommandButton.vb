Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports DevExpress.Utils.Commands
Imports HowToBindCommands.CommandUIBindings.UIState
Imports DevExpress.Xpf.RichEdit

Namespace HowToBindCommands.CommandUIBindings.Controls
	#Region "#commandbutton"
	Public Class CommandButton
		Inherits Button
		Private command_Renamed As Command
		Private control As RichEditControl

		Public Property RichEditControl() As RichEditControl
			Get
				Return control
			End Get
			Set(ByVal value As RichEditControl)
				If control Is value Then
					Return
				End If
				UnsubscribeControlEvents()
				control = value
				SubscribeControlEvents()
				OnUpdateUI(Me, EventArgs.Empty)
			End Set
		End Property
		Public Shadows Property Command() As Command
			Get
				Return command_Renamed
			End Get
			Set(ByVal value As Command)
				If command_Renamed Is value Then
					Return
				End If
				command_Renamed = value
				OnUpdateUI(Me, EventArgs.Empty)
			End Set
		End Property

		Private Sub SubscribeControlEvents()
			If control Is Nothing Then
				Return
			End If
			AddHandler control.UpdateUI, AddressOf OnUpdateUI
		End Sub
		Private Sub UnsubscribeControlEvents()
			If control Is Nothing Then
				Return
			End If
			RemoveHandler control.UpdateUI, AddressOf OnUpdateUI
		End Sub

		Private Sub OnUpdateUI(ByVal sender As Object, ByVal e As EventArgs)
			Dim command As Command = CreateCommand()
			If command IsNot Nothing Then
				Dim state As New CommandButtonUIState(Me)
				command.UpdateUIState(state)
			End If
		End Sub

		Protected Overrides Sub OnClick()
			MyBase.OnClick()
			Dim command As Command = CreateCommand()
			If command IsNot Nothing Then
				command.Execute()
			End If
		End Sub

		' You may override this method to create a command
		Protected Overridable Function CreateCommand() As Command
			Return command_Renamed
		End Function
	End Class
	#End Region ' #commandbutton
End Namespace
