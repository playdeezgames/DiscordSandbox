<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Character"

    StartPage
        BackToListLink SubPath, "Character"

        Dim rs
        Set rs = ExecuteSelectCommand(conn,TABLE_CHARACTERS,Array(COLUMN_CHARACTER_ID,COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID),Array(COLUMN_CHARACTER_ID),Array(Request.QueryString(COLUMN_CHARACTER_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_ID, "Id", rs
                TextInputEdit COLUMN_CHARACTER_NAME, "Name", rs
                ComboBoxEdit COLUMN_CHARACTER_TYPE_ID, "Character Type", Conn, TABLE_CHARACTER_TYPES, COLUMN_CHARACTER_TYPE_NAME, rs
                ComboBoxEdit COLUMN_LOCATION_ID, "Location", Conn, TABLE_LOCATIONS, COLUMN_LOCATION_NAME, rs
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_CHARACTER_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm

        Server.Execute("/Character/Statistic/List.asp")
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
