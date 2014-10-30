Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace DNNStuff.Favorites
    Partial Public Class ToggleControl
        Inherits System.Web.UI.UserControl

#Region "Private Members"
        Private _cssClass As String = "CommandButton"
        Private _addMessage As String = Nothing
        Private _removeMessage As String = Nothing

#End Region
#Region "Public Members"
        Public ReadOnly Property PortalSettings() As DotNetNuke.Entities.Portals.PortalSettings
            Get
                Return CType(HttpContext.Current.Items("PortalSettings"), DotNetNuke.Entities.Portals.PortalSettings)
            End Get
        End Property

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
                Return _addMessage
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
                Return _removeMessage
            End Get
            Set(ByVal Value As String)
                _removeMessage = Value
            End Set
        End Property
#End Region

#Region "Event Handlers"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If Not Page.IsPostBack Then
                    If HttpContext.Current.User.Identity.IsAuthenticated Then
                        ' set styling
                        lbToggleMessage.CssClass = CssClass

                        ' grab list of fav's for this user
                        Try
                            Dim favs As ArrayList = FavoritesController.GetFavorites(Entities.Users.UserController.GetCurrentUserInfo.UserID, PortalSettings.PortalId)

                            Dim foundAsFav As Boolean = False
                            For Each fav As FavoriteInfo In favs
                                If fav.PageUrl = Request.Url.ToString Then
                                    lbToggleMessage.Text = ReplacePageTokens(RemoveMessage)
                                    lbToggleMessage.CommandName = "REMOVE"
                                    lbToggleMessage.CommandArgument = fav.FavoriteId
                                    foundAsFav = True
                                    Exit For
                                End If
                            Next
                            If Not foundAsFav Then
                                lbToggleMessage.Text = ReplacePageTokens(AddMessage)
                                lbToggleMessage.CommandName = "ADD"
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        lbToggleMessage.Visible = False
                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Function ReplacePageTokens(ByVal s As String) As String
            Dim tabPage As DotNetNuke.Framework.CDefault = DNNPage()
            Return s.Replace("[DESCRIPTION]", tabPage.Description).Replace("[TITLE]", tabPage.Title).Replace("[IMAGEURL]", ResolveUrl("~/images"))
        End Function

        Private Function DNNPage() As DotNetNuke.Framework.CDefault
            Dim pg As DotNetNuke.Framework.CDefault
            pg = CType(Me.Page, DotNetNuke.Framework.CDefault)
            Return pg
        End Function

        Private Function GetPageTitle() As String
            Dim tp As DotNetNuke.Framework.CDefault = DNNPage()
            If tp IsNot Nothing Then
                Return tp.Title
            End If
            Return ""
        End Function
#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub lbToggleMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbToggleMessage.Click

            Select Case lbToggleMessage.CommandName.ToUpper
                Case "REMOVE"
                    FavoritesController.DeleteFavorite(Int32.Parse(lbToggleMessage.CommandArgument))
                Case "ADD"
                    Dim fav As New FavoriteInfo
                    With fav
                        .UserId = Entities.Users.UserController.GetCurrentUserInfo.UserID
                        .TabId = PortalSettings.ActiveTab.TabID
                        .PageUrl = Request.Url.ToString
                        .PageTitle = GetTitle()
                    End With
                    FavoritesController.AddFavorite(fav)
            End Select
            RefreshPage()
        End Sub

        Private Function GetTitle() As String
            Dim title As String = ""
            If Request.Form("favorite_title") IsNot Nothing Then
                If Request.Form("favorite_title").Length = 0 Then
                    title = GetPageTitle()
                Else
                    title = Request.Form("favorite_title")
                End If
            Else
                title = GetPageTitle()
            End If
            Return title
        End Function
        Private Sub RefreshPage()
            Response.Redirect(Request.Url.ToString)
        End Sub
    End Class
End Namespace
