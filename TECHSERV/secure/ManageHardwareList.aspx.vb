Public Class WebForm2
    Inherits System.Web.UI.Page

    Dim sqlAccess As New sqltechserv
    Public Shared intDeleteIndex As Integer = -1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        sqlAccess.strTable = "tblHardwareList"
        FillGrid()
    End Sub

    Private Sub FillGrid()

        gvItemList.DataSource = sqlAccess.GetAllRecords
        gvItemList.DataBind()
    End Sub

    Private Sub ClearBoxes()

        pnlEditItem.Visible = False
        lblDeleteMessage.Text = ""
        lblDeleteMessage.Visible = False

        btnStartNewItem.Visible = True
        btnDelete.Visible = False
        btnItemAdd.Visible = False
        btnItemUpdate.Visible = False
        btnCancel.Visible = False

        txtItemName.Text = ""
        txtItemUSPrice.Text = ""
        txtItemCANPrice.Text = ""
        txtItemInterface.Text = ""
        txtItemAdditionalCharges.Text = ""
        txtItemDetails.Text = ""
        ddlItemType.ClearSelection()
        ddlItemCategory.ClearSelection()

    End Sub

    Private Sub gvItemList_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvItemList.RowDeleting

        gvItemList.SelectedIndex = -1
        FillGrid()
        ClearBoxes()

        lblDeleteMessage.Text = ("Are you sure you want to delete <b>" & gvItemList.Rows(e.RowIndex).Cells(1).Text.ToString) & "</b>?<br/>"
        lblDeleteMessage.Visible = True
        btnStartNewItem.Visible = False
        btnDelete.Visible = True
        btnCancel.Visible = True

        intDeleteIndex = gvItemList.Rows(e.RowIndex).Cells(0).Text.ToString

    End Sub

    Protected Sub gvItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvItemList.SelectedIndexChanged

        FillGrid()
        ClearBoxes()

        btnStartNewItem.Visible = False
        pnlEditItem.Visible = True
        btnItemAdd.Visible = False
        btnItemUpdate.Visible = True
        btnCancel.Visible = True

        ddlItemType.Items.Clear()
        ddlItemType.Items.Add("Hardware")
        ddlItemType.Items.Add("Service")
        ddlItemType.Items.Add("Other")

        ddlItemCategory.Items.Clear()
        ddlItemCategory.Items.Add("Attendance Tracking")
        ddlItemCategory.Items.Add("POS")
        ddlItemCategory.Items.Add("Other")

        Dim i As Integer = gvItemList.Rows(gvItemList.SelectedIndex).Cells(0).Text.ToString

        txtItemName.Text = sqlAccess.GetSingleRecord(i, 1)
        txtItemUSPrice.Text = sqlAccess.GetSingleRecord(i, 2)
        txtItemCANPrice.Text = sqlAccess.GetSingleRecord(i, 3)
        txtItemInterface.Text = sqlAccess.GetSingleRecord(i, 4)
        txtItemAdditionalCharges.Text = sqlAccess.GetSingleRecord(i, 5)
        ddlItemType.Text = sqlAccess.GetSingleRecord(i, 6)
        ddlItemCategory.Text = sqlAccess.GetSingleRecord(i, 7)
        txtItemDetails.Text = sqlAccess.GetSingleRecord(i, 8)

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearBoxes()
        gvItemList.SelectedIndex = -1
        FillGrid()

    End Sub

    Protected Sub btnStartNewItem_Click(sender As Object, e As EventArgs) Handles btnStartNewItem.Click
        FillGrid()
        btnStartNewItem.Visible = False
        pnlEditItem.Visible = True
        btnCancel.Visible = True
        btnItemAdd.Visible = True
        btnItemUpdate.Visible = False

        ddlItemType.Items.Clear()
        ddlItemType.Items.Add("Hardware")
        ddlItemType.Items.Add("Service")
        ddlItemType.Items.Add("Other")

        ddlItemCategory.Items.Clear()
        ddlItemCategory.Items.Add("Attendance Tracking")
        ddlItemCategory.Items.Add("POS")
        ddlItemCategory.Items.Add("Other")

        txtItemName.Text = ""
        txtItemUSPrice.Text = ""
        txtItemCANPrice.Text = ""
        txtItemInterface.Text = ""
        txtItemAdditionalCharges.Text = ""
        txtItemDetails.Text = ""
        ddlItemType.ClearSelection()
        ddlItemCategory.ClearSelection()

        gvItemList.SelectedIndex = -1
        FillGrid()

    End Sub

    Protected Sub btnItemAdd_Click(sender As Object, e As EventArgs) Handles btnItemAdd.Click

        sqlAccess.InsertHardware(txtItemName.Text, txtItemUSPrice.Text, txtItemCANPrice.Text, txtItemInterface.Text, txtItemAdditionalCharges.Text, ddlItemType.SelectedItem.Text, ddlItemCategory.SelectedItem.Text, txtItemDetails.Text)

        ClearBoxes()
        FillGrid()
    End Sub

    Protected Sub btnItemUpdate_Click(sender As Object, e As EventArgs) Handles btnItemUpdate.Click

        sqlAccess.UpdateHardware(gvItemList.Rows(gvItemList.SelectedIndex).Cells(0).Text.ToString, txtItemName.Text, txtItemUSPrice.Text, txtItemCANPrice.Text, txtItemInterface.Text, txtItemAdditionalCharges.Text, ddlItemType.SelectedItem.Text, ddlItemCategory.SelectedItem.Text, txtItemDetails.Text)

        FillGrid()
        gvItemList.SelectedIndex = -1
        ClearBoxes()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        sqlAccess.DeleteRecord(intDeleteIndex)

        ClearBoxes()
        FillGrid()
    End Sub

End Class