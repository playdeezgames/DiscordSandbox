<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType/Statistic"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CHARACTER_TYPE_STATISTIC_DETAILS, _
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID,COLUMN_CHARACTER_TYPE_ID,COLUMN_STATISTIC_VALUE,COLUMN_MAXIMUM_VALUE,COLUMN_MINIMUM_VALUE,COLUMN_CHARACTER_TYPE_NAME,COLUMN_STATISTIC_TYPE_NAME), _
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID), _
        Array(Request.QueryString(COLUMN_CHARACTER_TYPE_STATISTIC_ID)))

    StartPage
        BackToEditLink "CharacterType", "Character Type",COLUMN_CHARACTER_TYPE_ID,rs
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_STATISTIC_ID, "Id", rs
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_NAME, "Character Type", rs
                ReadonlyTextInput COLUMN_STATISTIC_TYPE_NAME, "Statistic Type", rs
                TextInputEdit COLUMN_STATISTIC_VALUE, "Statistic Value", rs
                TextInputEdit COLUMN_MINIMUM_VALUE, "Minimum Value", rs
                TextInputEdit COLUMN_MAXIMUM_VALUE, "Maximum Value", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm SubPath
            HiddenInput COLUMN_CHARACTER_TYPE_STATISTIC_ID, Request.QueryString
            HiddenInput COLUMN_CHARACTER_TYPE_ID, rs
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
