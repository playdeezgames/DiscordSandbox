<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Character/Statistic"
    StartPage
        BackToEditLink "Character","Character",COLUMN_CHARACTER_ID,Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_CHARACTER_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_STATISTIC_TYPE_ID, "Statistic Type", Conn, VIEW_CHARACTER_AVAILABLE_STATISTIC_TYPES, COLUMN_STATISTIC_TYPE_NAME, COLUMN_CHARACTER_ID, Request.QueryString
                TextInputAdd COLUMN_STATISTIC_VALUE, "Statistic Value"
                TextInputAdd COLUMN_MINIMUM_VALUE, "Minimum Value"
                TextInputAdd COLUMN_MAXIMUM_VALUE, "Maximum Value"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
