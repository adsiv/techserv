
Public Class WebForm8
    Inherits System.Web.UI.Page

    Public Shared intDeleteIndex As Integer = -1

    Dim DB As New sqltechserv


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DB.strTable = "tblNavigation"
        FillGrid()


    End Sub

    Private Sub gvLinks_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvLinks.RowDeleting

        gvLinks.SelectedIndex = -1
        FillGrid()
        ClearBoxes()

        lblDeleteMessage.Text = ("Are you sure you want to delete <b>" & gvLinks.Rows(e.RowIndex).Cells(1).Text.ToString) & "</b>?<br/>"

        lblDeleteMessage.Visible = True
        btnStartNewLink.Visible = False
        btnDelete.Visible = True
        btnCancel.Visible = True


        intDeleteIndex = gvLinks.Rows(e.RowIndex).Cells(0).Text.ToString

    End Sub

    Private Sub FillGrid()

        gvLinks.DataSource = DB.ExecuteCustomReader("SELECT * FROM tblNavigation ORDER BY ID ASC")
        gvLinks.DataBind()

    End Sub

    Private Sub ClearBoxes()

        pnlEditLinks.Visible = False
        lblDeleteMessage.Text = ""
        lblDeleteMessage.Visible = False

        btnStartNewLink.Visible = True
        btnDelete.Visible = False
        btnLinkAdd.Visible = False
        btnLinkUpdate.Visible = False
        btnCancel.Visible = False

        txtLinkDescription.Text = ""
        txtLinkURL.Text = ""
        ddlLinkCategory.ClearSelection()

    End Sub

    Protected Sub gvLinks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvLinks.SelectedIndexChanged

        FillGrid()
        ClearBoxes()

        btnStartNewLink.Visible = False
        pnlEditLinks.Visible = True
        btnLinkAdd.Visible = False
        btnLinkUpdate.Visible = True
        btnCancel.Visible = True

        ddlLinkCategory.Items.Clear()
        ddlLinkCategory.Items.Add("TECHSERV")
        ddlLinkCategory.Items.Add("Developer Utilities")
        ddlLinkCategory.Items.Add("Links")
        ddlLinkCategory.Items.Add("Hardware Setup")
        ddlLinkCategory.Items.Add("Software Setup")
        ddlLinkCategory.Items.Add("Documents")
        ddlLinkCategory.Items.Add("Bench Forms")

        Dim i As Integer = gvLinks.Rows(gvLinks.SelectedIndex).Cells(0).Text.ToString

        txtLinkDescription.Text = DB.GetSingleRecord(i, 1)
        txtLinkURL.Text = DB.GetSingleRecord(i, 2)
        ddlLinkCategory.Text = DB.GetSingleRecord(i, 3)


    End Sub

    Protected Sub btnStartNewLink_Click(sender As Object, e As EventArgs) Handles btnStartNewLink.Click

        FillGrid()
        btnStartNewLink.Visible = False
        pnlEditLinks.Visible = True
        btnCancel.Visible = True
        btnLinkAdd.Visible = True
        btnLinkUpdate.Visible = False

        ddlLinkCategory.Items.Clear()
        ddlLinkCategory.Items.Add("TECHSERV")
        ddlLinkCategory.Items.Add("Developer Utilities")
        ddlLinkCategory.Items.Add("Links")
        ddlLinkCategory.Items.Add("Hardware Setup")
        ddlLinkCategory.Items.Add("Software Setup")
        ddlLinkCategory.Items.Add("Documents")
        ddlLinkCategory.Items.Add("Bench Forms")

        txtLinkDescription.Text = ""
        txtLinkURL.Text = ""
        ddlLinkCategory.ClearSelection()

        gvLinks.SelectedIndex = -1
        FillGrid()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        ClearBoxes()
        gvLinks.SelectedIndex = -1
        FillGrid()

    End Sub

    Protected Sub btnLinkUpdate_Click(sender As Object, e As EventArgs) Handles btnLinkUpdate.Click

        DB.UpdateURL(gvLinks.Rows(gvLinks.SelectedIndex).Cells(0).Text.ToString, txtLinkDescription.Text, txtLinkURL.Text, ddlLinkCategory.SelectedItem.Text)

        FillGrid()
        gvLinks.SelectedIndex = -1
        ClearBoxes()
    End Sub

    Protected Sub btnLinkAdd_Click(sender As Object, e As EventArgs) Handles btnLinkAdd.Click

        DB.InsertURL(txtLinkDescription.Text, txtLinkURL.Text, ddlLinkCategory.SelectedItem.ToString)

        ClearBoxes()
        FillGrid()

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        DB.DeleteRecord(intDeleteIndex)

        ClearBoxes()
        FillGrid()
    End Sub

End Class