<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/StatisticDelta"
    StartPage
        BackToEditLink "EffectType","Effect Type",COLUMN_EFFECT_TYPE_ID,Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_STATISTIC_TYPE_ID, "Statistic Type", Conn, VIEW_EFFECT_TYPE_AVAILABLE_DELTA_STATISTIC_TYPES, COLUMN_STATISTIC_TYPE_NAME, COLUMN_EFFECT_TYPE_ID, Request.QueryString
                TextInputAdd COLUMN_STATISTIC_VALUE, "Statistic Value"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
