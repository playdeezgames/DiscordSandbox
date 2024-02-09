<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType"
    StartPage
        BackToListLink SubPath, "Effect Type"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_EFFECT_TYPES, _
            Array( _
                COLUMN_EFFECT_TYPE_ID, _
                COLUMN_EFFECT_TYPE_NAME, _
                COLUMN_LOCATION_TYPE_ID), _
            Array(COLUMN_EFFECT_TYPE_ID), _
            Array(Request.QueryString(COLUMN_EFFECT_TYPE_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_EFFECT_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_EFFECT_TYPE_NAME, "Name", rs
                ComboBoxEdit COLUMN_LOCATION_TYPE_ID, "Location Type", Conn, TABLE_LOCATION_TYPES, COLUMN_LOCATION_TYPE_NAME, rs, True
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm

        Server.Execute("/EffectType/StatisticDelta/List.asp")

        Server.Execute("/EffectType/CardTypeGenerator/List.asp")

        Server.Execute("/EffectType/Location/List.asp")
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
