Imports System
Imports DotNetNuke
Imports DotNetNuke.Common
Imports DotNetNuke.Services.Exceptions

Namespace DNNStuff.Favorites
    Partial Class ToggleViewOptions
        Inherits Entities.Modules.PortalModuleBase

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
#Region " Page Level"


        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Public Sub LoadSettings()
            Try
                If Not Page.IsPostBack Then
                    Dim options As New ToggleSettings(ModuleId)
                    txtAddMessage.Text = options.AddMessage
                    txtRemoveMessage.Text = options.RemoveMessage
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub UpdateSettings()
            Try
                Dim options As New ToggleSettings(ModuleId)

                ' update options
                With options
                    .AddMessage = txtAddMessage.Text
                    .RemoveMessage = txtRemoveMessage.Text
                End With

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region
    End Class

End Namespace
