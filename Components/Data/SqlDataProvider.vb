Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DotNetNuke

Namespace DNNStuff.Favorites

    Public Class SqlDataProvider
        Inherits DNNStuff.Favorites.DataProvider

#Region "Private Members"
        Private Const ProviderType As String = "data"

        Private _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration(ProviderType)
        Private _connectionString As String
        Private _providerPath As String
        Private _objectQualifier As String
        Private _databaseOwner As String

#End Region

#Region "Constructors"

        Public Sub New()

            ' Read the configuration specific information for this provider
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)

            ' Read the attributes for this provider
            _connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString()

            _providerPath = objProvider.Attributes("providerPath")

            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
                _databaseOwner += "."
            End If

        End Sub

        Public ReadOnly Property ConnectionString() As String
            Get
                Return _connectionString
            End Get
        End Property

        Public ReadOnly Property ProviderPath() As String
            Get
                Return _providerPath
            End Get
        End Property

        Public ReadOnly Property ObjectQualifier() As String
            Get
                Return _objectQualifier
            End Get
        End Property

        Public ReadOnly Property DatabaseOwner() As String
            Get
                Return _databaseOwner
            End Get
        End Property

        Public ReadOnly Property ObjectPrefix() As String
            Get
                Return DNNStuff.Favorites.Common.CompanyName & "_" & DNNStuff.Favorites.Common.ProductName & "_"
            End Get
        End Property
#End Region

#Region "Public Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function

        ' Favoritess
        Public Overrides Function AddFavorite(ByVal info As FavoriteInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & ObjectPrefix & "AddFavorite", info.UserId, info.TabId, info.PageUrl, info.PageTitle), Integer)
        End Function

        Public Overrides Sub UpdateFavorite(ByVal info As FavoriteInfo)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ObjectPrefix & "UpdateFavorite", info.FavoriteId, info.UserId, info.TabId, info.PageUrl, info.PageTitle)
        End Sub

        Public Overrides Sub DeleteFavorite(ByVal FavoriteId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ObjectPrefix & "DeleteFavorite", FavoriteId)
        End Sub

        Public Overrides Function GetFavorite(ByVal FavoriteId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier + ObjectPrefix & "GetFavorite", FavoriteId), IDataReader)
        End Function

        Public Overrides Function GetFavorites(ByVal UserId As Integer, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ObjectPrefix & "GetFavorites", UserId, PortalId), IDataReader)
        End Function
#End Region

    End Class

End Namespace
