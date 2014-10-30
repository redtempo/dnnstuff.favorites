Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization


Namespace DNNStuff.Favorites
    Partial Class ToggleView
        Inherits DotNetNuke.Entities.Modules.PortalModuleBase
        Implements DotNetNuke.Entities.Modules.IActionable

        Private _ms As ToggleSettings
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            InitializeModule()
        End Sub

#End Region
#Region " Menu Actions"

        Public ReadOnly Property ModuleActions() As Entities.Modules.Actions.ModuleActionCollection Implements Entities.Modules.IActionable.ModuleActions
            Get
                Dim Actions As New Entities.Modules.Actions.ModuleActionCollection
                Actions.Add(GetNextActionID, Localization.GetString(Common.ToggleViewOptions, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl(Common.ToggleViewOptions), False, Security.SecurityAccessLevel.Edit, True, False)

                Return Actions
            End Get
        End Property

#End Region

        Private Sub InitializeModule()
            Try
                ' get settings
                _ms = New ToggleSettings(ModuleId)
            Catch ex As Exception
                DotNetNuke.Services.Exceptions.ProcessModuleLoadException(Me, ex, True)
            End Try
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                With lbToggle
                    .AddMessage = _ms.AddMessage
                    .RemoveMessage = _ms.RemoveMessage
                End With
            Else
                lbToggle.Visible = False
            End If
        End Sub

    End Class
End Namespace


