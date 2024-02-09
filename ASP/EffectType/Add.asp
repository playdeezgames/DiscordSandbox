<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType"
    StartPage
        BackToListLink SubPath, "Effect Type"

        StartInsertForm SubPath
            StartTable 
                TextInputAdd COLUMN_EFFECT_TYPE_NAME, "Name"
                ComboBoxAdd COLUMN_LOCATION_TYPE_ID, "Location Type", Conn, TABLE_LOCATION_TYPES, COLUMN_LOCATION_TYPE_NAME, True
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
