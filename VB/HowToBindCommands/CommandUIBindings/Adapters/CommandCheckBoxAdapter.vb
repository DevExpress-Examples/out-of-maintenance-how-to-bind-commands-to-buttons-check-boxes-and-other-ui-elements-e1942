Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Utils.Commands
Imports DevExpress.Xpf.Editors
Imports HowToBindCommands.CommandUIBindings.UIState
Imports DevExpress.Xpf.RichEdit

Namespace HowToBindCommands.CommandUIBindings.Adapters
	#Region "CommandCheckBoxAdapter"
	Public Class CommandCheckBoxAdapter
		Private command_Renamed As Command
		Private control As RichEditControl
		Private checkBox_Renamed As CheckEdit

		Public Property CheckBox() As CheckEdit
			Get
				Return checkBox_Renamed
			End Get
			Set(ByVal value As CheckEdit)
				If checkBox_Renamed Is value Then
					Return
				End If

				UnsubscribeCheckBoxEvents()
				checkBox_Renamed = value
				SubscribeCheckBoxEvents()
				OnUpdateUI(Me, EventArgs.Empty)
			End Set
		End Property
		Private Sub SubscribeCheckBoxEvents()
			If checkBox_Renamed Is Nothing Then
				Return
			End If

			AddHandler checkBox_Renamed.EditValueChanged, AddressOf OnEditValueChanged
		End Sub
		Private Sub UnsubscribeCheckBoxEvents()
			If checkBox_Renamed Is Nothing Then
				Return
			End If

			RemoveHandler checkBox_Renamed.EditValueChanged, AddressOf OnEditValueChanged
		End Sub
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
			If checkBox_Renamed Is Nothing Then
				Return
			End If
			UnsubscribeCheckBoxEvents()
			Try
				Dim command As Command = CreateCommand()
				If command IsNot Nothing Then
					Dim state As New CommandCheckBoxUIState(checkBox_Renamed)
					command.UpdateUIState(state)
				End If
			Finally
				SubscribeCheckBoxEvents()
			End Try
		End Sub


		Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Editors.EditValueChangedEventArgs)
			UnsubscribeCheckBoxEvents()
			Try
				Dim command As Command = CreateCommand()
				If command IsNot Nothing Then
					command.Execute()
				End If
			Finally
				SubscribeCheckBoxEvents()
			End Try
		End Sub

		' You may override this method to create command
		Protected Overridable Function CreateCommand() As Command
			Return command_Renamed
		End Function
	End Class
	#End Region
End Namespace
