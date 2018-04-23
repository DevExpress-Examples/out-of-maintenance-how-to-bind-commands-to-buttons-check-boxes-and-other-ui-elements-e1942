Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Utils.Commands
Imports DevExpress.AgEditors

Namespace SilverlightApplication102.CommandUIBindings.UIState
	#Region "CommandCheckBoxUIState"
	Public Class CommandCheckBoxUIState
		Implements ICommandUIState
		Private ReadOnly checkBox As CheckEdit
		Public Sub New(ByVal checkBox As CheckEdit)
			Me.checkBox = checkBox
		End Sub
		#Region "ICommandUIState Members"
        Public Property Checked() As Boolean Implements ICommandUIState.Checked
            Get
                If checkBox.IsChecked.HasValue Then
                    Return checkBox.IsChecked.Value
                End If
                Return False
            End Get
            Set(ByVal value As Boolean)
                checkBox.IsChecked = value
            End Set
        End Property

        Public Property Enabled() As Boolean Implements ICommandUIState.Enabled
            Get
                Return checkBox.IsEnabled
            End Get
            Set(ByVal value As Boolean)
                checkBox.IsEnabled = value
            End Set
        End Property
        Public Property Visible() As Boolean Implements ICommandUIState.Visible
            Get
                Return checkBox.Visibility <> Visibility.Collapsed
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    checkBox.Visibility = Visibility.Visible
                Else
                    checkBox.Visibility = Visibility.Collapsed
                End If
            End Set
        End Property
		#End Region
	End Class
	#End Region

End Namespace