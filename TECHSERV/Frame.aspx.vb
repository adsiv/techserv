Public Class WebForm1
    Inherits System.Web.UI.Page

    Public strPageLoad As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            strPageLoad = "hardwaresetup/" & Request.QueryString.Item("loadpage") & ".htm"
        Catch ex As Exception

        End Try

    End Sub

End Class