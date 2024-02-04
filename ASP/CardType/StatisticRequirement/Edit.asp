<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardType/StatisticRequirement"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CARD_TYPE_STATISTIC_REQUIREMENT_DETAILS, _
        Array( _
            COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID, _
            COLUMN_CARD_TYPE_ID, _
            COLUMN_MAXIMUM_VALUE, _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_CARD_TYPE_NAME, _
            COLUMN_STATISTIC_TYPE_NAME), _
        Array(COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID), _
        Array(Request.QueryString(COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID)))

    StartPage
        BackToEditLink "CardType", "Card Type",COLUMN_CARD_TYPE_ID,rs
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID, "Id", rs
                ReadonlyTextInput COLUMN_CARD_TYPE_NAME, "Card Type", rs
                ReadonlyTextInput COLUMN_STATISTIC_TYPE_NAME, "Statistic Type", rs
                TextInputEdit COLUMN_MINIMUM_VALUE, "Minimum Value", rs
                TextInputEdit COLUMN_MAXIMUM_VALUE, "Maximum Value", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm SubPath
            HiddenInput COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID, Request.QueryString
            HiddenInput COLUMN_CARD_TYPE_ID, rs
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
    rs.close
    set rs = nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
