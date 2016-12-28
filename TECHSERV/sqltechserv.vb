Imports System.Data.SQLite
Imports System
Imports System.IO


Public Class sqltechserv
    Dim objConn As SQLiteConnection
    Dim objCmd As SQLiteCommand
    Dim strConnection As String = "Data Source=" & HttpContext.Current.Server.MapPath("~\secure\techserv.s3db")
    Public strTable As String




    Public Sub DeleteRecord(ByVal intIndex As Integer)

        ExecuteCustomNonQuery("Delete from " & strTable & " where ID ='" & intIndex & "'")

    End Sub




    Public Sub ExecuteCustomNonQuery(ByVal strCommand As String)
        'code to execute non query commands to sqlite database

        objConn = New SQLiteConnection(strConnection)
        objConn.Open()

        objCmd = objConn.CreateCommand
        objCmd.CommandText = strCommand

        objCmd.ExecuteNonQuery()

        objConn.Close()

    End Sub




    Public Function ExecuteCustomReader(ByVal strCommand As String) As DataSet
        Dim ds As New DataSet

        objConn = New SQLiteConnection(strConnection)
        objConn.Open()

        Using da As New SQLiteDataAdapter(strCommand, objConn)
            da.Fill(ds, strTable)


        End Using

        objConn.Close()

        Return ds

    End Function




    Public Function GetAllRecords() As DataSet
        'gets the entire table and returns as a dataset

        Return ExecuteCustomReader("select * from " & strTable)

    End Function




    ''' <summary>
    ''' Returns a string(). Specify # to return a single column instead.
    ''' </summary>
    ''' <param name="intIndex"></param>
    ''' <param name="intSpecificColumn">(Optional) Use to specify a single column. Returns as a single string value.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSingleRecord(ByVal intIndex As Integer, Optional ByVal intSpecificColumn As Integer = -1)

        Dim strRecord() As String = {"", "", "", "", "", "", "", "", ""}

        Dim ds As DataSet = ExecuteCustomReader("select * from " & strTable & " where ID='" & intIndex & "'")

        If intSpecificColumn > -1 Then
            Return ds.Tables(0).Rows(0).Item(intSpecificColumn).ToString
        Else

            Try
                For i As Integer = 0 To 9
                    strRecord(i) = ds.Tables(0).Rows(0).Item(i).ToString
                Next
            Catch ex As Exception

            End Try

            Return strRecord
        End If

    End Function





    Public Function GetRecordCount()
        'returns total number of records as integer

        Dim ds As DataSet = ExecuteCustomReader("select count(ID) from " & strTable)

        Return ds.Tables(0).Rows(0).Item(0).ToString()

    End Function




    Public Function IsUserAllowed(ByVal strUser As String, strPermission As String)

        Dim ds As New DataSet

        objConn = New SQLiteConnection(strConnection)
        objConn.Open()

        Using da As New SQLiteDataAdapter("SELECT " & strPermission & " FROM tblUserPermissions WHERE user_name = """ & strUser & """", objConn)
            da.Fill(ds, "tblUserPermissions")

        End Using

        objConn.Close()

        Return ds
    End Function




    ''' <summary>
    ''' Only works with tblNavigation. Use link_description, link_url and link_category to return ID.
    ''' </summary>
    ''' <param name="strDescription"></param>
    ''' <param name="strURL"></param>
    ''' <param name="strCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetURLIndex(ByVal strDescription As String, strURL As String, strCategory As String)
        'returns index as a integer

        Dim ds As DataSet = ExecuteCustomReader("select ID from " & strTable & " where link_description='" & strDescription & "' and link_url='" & strURL & "' and link_category='" & strCategory & "'")

        Return Convert.ToInt32(ds.Tables(0).Rows(0).Item(0).ToString())

    End Function




    ''' <summary>
    ''' Only works with tblNavigation.
    ''' </summary>
    ''' <param name="strDescription"></param>
    ''' <param name="strURL"></param>
    ''' <param name="strCategory"></param>
    ''' <remarks></remarks>
    Public Sub InsertURL(ByVal strDescription As String, strURL As String, strCategory As String)
        'NULL is used to autoincrement ID column
        ExecuteCustomNonQuery("Insert into " & strTable & " values (NULL,'" & strDescription.Replace("'", "''") & "','" & strURL.Replace("'", "''") & "','" & strCategory.Replace("'", "''") & "')")

    End Sub




    ''' <summary>
    ''' Only works with tblHardwareList.
    ''' </summary>
    ''' <param name="strName"></param>
    ''' <param name="strPriceUS"></param>
    ''' <param name="strPriceCAN"></param>
    ''' <param name="strInterface"></param>
    ''' <param name="strAdditionalCharges"></param>
    ''' <param name="strType"></param>
    ''' <param name="strCategory"></param>
    ''' <param name="strDetails"></param>
    ''' <remarks></remarks>
    Public Sub InsertHardware(ByVal strName As String, strPriceUS As String, strPriceCAN As String, _
                               strInterface As String, strAdditionalCharges As String, strType As String, _
                               strCategory As String, strDetails As String)

        ExecuteCustomNonQuery("Insert into " & strTable & " values (NULL,'" & _
                              strName.Replace("'", "''") & "','" & _
                              strPriceUS.Replace("'", "''") & "','" & _
                              strPriceCAN.Replace("'", "''") & "','" & _
                              strInterface.Replace("'", "''") & "','" & _
                              strAdditionalCharges.Replace("'", "''") & "','" & _
                              strType.Replace("'", "''") & "','" & _
                              strCategory.Replace("'", "''") & "','" & _
                              strDetails.Replace("'", "''") & "')")

    End Sub




    ''' <summary>
    ''' Only works with tblUsedHardware.
    ''' </summary>
    ''' <param name="strType"></param>
    ''' <param name="strSerialNumber"></param>
    ''' <param name="strPrice"></param>
    ''' <param name="strDescription"></param>
    ''' <remarks></remarks>
    Public Sub InsertUsedHardware(ByVal strType As String, strSerialNumber As String, strPrice As String, strDescription As String)

        ExecuteCustomNonQuery("Insert into " & strTable & " values (NULL,'" & _
                              strType.Replace("'", "''") & "','" & _
                              strSerialNumber.Replace("'", "''") & "','" & _
                              strPrice.Replace("'", "''") & "','" & _
                              strDescription.Replace("'", "''") & "')")

    End Sub



    ''' <summary>
    ''' Only works with tblNavigation.
    ''' </summary>
    ''' <param name="intIndex">ID to update.</param>
    ''' <param name="strNewDescription">Value to be saved to link_description.</param>
    ''' <param name="strNewURL">Value to be saved to link_url.</param>
    ''' <param name="strNewCategory">Value to be saved to link_category.</param>
    ''' <remarks></remarks>
    Public Sub UpdateURL(ByVal intIndex As Integer, strNewDescription As String, strNewURL As String, strNewCategory As String)

        ExecuteCustomNonQuery("Update " & strTable & " set link_description='" & strNewDescription.Replace("'", "''") & "', link_url='" & strNewURL.Replace("'", "''") & "', link_category='" & strNewCategory.Replace("'", "''") & "' where ID='" & intIndex & "'")

    End Sub




    ''' <summary>
    ''' Only works with tblHardwareList
    ''' </summary>
    ''' <param name="intIndex"></param>
    ''' <param name="strNewName"></param>
    ''' <param name="strNewPriceUS"></param>
    ''' <param name="strNewPriceCAN"></param>
    ''' <param name="strNewInterface"></param>
    ''' <param name="strNewAdditionalCharges"></param>
    ''' <param name="strNewType"></param>
    ''' <param name="strNewCategory"></param>
    ''' <param name="strNewDetails"></param>
    ''' <remarks></remarks>
    Public Sub UpdateHardware(ByVal intIndex As Integer, strNewName As String, strNewPriceUS As String, strNewPriceCAN As String, _
                               strNewInterface As String, strNewAdditionalCharges As String, strNewType As String, _
                               strNewCategory As String, strNewDetails As String)

        ExecuteCustomNonQuery("Update " & strTable & " set hardware_name='" & strNewName & _
                              "', hardware_price_us='" & strNewPriceUS.Replace("'", "''") & _
                              "', hardware_price_can='" & strNewPriceCAN.Replace("'", "''") & _
                              "', hardware_interface='" & strNewInterface.Replace("'", "''") & _
                              "', hardware_additional_charges='" & strNewAdditionalCharges.Replace("'", "''") & _
                              "', hardware_type='" & strNewType.Replace("'", "''") & _
                              "', hardware_category='" & strNewCategory.Replace("'", "''") & _
                              "', hardware_details='" & strNewDetails.Replace("'", "''") & _
                              "' where ID='" & intIndex & "'")
    End Sub




    ''' <summary>
    ''' Only works with tblUsedHardware.
    ''' </summary>
    ''' <param name="intIndex"></param>
    ''' <param name="strNewType"></param>
    ''' <param name="strNewSerial"></param>
    ''' <param name="strNewPrice"></param>
    ''' <param name="strNewDescription"></param>
    ''' <remarks></remarks>
    Public Sub UpdateUsedHardware(ByVal intIndex As Integer, strNewType As String, strNewSerial As String, strNewPrice As String, strNewDescription As String)

        ExecuteCustomNonQuery("Update " & strTable & " set used_type='" & strNewType & _
                              "', used_serial='" & strNewSerial.Replace("'", "''") & _
                              "', used_price='" & strNewPrice.Replace("'", "''") & _
                              "', used_description='" & strNewDescription.Replace("'", "''") & _
                              "' where ID='" & intIndex & "'")
    End Sub
End Class
