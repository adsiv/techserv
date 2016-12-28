Imports System.Xml

Public Class WebForm9
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CheckForNotification()
        PopulateLinks()

    End Sub


    Private Sub CheckForNotification()
        Dim db As New sqltechserv
        Dim dt As DataTable

        db.strTable = "tblNotification"

        Try
            dt = db.ExecuteCustomReader("SELECT * FROM tblNotification").Tables("tblNotification")

            If dt.Rows(0).Item("NotificationActive").ToString = "True" Then
                lblNotification.Text = dt.Rows(0).Item("NotificationText").ToString & "<br><br>Posted by " & dt.Rows(0).Item("NotificationPostedBy").ToString
                pnlNotification.Visible = True
            End If

        Catch ex As Exception

        End Try
        
    End Sub



    Private Sub PopulateLinks()
        Dim DB As New sqltechserv
        Dim dtCategories As DataTable
        Dim dtLinks As DataTable
        Dim strOutput As String = ""

        DB.strTable = "tblNavigation"

        dtCategories = DB.ExecuteCustomReader("SELECT * FROM (SELECT ID, link_category from tblNavigation ORDER BY ID DESC) GROUP BY link_category ORDER BY ID ASC").tables(0)

        Dim i As Integer = 0

        lblOutput.Text = "<table><tr style=""vertical-align: top"">"

        'for each distinct category...

        For Each dr1 As DataRow In dtCategories.Rows

            strOutput &= "<span class=""Title"">" & dr1("link_category").ToString & "</span><br/>"

            dtLinks = DB.ExecuteCustomReader("SELECT * FROM tblNavigation WHERE link_category =""" & dr1("link_category").ToString & """ ORDER BY link_description ASC").tables("tblNavigation")


            'create a link for every item with currently selected category

            For Each dr2 As DataRow In dtLinks.Rows

                If dr2("link_url").ToString.Contains("secure") Or dr2("link_url").ToString.Contains("Secure") Then
                    strOutput &= "<img width=""13px"" height=""13px"" src=""images/secure.png"" /> "
                Else
                    strOutput &= "<img width=""13px"" height=""13px"" src=""images/allowed.png"" /> "

                End If

                strOutput &= "<span class=""ContentText"">"

                strOutput &= "<a href=""" & dr2("link_url").ToString & """>" & dr2("link_description").ToString & "</a>"
                strOutput &= "<br/></span>"

            Next


            strOutput = strOutput ' & "<br/>"


            'determines if this is top of new column.  if not, will add a break between categories.

            If i > 0 Or i > (dtCategories.Rows.Count / 2) Then
                strOutput = "<br />" & strOutput
            End If


            'figures out which column to place links in

            If i < (dtCategories.Rows.Count / 2) - 1 Then

                lblList1.Text &= strOutput
            Else

                lblList2.Text &= strOutput
            End If

            i = i + 1

            If dr1("link_category").ToString = "Hardware Setup" Or dr1("link_category").ToString = "Documents" Then
                strOutput = "<td>" & strOutput
            ElseIf dr1("link_category").ToString = "Software Setup" Or dr1("link_category").ToString = "Bench Forms" Then
                strOutput = strOutput & "</td>"
            Else
                strOutput = "<td>" & strOutput & "</td>"
            End If

            lblOutput.Text &= strOutput

            strOutput = ""
        Next

        lblOutput.Text = lblOutput.Text & "</tr></table>"



    End Sub


End Class