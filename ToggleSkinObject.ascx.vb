Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace DNNStuff.Favorites
    Partial Class ToggleSkinObject
        Inherits DotNetNuke.UI.Skins.SkinObjectBase

        Private _cssClass As String = "CommandButton"
        Private _addMessage As String = Nothing
        Private _removeMessage As String = Nothing

        Public Property CssClass() As String
            Get
                Return _cssClass
            End Get
            Set(ByVal Value As String)
                _cssClass = Value
            End Set
        End Property
        Public Property AddMessage() As String
            Get
                If _addMessage Is Nothing Then
                    _addMessage = Localization.GetString("AddMessage", Services.Localization.Localization.GetResourceFile(Me, "ToggleSkinObject.ascx"))
                End If
                Return _addMessage.Replace("[IMAGEURL]", ResolveUrl("~/images"))
            End Get
            Set(ByVal Value As String)
                _addMessage = Value
            End Set
        End Property
        Public Property RemoveMessage() As String
            Get
                If _removeMessage Is Nothing Then
                    _removeMessage = Localization.GetString("RemoveMessage", Services.Localization.Localization.GetResourceFile(Me, "ToggleSkinObject.ascx"))
                End If
                Return _removeMessage.Replace("[IMAGEURL]", ResolveUrl("~/images"))
            End Get
            Set(ByVal Value As String)
                _removeMessage = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            With toggle
                .CssClass = _cssClass
                .RemoveMessage = _removeMessage
                .AddMessage = _addMessage
            End With
        End Sub
    End Class
End Namespace


