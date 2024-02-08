<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/Location"
    StartPage
        BackToEditLink "EffectType", "Effect Type", COLUMN_EFFECT_TYPE_ID, Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID,Request.QueryString
            StartTable 
                ComboBoxAdd COLUMN_LOCATION_ID, "Location", Conn, TABLE_LOCATIONS, COLUMN_LOCATION_NAME
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
