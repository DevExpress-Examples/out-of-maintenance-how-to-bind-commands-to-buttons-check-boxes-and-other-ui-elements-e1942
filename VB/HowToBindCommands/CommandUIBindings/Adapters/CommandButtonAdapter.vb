Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports DevExpress.Utils.Commands
Imports DevExpress.XtraRichEdit
Imports HowToBindCommands.CommandUIBindings.UIState

Namespace HowToBindCommands.Adapters
	#Region "#commandbuttonadapter"
	Public Class CommandButtonAdapter
		Private command_Renamed As Command
		Private control As RichEditControl
		Private button_Renamed As Button

		Public Property RichEditControl() As RichEditControl
			Get
				Return control
			End Get
			Set(ByVal value As RichEditControl)
				If control Is value Then
					Return
				End If
				UnsubscribeControlEvents()
				Me.control = value
				SubscribeControlEvents()
				OnUpdateUI(Me, EventArgs.Empty)
			End Set
		End Property
		Public Property Command() As Command
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

		Public Property Button() As Button
			Get
				Return button_Renamed
			End Get
			Set(ByVal value As Button)
				If button_Renamed Is value Then
					Return
				End If

				UnsubscribeButtonEvents()
				button_Renamed = value
				SubscribeButtonEvents()
				OnUpdateUI(Me, EventArgs.Empty)
			End Set
		End Property
		Private Sub SubscribeButtonEvents()
			If button_Renamed Is Nothing Then
				Return
			End If

			AddHandler button_Renamed.Click, AddressOf OnClick
		End Sub
		Private Sub UnsubscribeButtonEvents()
			If button_Renamed Is Nothing Then
				Return
			End If

			RemoveHandler button_Renamed.Click, AddressOf OnClick
		End Sub
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
			If button_Renamed Is Nothing Then
				Return
			End If

			Dim command As Command = CreateCommand()
			If command IsNot Nothing Then
				Dim state As New CommandButtonUIState(button_Renamed)
				command.UpdateUIState(state)
			End If
		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
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
	#End Region ' #commandbuttonadapter
End Namespace
