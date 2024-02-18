<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Location"

    StartPage
        BackToListLink SubPath, "Location"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
        TABLE_LOCATIONS, _
        Array( _
            COLUMN_LOCATION_ID, _
            COLUMN_LOCATION_NAME, _
            COLUMN_LOCATION_TYPE_ID), _
        Array(COLUMN_LOCATION_ID), _
        Array(Request.QueryString(COLUMN_LOCATION_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_LOCATION_ID, "Id", rs
                TextInputEdit COLUMN_LOCATION_NAME, "Name", rs
                ComboBoxEdit COLUMN_LOCATION_TYPE_ID, "Location Type", Conn, TABLE_LOCATION_TYPES, COLUMN_LOCATION_TYPE_NAME, rs, False
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_LOCATION_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
