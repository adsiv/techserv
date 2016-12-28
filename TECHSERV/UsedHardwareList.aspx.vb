Public Class WebForm12
    Inherits System.Web.UI.Page

    Dim sqlAccess As New sqltechserv

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        sqlAccess.strTable = "tblUsedHardware"
        PopulateList()

    End Sub





    Private Sub PopulateList()

        Dim lstUsedCategories As New List(Of String)
        Dim intCategoryCount As Integer = 0

        Dim tblCategory As DataTable = New DataTable

        tblCategory.Columns.Add("CategoryType", Type.GetType("System.String"))
        tblCategory.Columns.Add("CategoryCount", Type.GetType("System.String"))

        'get data data

        'if table is empty, nothing to load.
        If sqlAccess.GetRecordCount = 0 Then
            lblSelectedItemType.Text = "No used hardware entered."
            Exit Sub
        End If

        Dim dtUsedHardware As DataTable

        dtUsedHardware = sqlAccess.ExecuteCustomReader("SELECT * FROM tblUsedHardware").Tables(0)

        'get list of all unique 'used_type' values
        For Each dr1 As DataRow In dtUsedHardware.Rows

            If Not lstUsedCategories.Contains(dr1("used_type").ToString) Then
                lstUsedCategories.Add(dr1("used_type").ToString)
            End If

        Next

        'count records of each 'used_type' values
        'add record to datatable with type and count
        For Each s As String In lstUsedCategories

            For Each dr2 As DataRow In dtUsedHardware.Rows
                If dr2("used_type").ToString = s Then
                    intCategoryCount = intCategoryCount + 1
                End If
            Next

            tblCategory.Rows.Add(s, "(" & intCategoryCount & ")")
            intCategoryCount = 0
        Next

        'bind it to grid view
        gvUsedCategoryList.DataSource = tblCategory
        gvUsedCategoryList.DataBind()

    End Sub






    Protected Sub gvUsedCategoryList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvUsedCategoryList.SelectedIndexChanged


        Dim dt As DataTable
        Dim strSelectedCategory As String

        strSelectedCategory = gvUsedCategoryList.Rows(gvUsedCategoryList.SelectedIndex).Cells(0).Text.ToString

        dt = sqlAccess.ExecuteCustomReader("SELECT used_serial, used_price FROM tblUsedHardware WHERE used_type = '" & strSelectedCategory & "'").Tables(0)

        'get list of all unique 'used_type' values

        gvFilteredItems.DataSource = dt
        gvFilteredItems.DataBind()
        gvFilteredItems.SelectedIndex = -1
        lblSelectedItemDetails.Text = ""



    End Sub


    Protected Sub gvFilteredItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvFilteredItems.SelectedIndexChanged
        Dim ds As DataSet
        Dim dr As DataRow

        ds = sqlAccess.ExecuteCustomReader("SELECT * FROM " & sqlAccess.strTable & " WHERE used_serial = '" & gvFilteredItems.Rows(gvFilteredItems.SelectedIndex).Cells(0).Text.ToString & "'")

        dr = ds.Tables(0).Rows(0)

        lblSelectedItemDetails.Text = "<b>Item Type:</b> " & dr("used_type").ToString() & "<br>"
        lblSelectedItemDetails.Text &= "<b>Serial Number:</b> " & dr("used_serial").ToString() & "<br>"
        lblSelectedItemDetails.Text &= "<b>Price:</b> $" & dr("used_price").ToString() & "<br>"
        lblSelectedItemDetails.Text &= "<b>Description:</b><br>" & dr("used_description").ToString()



    End Sub

End Class