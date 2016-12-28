Public Class WebForm22
    Inherits System.Web.UI.Page

    Dim DB As New sqltechserv

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Try
                FillBoxes()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub FillBoxes()
        Dim dt As New DataTable

        DB.strTable = "tblNotification"

        dt = DB.ExecuteCustomReader("SELECT * FROM tblNotification").Tables("tblNotification")

        lblNotificationText.Text = dt.Rows(0).Item("NotificationText").ToString '.Replace("<br>", vbCrLf)

        txtNotificationText.Text = lblNotificationText.Text

        If dt.Rows(0).Item("NotificationActive").ToString = "True" Then
            lblActive.Text = "Notification is active."
            chkActive.Checked = True
        Else
            lblActive.Text = "Notification is not active."
            chkActive.Checked = False
        End If
        chkActive.Checked = dt.Rows(0).Item("NotificationActive").ToString

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intChecked As Integer = 0

        If chkActive.Checked = True Then
            intChecked = 1
        Else
            intChecked = 0
        End If

        DB.ExecuteCustomNonQuery("UPDATE tblNotification SET NotificationText =""" & txtNotificationText.Text & """, NotificationActive=" & intChecked & ", NotificationPostedBy=""" & System.Environment.UserName.ToString & """")

        FillBoxes()

        pnlEditNotification.Visible = False
        pnlViewNotification.Visible = True

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        pnlEditNotification.Visible = False
        pnlViewNotification.Visible = True
    End Sub

    Protected Sub btnEditNotification_Click(sender As Object, e As EventArgs) Handles btnEditNotification.Click
        pnlEditNotification.Visible = True
        pnlViewNotification.Visible = False

    End Sub
End Class