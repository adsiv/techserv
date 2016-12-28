Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sqlAccess As New sqltechserv
        Dim lstCategoryList As New List(Of String)
        Dim strHardwareList As String = ""
        Dim intCategoryCount As Integer = 0
        Dim strMultiline As String = ""

        sqlAccess.strTable = "tblHardwareList"

        Dim dt As DataTable = sqlAccess.ExecuteCustomReader("SELECT * FROM tblHardwareList ORDER BY hardware_name ASC").Tables(0)

        lblCheckinList.Text = ""


        'create list of unique categories

        For Each dr As DataRow In dt.Rows
            If Not lstCategoryList.Contains(dr("hardware_category").ToString) Then lstCategoryList.Add(dr("hardware_category").ToString)
        Next

        For Each s As String In lstCategoryList

            intCategoryCount = intCategoryCount + 1

            strHardwareList &= "<span class=""Title"">" & s & "</span><br/>"

            For Each dr2 As DataRow In dt.Rows

                If dr2("hardware_category").ToString = s Then
                    strHardwareList &= "<table class=""tablehardwarelist""><tr><td>"
                    strHardwareList &= "<b>" & dr2("hardware_name").ToString & "</b></br>"
                    strHardwareList &= "<b>Interface:</b> " & dr2("hardware_interface").ToString & "</br>"
                    strHardwareList &= "<b>US Price:</b> $" & dr2("hardware_price_us").ToString & " / " & "<b>CAN Price:</b> $" & dr2("hardware_price_can").ToString & "</br>"

                    If dr2("hardware_additional_charges").ToString <> "" Then
                        strMultiline = "<b>Additional Charges:</b></br> " & dr2("hardware_additional_charges").ToString & "</br>"
                        strHardwareList &= strMultiline.Replace(vbCrLf, "</br>")
                    End If

                    If dr2("hardware_details").ToString <> "" Then
                        strMultiline = "<i>" & dr2("hardware_details").ToString & "</i></br>"
                        strHardwareList &= strMultiline.Replace(vbCrLf, "<br>")
                    End If

                    strHardwareList &= "</td></tr></table><br/>"

                End If

            Next


            'depending on category, append item to different column

            Select Case s
                Case "Attendance Tracking"
                    lblCheckinList.Text = strHardwareList
                    strHardwareList = ""
                Case "POS"
                    lblPOSList.Text = strHardwareList
                    strHardwareList = ""
                Case Else
                    lblOtherList.Text = strHardwareList
                    strHardwareList = ""
            End Select

        Next

    End Sub

End Class