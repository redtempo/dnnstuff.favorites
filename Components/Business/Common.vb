Imports DotNetNuke

Namespace DNNStuff.Favorites
    Public Class Common
        ' constants
        Public Const CompanyName As String = "DNNStuff"
        Public Const ProductName As String = "Favorites"
        Public Const CompanyUrl As String = "http://www.dnnstuff.com"
        Public Const TrialStyle As String = "display:block;visibility:visible;color:black;position:relative;left:0;top:0;margin:0;padding:0;font:1.0em;line-height:1;"

        ' standard menus
        Public Const ViewOptions As String = "ViewOptions"
        Public Const ToggleViewOptions As String = "ToggleViewOptions"

        ''' <summary>
        ''' TrialWarning - builds up the Trial warning inserted when using the Trial version of the module
        ''' </summary>
        Public Shared Function TrialWarning() As String

            Dim sb As New Text.StringBuilder
            sb.AppendFormat("<p>Thank you for evaluating <a style=""text-decoration:underline"" target=""_blank"" ")
            sb.AppendFormat("title=""{0}"" ", ProductName)
            sb.AppendFormat("href=""{0}/{2}.aspx?utm_source={1}&utm_medium=trial&utm_campaign={1}"">{2}</a> ", CompanyUrl, CompanyName, ProductName)
            sb.AppendFormat("If after your evaluation you wish to support great DotNetNuke software and obtain a licensed copy of all DNNStuff modules, ")
            sb.AppendFormat("please visit the store to <a style=""text-decoration:underline"" target=""_blank"" ")
            sb.AppendFormat("title=""{0}"" ", CompanyName)
            sb.AppendFormat("href=""{0}/store.aspx?utm_source={1}&utm_medium=trial&utm_campaign={2}", CompanyUrl, CompanyName, ProductName)
            sb.AppendFormat(""">purchase a membership</a>. Use discount code <strong>'TRIAL'</strong> at checkout for 10% ")
            sb.AppendFormat("off!</p><hr />")

            Return sb.ToString
        End Function

        ''' <summary>
        ''' AddTrialNotice - returns a control containing the trial warning
        ''' </summary>
        Public Shared Sub AddTrialNotice(ByVal ParentControl As Control)

            Dim ctrl As New HtmlControls.HtmlGenericControl("div")
            With ctrl
                .InnerHtml = TrialWarning()
                .Attributes.Add("style", Common.TrialStyle)
            End With

            ParentControl.Controls.Add(ctrl)

        End Sub

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
