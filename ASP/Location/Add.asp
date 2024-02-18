<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Location"
    StartPage
        BackToListLink SubPath, "Location"
        StartInsertForm SubPath
            StartTable
                TextInputAdd COLUMN_LOCATION_NAME, "Name"
                ComboBoxAdd COLUMN_LOCATION_TYPE_ID, "Location Type", Conn, TABLE_LOCATION_TYPES, COLUMN_LOCATION_TYPE_NAME, False
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
