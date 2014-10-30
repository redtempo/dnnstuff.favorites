'***************************************************************************/
'* DataController.vb
'*
'* COPYRIGHT (c) 2004 by DNNStuff
'* ALL RIGHTS RESERVED.
'*
'* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
'* TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
'* THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
'* CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
'* DEALINGS IN THE SOFTWARE.
'*************/
Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Xml
Imports DotNetNuke
Imports DotNetNuke.Common.Utilities
Imports Microsoft.ApplicationBlocks.Data

Namespace DNNStuff.Favorites

#Region " FavoriteInfo Class"

    Public Class FavoriteInfo

        ' collections
        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property FavoriteId() As Integer
        Public Property UserId As Integer
        Public Property TabId As Integer
        Public Property PageUrl As String
        Public Property PageTitle As String

#Region " Derived Properties"
        Public ReadOnly Property Tab As Entities.Tabs.TabInfo
            Get
                Dim tabController As New Entities.Tabs.TabController
                Return tabController.GetTab(TabId, Entities.Portals.PortalSettings.Current.PortalId, False)
            End Get
        End Property
#End Region

    End Class

#End Region

#Region " FavoriteController Class "

    Public Class FavoritesController
        Implements Entities.Modules.IPortable

#Region "Private Members"

        Private Shared dataProvider As DataProvider = DataProvider.Instance()

#End Region
        ' Favorites
        ''' <summary>
        ''' Adds a new Favorite record
        ''' </summary>
        ''' <returns>Identifier for the newly created object</returns>
        Public Shared Function AddFavorite(ByVal info As FavoriteInfo) As Integer
            Return CType(dataProvider.AddFavorite(info), Integer)
        End Function


        ''' <summary>
        ''' Updates a specified Favorite
        ''' </summary>
        Public Shared Sub UpdateFavorite(ByVal info As FavoriteInfo)
            dataProvider.UpdateFavorite(info)
        End Sub


        ''' <summary>
        ''' Deletes a specified Favorite
        ''' </summary>
        Public Shared Sub DeleteFavorite(ByVal FavoriteId As Integer)
            dataProvider.DeleteFavorite(FavoriteId)
        End Sub


        ''' <summary>
        ''' Retrieves the details of a specified Favorite
        ''' </summary>
        ''' <returns>FavoriteInfo object</returns>
        Public Shared Function GetFavorite(ByVal FavoriteId As Integer) As FavoriteInfo
            Return CType(CBO.FillObject(dataProvider.GetFavorite(FavoriteId), GetType(FavoriteInfo)), FavoriteInfo)
        End Function


        ''' <summary>
        ''' Retrieves the entire list of Favorites for the entire portal
        ''' </summary>
        ''' <returns>ArrayList of FavoriteInfo objects</returns>
        Public Shared Function GetFavorites(ByVal UserId As Integer, ByVal PortalId As Integer) As ArrayList
            Return CBO.FillCollection(dataProvider.GetFavorites(UserId, PortalId), GetType(FavoriteInfo))
        End Function

#Region " IPortable"
        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements DotNetNuke.Entities.Modules.IPortable.ExportModule
            Return ExportModule(ModuleID, Nothing)
        End Function

        Public Function ExportModule(ByVal ModuleID As Integer, ByVal ModuleMapping As System.Collections.Generic.Dictionary(Of Integer, Integer)) As String
            Dim strXML As New Text.StringBuilder()
            Dim settings As New XmlWriterSettings()
            settings.Indent = True
            settings.OmitXmlDeclaration = True

            Dim Writer As XmlWriter = XmlWriter.Create(strXML, settings)
            Writer.WriteStartElement("Favorites")

            Dim favSettings As New FavoritesSettings(ModuleID)
            With favSettings
                Writer.WriteElementString("Header", .Header)
                Writer.WriteElementString("Footer", .Footer)
                Writer.WriteElementString("Body", .Body)
                Writer.WriteElementString("UseFullUrl", .UseFullUrl.ToString)
                Writer.WriteElementString("MaxTitleChars", .MaxTitleChars.ToString)
            End With
            Writer.WriteEndElement()

            Writer.Close()

            Return strXML.ToString()
        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements DotNetNuke.Entities.Modules.IPortable.ImportModule

            Dim xml As XmlNode = DotNetNuke.Common.Globals.GetContent(Content, "Favorites")

            Dim favSettings As New FavoritesSettings(ModuleID)
            With favSettings
                .Header = xml.SelectSingleNode("Header").InnerText
                .Footer = xml.SelectSingleNode("Footer").InnerText
                .Body = xml.SelectSingleNode("Body").InnerText
                .UseFullUrl = Convert.ToBoolean(xml.SelectSingleNode("UseFullUrl").InnerText)
                .MaxTitleChars = Convert.ToInt32(xml.SelectSingleNode("MaxTitleChars").InnerText)
            End With

        End Sub
#End Region

    End Class

#End Region

End Namespace
