Imports DotNetNuke.Entities.Modules

''' <summary>
''' Provides strong typed access to settings used by module
''' </summary>
Public Class FavoritesSettings
    Private controller As ModuleController
    Private moduleId As Integer

    Public Sub New(ByVal moduleId As Integer)
        controller = New ModuleController()
        Me.moduleId = moduleId
    End Sub

    Protected Function ReadSetting(Of T)(ByVal settingName As String, ByVal defaultValue As T) As T
        Dim settings As Hashtable = controller.GetModuleSettings(Me.moduleId)

        Dim ret As T = Nothing

        If settings.ContainsKey(settingName) Then
            Dim tc As System.ComponentModel.TypeConverter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(T))
            Try
                ret = DirectCast(tc.ConvertFrom(settings(settingName)), T)
            Catch
                ret = defaultValue
            End Try
        Else
            ret = defaultValue
        End If

        Return ret
    End Function

    Protected Sub WriteSetting(ByVal settingName As String, ByVal value As String)
        controller.UpdateModuleSetting(Me.moduleId, settingName, value)
    End Sub

#Region "public properties"

    Public Property Header() As String
        Get
            Return ReadSetting(Of String)("Header", "<table cellpadding=""2"" cellspacing=""2"" border=""0"">")
        End Get
        Set(ByVal value As String)
            WriteSetting("Header", value)
        End Set
    End Property

    Public Property Body() As String
        Get
            Return ReadSetting(Of String)("Body", "<tr><td>[DELETEACTION]&nbsp;[LINK]</td></tr>")
        End Get
        Set(ByVal value As String)
            WriteSetting("Body", value)
        End Set
    End Property

    Public Property Footer() As String
        Get
            Return ReadSetting(Of String)("Footer", "</table>")
        End Get
        Set(ByVal value As String)
            WriteSetting("Footer", value)
        End Set
    End Property

    Public Property Empty() As String
        Get
            Return ReadSetting(Of String)("Empty", "No Favorites selected")
        End Get
        Set(ByVal value As String)
            WriteSetting("Empty", value)
        End Set
    End Property

    Public Property Unauthenticated() As String
        Get
            Return ReadSetting(Of String)("Unauthenticated", "")
        End Get
        Set(ByVal value As String)
            WriteSetting("Unauthenticated", value)
        End Set
    End Property

    Public Property UseFullUrl() As Boolean
        Get
            Return ReadSetting(Of Boolean)("UseFullUrl", "False")
        End Get
        Set(ByVal value As Boolean)
            WriteSetting("UseFullUrl", value)
        End Set
    End Property

    Public Property MaxTitleChars() As Integer
        Get
            Return ReadSetting(Of Integer)("MaxTitleChars", "25")
        End Get
        Set(ByVal value As Integer)
            WriteSetting("MaxTitleChars", value)
        End Set
    End Property

#End Region
End Class
