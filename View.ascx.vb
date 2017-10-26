Imports DotNetNuke
Imports DotNetNuke.Services.Localization

Namespace DNNStuff.Favorites
    Partial Class View
        Inherits Entities.Modules.PortalModuleBase
        Implements Entities.Modules.IActionable

        Private _favSettings As FavoritesSettings

        Private ReadOnly Property FavSettings As FavoritesSettings
            Get
                If _favSettings Is Nothing Then
                    _favSettings = New FavoritesSettings(ModuleId)
                End If
                Return _favSettings
            End Get
        End Property

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Menu Actions"

        Public ReadOnly Property ModuleActions() As Entities.Modules.Actions.ModuleActionCollection _
            Implements Entities.Modules.IActionable.ModuleActions
            Get
                Dim menuActions As New Entities.Modules.Actions.ModuleActionCollection
                menuActions.Add(GetNextActionID, Localization.GetString(Common.ViewOptions, LocalResourceFile),
                                Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "",
                                EditUrl(Common.ViewOptions), False, Security.SecurityAccessLevel.Edit, True, False)

                Return menuActions
            End Get
        End Property

#End Region

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If HttpContext.Current.User.Identity.IsAuthenticated Then
                BindFavs()
            Else
                DisplayUnathenticatedMessage()
            End If
        End Sub

        Private Sub RefreshPage()
            Response.Redirect(Request.Url.ToString)
        End Sub

        Private Sub BindFavs()
            Dim favs As ArrayList = FavoritesController.GetFavorites(UserId, PortalId)

            dlUrls.DataSource = favs
            dlUrls.DataBind()

            If favs.Count = 0 Then
                DisplayEmptyMessage()
            End If
        End Sub

        Private Sub DisplayUnathenticatedMessage()
            phText.Controls.Add(New LiteralControl(FavSettings.Unauthenticated))
        End Sub

        Private Sub DisplayEmptyMessage()
            phText.Controls.Add(New LiteralControl(FavSettings.Empty))
        End Sub

        Private Function ReplaceFavoriteTokens(ByVal text As String, ByVal tokens As Hashtable) As String
            ' do generic replacements
            text = TokenReplacement.ReplaceGenericTokens(Me, text)

            ' do favorite specific replacements
            Dim replacer As New DNNStuff.Utilities.RegularExpression.TokenReplacement(tokens)
            replacer.ReplaceIfNotFound = False
            Return replacer.Replace(text)
        End Function

#Region " Data Presentation"

        Private Sub dlUrls_ItemCommand(ByVal source As Object,
                                       ByVal e As RepeaterCommandEventArgs) _
            Handles dlUrls.ItemCommand
            If e.CommandName = "Delete" Then
                FavoritesController.DeleteFavorite(Int32.Parse(e.CommandArgument.ToString))
                RefreshPage()
            End If
        End Sub

        Private Sub dlUrls_ItemDataBound(ByVal sender As Object,
                                         ByVal e As RepeaterItemEventArgs) _
            Handles dlUrls.ItemDataBound

            ' create tokens
            Dim tokens As Hashtable = StandardTokenList()

            ' header
            If e.Item.ItemType = ListItemType.Header Then
                e.Item.Controls.Add(ParseControl(ReplaceFavoriteTokens(FavSettings.Header, tokens)))
            End If

            ' footer
            If e.Item.ItemType = ListItemType.Footer Then
                e.Item.Controls.Add(ParseControl(ReplaceFavoriteTokens(FavSettings.Footer, tokens)))
            End If

            ' favorite item
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim fav As FavoriteInfo = CType(e.Item.DataItem, FavoriteInfo)

                Dim url As String = ""
                Dim title As String = ""
                Dim name As String = ""
                Dim safeTitle As String = ""

                If FavSettings.UseFullUrl Then
                    url = fav.PageUrl
                    title = fav.PageTitle
                    name = fav.PageTitle
                Else
                    url = fav.Tab.FullUrl
                    title = IIf(fav.Tab.Title.Length = 0, fav.Tab.TabName, fav.Tab.Title)
                    name = fav.Tab.TabName
                End If

                safeTitle = title
                If title.Length > FavSettings.MaxTitleChars Then
                    safeTitle = safeTitle.Substring(0, FavSettings.MaxTitleChars) & " ..."
                End If

                tokens.Add("TITLE", title)
                tokens.Add("DESCRIPTION", fav.Tab.Description)
                tokens.Add("NAME", name)
                tokens.Add("URL", url)
                tokens.Add("LINKNAME", String.Format("<a href='{0}' title='{1}'>{2}</a>", url, title, name))
                tokens.Add("LINKTITLE", String.Format("<a href='{0}' title='{1}'>{2}</a>", url, title, safeTitle))
                tokens.Add("LINK", tokens("LINKNAME"))
                tokens.Add("DELETEACTION",
                           String.Format(
                               "<asp:Linkbutton ID=""btnRemoveFavorite"" Title=""Remove"" Runat=""server"" ResourceKey=""btnRemoveFavorite"" CommandName=""Delete"" CommandArgument=""{0}"" ><img border=0 align=absmiddle src='{1}'></asp:LinkButton>",
                               fav.FavoriteId, ResolveUrl(Localization.GetString("DeleteImage.Text", LocalResourceFile))))

                e.Item.Controls.Add(ParseControl(ReplaceFavoriteTokens(FavSettings.Body, tokens)))
            End If
        End Sub

        Private Function StandardTokenList() As Hashtable
            Dim tokens As New Hashtable
            tokens.Add("IMAGEURL", ResolveUrl("~/images"))
            Return tokens

        End Function
#End Region

    End Class
End Namespace
