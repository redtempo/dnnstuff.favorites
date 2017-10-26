Option Strict On
Option Explicit On 

Imports DotNetNuke
Imports DotNetNuke.Common
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Portals
Imports DotNetNuke.Services.Exceptions
Imports Dotnetnuke.Services.Localization
Imports System.Collections.Generic

Namespace DNNStuff.Favorites

    Partial Class ViewOptions
        Inherits Entities.Modules.PortalModuleBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            MyBase.HelpURL = "http://www.dnnstuff.com/"
        End Sub

#End Region

#Region " Page Level"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If DNNUtilities.SafeDNNVersion().Major = 5 Then
                    DNNUtilities.InjectCSS(Me.Page, ResolveUrl("Resources/Support/edit_5.css"))
                Else
                    DNNUtilities.InjectCSS(Me.Page, ResolveUrl("Resources/Support/edit.css"))
                End If
                Page.ClientScript.RegisterClientScriptInclude(Me.GetType, "yeti", ResolveUrl("resources/support/yetii-min.js"))

                If Page.IsPostBack = False Then
                    LoadSettings()
                End If

            Catch ex As Exception 'Module failed to load
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                ReturnToPage()
            Catch ex As Exception 'Module failed to load
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Try
                UpdateSettings()
                ReturnToPage()
            Catch ex As Exception 'Module failed to load
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub ReturnToPage()
            ' synchronize
            Entities.Modules.ModuleController.SynchronizeModule(ModuleId)

            ' Redirect back to the portal home page
            Response.Redirect(NavigateURL(), True)

        End Sub
#End Region

#Region " Settings"
        Private Sub UpdateSettings()
            Dim favSettings As New FavoritesSettings(ModuleId)
            With favSettings
                .Header = txtHeader.Text
                .Body = txtBody.Text
                .Footer = txtFooter.Text
                .Empty = txtEmpty.Text
                .Unauthenticated = txtUnathenticated.Text
                .UseFullUrl = chkUseFullUrl.Checked
                .MaxTitleChars = Convert.ToInt32(txtMaxTitleChars.Text)
            End With
        End Sub

        Private Sub LoadSettings()
            Dim favSettings As New FavoritesSettings(ModuleId)

            With favSettings
                txtHeader.Text = .Header
                txtBody.Text = .Body
                txtFooter.Text = .Footer
                txtEmpty.Text = .Empty
                txtUnathenticated.Text = .Unauthenticated
                chkUseFullUrl.Checked = .UseFullUrl
                txtMaxTitleChars.Text = .MaxTitleChars.ToString
            End With
        End Sub

#End Region

#Region " Validation"
#End Region

    End Class


End Namespace