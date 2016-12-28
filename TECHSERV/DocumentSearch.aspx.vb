Public Class WebForm15
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lblResults.Text = ""

        If txtClientNumber.Text = "" Then
            lblResults.Text = "Enter a client number."
            Exit Sub
        End If

        If txtAccountNumber.Text = "" Then
            lblResults.Text &= "Enter an account number."
            Exit Sub
        End If

        Try
            SearchDirectory(txtClientNumber.Text, txtAccountNumber.Text)
            SearchDirectory(Left(txtAccountNumber.Text, 3), txtAccountNumber.Text)
            SearchDirectory("emailedDocs", txtAccountNumber.Text)
        Catch ex As Exception

        End Try

        lblResults.Text &= "Done"
    End Sub

    Private Sub SearchDirectory(ByVal strFolderName As String, strAccountNumber As String)
        Dim ioDi As New IO.DirectoryInfo("\\fileserver\" & strFolderName & "\")
        Dim ioFileArray As IO.FileInfo() = ioDi.GetFiles()
        Dim ioFile As IO.FileInfo

        For Each ioFile In ioFileArray

            If ioFile.ToString.Contains(strAccountNumber) Then

                lblResults.Text &= ioFile.LastWriteTime.ToString & " <a href=""file://fileserver/" & strFolderName & "/" & ioFile.ToString & """ target=""_blank"">" & strFolderName & "/" & ioFile.ToString & "</a></br>"
            End If

        Next

    End Sub
End Class