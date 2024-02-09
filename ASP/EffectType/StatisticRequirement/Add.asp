<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/StatisticRequirement"
    StartPage
        BackToEditLink "EffectType","Effect Type",COLUMN_EFFECT_TYPE_ID,Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_STATISTIC_TYPE_ID, "Statistic Type", Conn, VIEW_EFFECT_TYPE_AVAILABLE_REQUIREMENT_STATISTIC_TYPES, COLUMN_STATISTIC_TYPE_NAME, COLUMN_EFFECT_TYPE_ID, Request.QueryString, False
                TextInputAdd COLUMN_MINIMUM_VALUE, "Minimum Value"
                TextInputAdd COLUMN_MAXIMUM_VALUE, "Maximum Value"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
