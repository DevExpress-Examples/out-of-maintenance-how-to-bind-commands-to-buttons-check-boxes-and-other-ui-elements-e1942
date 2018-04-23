Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Utils.Commands

Namespace HowToBindCommands.CommandUIBindings.UIState
	#Region "#commandbuttonuistate"
	Public Class CommandButtonUIState
		Implements ICommandUIState
		Private ReadOnly button As Button
		Public Sub New(ByVal button As Button)
			Me.button = button
		End Sub
		#Region "ICommandUIState Members"
        Public Property Checked() As Boolean Implements ICommandUIState.Checked
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)
            End Set
        End Property
        Public Property Enabled() As Boolean Implements ICommandUIState.Enabled
            Get
                Return button.IsEnabled
            End Get
            Set(ByVal value As Boolean)
                button.IsEnabled = value
            End Set
        End Property
        Public Property Visible() As Boolean Implements ICommandUIState.Visible
            Get
                Return button.Visibility <> Visibility.Collapsed
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    button.Visibility = Visibility.Visible
                Else
                    button.Visibility = Visibility.Collapsed
                End If
            End Set
		End Property

		Public Overridable Property EditValue() As Object Implements ICommandUIState.EditValue
			Get
				Return Nothing
			End Get
			Set(ByVal value As Object)
			End Set
		End Property

		#End Region
	End Class
	#End Region ' #commandbuttonuistate

End Namespace