<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Character"
    StartPage
        BackToListLink SubPath, "Character"
        StartInsertForm SubPath
            StartTable
                TextInputAdd COLUMN_CHARACTER_NAME, "Name"
                ComboBoxAdd COLUMN_CHARACTER_TYPE_ID, "Character Type", Conn, TABLE_CHARACTER_TYPES, COLUMN_CHARACTER_TYPE_NAME
                ComboBoxAdd COLUMN_LOCATION_ID, "Location", Conn, TABLE_LOCATIONS, COLUMN_LOCATION_NAME
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
