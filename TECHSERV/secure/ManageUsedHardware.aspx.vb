Imports System.Xml

Public Class WebForm11
    Inherits System.Web.UI.Page

    Dim sqlAccess As New sqltechserv
    Public Shared intDeleteIndex As Integer = -1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sqlAccess.strTable = "tblUsedHardware"
        FillGrid()
    End Sub

    Private Sub FillItemType()

        ddlUsedItemType.Items.Clear()

        Dim ds As DataSet = sqlAccess.ExecuteCustomReader("SELECT * FROM tblHardwareList")
        Dim strItem As String

        ddlUsedItemType.Items.Add("Computer")

        For Each dr As DataRow In ds.Tables(0).Rows

            strItem = dr("hardware_name").ToString()

            If ddlUsedItemType.Items.FindByValue(strItem) Is Nothing Then ddlUsedItemType.Items.Add(strItem)

        Next

        ddlUsedItemType.Items.Add("Other")

    End Sub

    Private Sub FillGrid()
        'refresh grid with current data

        gvUsedItemList.DataSource = sqlAccess.ExecuteCustomReader("SELECT * FROM  tblUsedHardware")
        gvUsedItemList.DataBind()

    End Sub

    Protected Sub btnNewEntry_Click(sender As Object, e As EventArgs) Handles btnNewEntry.Click
        'hide/show relevant ui elements
        btnNewEntry.Visible = False
        pnlEditItem.Visible = True
        btnCancel.Visible = True
        btnItemAdd.Visible = True
        btnItemUpdate.Visible = False

        'clear any possible leftover data in relevant fields
        FillItemType()
        txtUsedItemSerialNumber.Text = ""
        txtUsedItemPrice.Text = ""
        txtUsedItemDescription.Text = ""

        'refresh grid to show no selection
        FillGrid()
        gvUsedItemList.SelectedIndex = -1

    End Sub

    Private Sub ClearBoxes()
        'reset current ui elements to blank state
        pnlEditItem.Visible = False
        lblDeleteMessage.Text = ""
        lblDeleteMessage.Visible = False

        btnNewEntry.Visible = True
        btnDelete.Visible = False
        btnItemAdd.Visible = False
        btnItemUpdate.Visible = False
        btnCancel.Visible = False

        txtUsedItemSerialNumber.Text = ""
        txtUsedItemPrice.Text = ""
        txtUsedItemDescription.Text = ""

    End Sub

    Private Sub gvUsedItemList_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvUsedItemList.RowDeleting

        gvUsedItemList.SelectedIndex = -1
        FillGrid()
        ClearBoxes()

        lblDeleteMessage.Text = "Are you sure you want to delete this entry?<br/><br/>" & gvUsedItemList.Rows(e.RowIndex).Cells(0).Text.ToString & "<br/>" & gvUsedItemList.Rows(e.RowIndex).Cells(1).Text.ToString & "<br/>" & gvUsedItemList.Rows(e.RowIndex).Cells(2).Text.ToString & "<br/>" & gvUsedItemList.Rows(e.RowIndex).Cells(3).Text.ToString & "<br/>"
        lblDeleteMessage.Visible = True
        btnNewEntry.Visible = False
        btnDelete.Visible = True
        btnCancel.Visible = True

        intDeleteIndex = gvUsedItemList.Rows(e.RowIndex).Cells(0).Text.ToString

    End Sub

    Protected Sub gvUsedItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvUsedItemList.SelectedIndexChanged

        ClearBoxes()
        FillGrid()
        FillItemType()

        btnNewEntry.Visible = False
        pnlEditItem.Visible = True
        btnItemAdd.Visible = False
        btnItemUpdate.Visible = True
        btnCancel.Visible = True


        Dim ds As DataSet = sqlAccess.ExecuteCustomReader("SELECT * FROM tblUsedHardware WHERE ID = " & gvUsedItemList.Rows(gvUsedItemList.SelectedIndex).Cells(0).Text.ToString())

        ddlUsedItemType.SelectedValue = ds.Tables(0).Rows(0)("used_type").ToString()
        txtUsedItemSerialNumber.Text = ds.Tables(0).Rows(0)("used_serial").ToString()
        txtUsedItemPrice.Text = ds.Tables(0).Rows(0)("used_price").ToString()
        txtUsedItemDescription.Text = ds.Tables(0).Rows(0)("used_description").ToString()


    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearBoxes()
        gvUsedItemList.SelectedIndex = -1
        FillGrid()
        FillItemType()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        sqlAccess.DeleteRecord(intDeleteIndex)

        ClearBoxes()
        FillGrid()
        FillItemType()
    End Sub

    Protected Sub btnItemUpdate_Click(sender As Object, e As EventArgs) Handles btnItemUpdate.Click

        sqlAccess.UpdateUsedHardware(gvUsedItemList.Rows(gvUsedItemList.SelectedIndex).Cells(0).Text.ToString, ddlUsedItemType.SelectedItem.ToString, txtUsedItemSerialNumber.Text, txtUsedItemPrice.Text, txtUsedItemDescription.Text)

        FillGrid()
        gvUsedItemList.SelectedIndex = -1
        ClearBoxes()
        FillItemType()
    End Sub

    Protected Sub btnItemAdd_Click(sender As Object, e As EventArgs) Handles btnItemAdd.Click

        sqlAccess.InsertUsedHardware(ddlUsedItemType.SelectedItem.ToString, txtUsedItemSerialNumber.Text, txtUsedItemPrice.Text, txtUsedItemDescription.Text)

        ClearBoxes()
        FillGrid()
        FillItemType()
    End Sub

End Class