<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardType"

    StartPage
        BackToListLink SubPath, "Card Type"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_CARD_TYPES, _
            Array(COLUMN_CARD_TYPE_ID,COLUMN_CARD_TYPE_NAME), _
            Array(COLUMN_CARD_TYPE_ID), _
            Array(Request.QueryString(COLUMN_CARD_TYPE_ID)))

        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CARD_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_CARD_TYPE_NAME, "Name", rs
                SubmitButton
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_CARD_TYPE_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
