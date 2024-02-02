<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "LocationType"
    StartPage
        BackToListLink SubPath, "Location Type"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_LOCATION_TYPES, _
            Array(COLUMN_LOCATION_TYPE_ID,COLUMN_LOCATION_TYPE_NAME), _
            Array(COLUMN_LOCATION_TYPE_ID), _
            Array(Request.QueryString(COLUMN_LOCATION_TYPE_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_LOCATION_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_LOCATION_TYPE_NAME, "Name", rs
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_LOCATION_TYPE_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
