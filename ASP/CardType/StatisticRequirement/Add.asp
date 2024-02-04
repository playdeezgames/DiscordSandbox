<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardType/StatisticRequirement"
    StartPage
        BackToEditLink "CardType","Card Type",COLUMN_CARD_TYPE_ID,Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_CARD_TYPE_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_STATISTIC_TYPE_ID, "Statistic Type", Conn, VIEW_CARD_TYPE_AVAILABLE_REQUIREMENT_STATISTIC_TYPES, COLUMN_STATISTIC_TYPE_NAME, COLUMN_CARD_TYPE_ID, Request.QueryString
                TextInputAdd COLUMN_MINIMUM_VALUE, "Minimum Value"
                TextInputAdd COLUMN_MAXIMUM_VALUE, "Maximum Value"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
