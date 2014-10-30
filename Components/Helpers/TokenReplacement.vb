Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports DotNetNuke.Entities.Host

Namespace DNNStuff.Favorites

    Public Class TokenReplacement
        ' this module will provide compatibility between DNN versions

        Public Shared Function ReplaceGenericTokens(ByVal fav As DNNStuff.Favorites.View, ByVal text As String) As String
            Dim ret As String

            Dim objTokenReplace As New DotNetNuke.Services.Tokens.TokenReplace()
            objTokenReplace.ModuleId = fav.ModuleId
            ret = objTokenReplace.ReplaceEnvironmentTokens(text)

            objTokenReplace.User = fav.UserInfo
            If fav.UserInfo.Profile.PreferredLocale IsNot Nothing Then ' will be nothing for anonymous users
                objTokenReplace.Language = fav.UserInfo.Profile.PreferredLocale
            End If
            ret = objTokenReplace.ReplaceEnvironmentTokens(ret)

            Return ret
        End Function

    End Class
End Namespace
