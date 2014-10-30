Imports DotNetNuke.Entities.Modules

''' <summary>
''' Provides strong typed access to settings used by module
''' </summary>
Public Class ToggleSettings
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

    Public Property AddMessage() As String
        Get
            Return ReadSetting(Of String)("AddMessage", "<img border=0 align=absmiddle src='[IMAGEURL]/add.gif'>&nbsp;Add To Favs")
        End Get
        Set(ByVal value As String)
            WriteSetting("AddMessage", value)
        End Set
    End Property

    Public Property RemoveMessage() As String
        Get
            Return ReadSetting(Of String)("RemoveMessage", "<img border=0 align=absmiddle src='[IMAGEURL]/delete.gif'>&nbsp;Remove From Favs")
        End Get
        Set(ByVal value As String)
            WriteSetting("RemoveMessage", value)
        End Set
    End Property


#End Region
End Class
