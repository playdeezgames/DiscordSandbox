<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Character/Statistic"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CHARACTER_STATISTIC_DETAILS, _
        Array( _
            COLUMN_CHARACTER_STATISTIC_ID, _
            COLUMN_CHARACTER_ID, _
            COLUMN_STATISTIC_VALUE, _
            COLUMN_MAXIMUM_VALUE, _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_CHARACTER_NAME, _
            COLUMN_STATISTIC_TYPE_NAME), _
        Array(COLUMN_CHARACTER_STATISTIC_ID), _
        Array(Request.QueryString(COLUMN_CHARACTER_STATISTIC_ID)))

    StartPage
        BackToEditLink "Character", "Character",COLUMN_CHARACTER_ID,rs
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_STATISTIC_ID, "Id", rs
                ReadonlyTextInput COLUMN_CHARACTER_NAME, "Character", rs
                ReadonlyTextInput COLUMN_STATISTIC_TYPE_NAME, "Statistic Type", rs
                TextInputEdit COLUMN_STATISTIC_VALUE, "Statistic Value", rs
                TextInputEdit COLUMN_MINIMUM_VALUE, "Minimum Value", rs
                TextInputEdit COLUMN_MAXIMUM_VALUE, "Maximum Value", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm "CharacterType/Statistic"
            HiddenInput COLUMN_CHARACTER_STATISTIC_ID, Request.QueryString
            HiddenInput COLUMN_CHARACTER_ID, rs
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
