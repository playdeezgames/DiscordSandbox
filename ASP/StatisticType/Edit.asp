<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "StatisticType"
    StartPage
        BackToListLink SubPath, "Statistic Type"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_STATISTIC_TYPES, _
            Array(COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_TYPE_NAME), _
            Array(COLUMN_STATISTIC_TYPE_ID), _
            Array(Request.QueryString(COLUMN_STATISTIC_TYPE_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_STATISTIC_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_STATISTIC_TYPE_NAME, "Name", rs
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_STATISTIC_TYPE_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
