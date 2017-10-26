Imports DotNetNuke

Namespace DNNStuff.Favorites
    Public Class Common
        ' constants
        Public Const CompanyName As String = "DNNStuff"
        Public Const ProductName As String = "Favorites"
        Public Const CompanyUrl As String = "http://www.dnnstuff.com"

        ' standard menus
        Public Const ViewOptions As String = "ViewOptions"
        Public Const ToggleViewOptions As String = "ToggleViewOptions"

        Public Shared Function DatabaseOwner() As String
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim _databaseOwner As String

            ' Read the configuration specific information for this provider
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)

            ' Read the attributes for this provider
            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") Then
                _databaseOwner = _databaseOwner.TrimEnd(".")
            End If
            Return _databaseOwner
        End Function

        Public Shared Function FullyQualifiedDatabaseObject() As String
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim _objectQualifier As String

            ' Read the configuration specific information for this provider
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)

            ' Read the attributes for this provider
            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            Return _objectQualifier & CompanyName & "_" & ProductName & "_"
        End Function
    End Class

End Namespace
