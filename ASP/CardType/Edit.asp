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
            Array( _
                COLUMN_CARD_TYPE_ID, _
                COLUMN_CARD_TYPE_NAME, _
                COLUMN_SELF_DESTRUCT, _
                COLUMN_CARD_LIMIT, _
                COLUMN_ALWAYS_AVAILABLE, _
                COLUMN_HAND_SIZE), _
            Array(COLUMN_CARD_TYPE_ID), _
            Array(Request.QueryString(COLUMN_CARD_TYPE_ID)))

        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CARD_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_CARD_TYPE_NAME, "Name", rs
                CheckboxInputEdit COLUMN_SELF_DESTRUCT, "Self Destruct", rs
                TextInputEdit COLUMN_CARD_LIMIT, "Limit", rs
                CheckboxInputEdit COLUMN_ALWAYS_AVAILABLE, "Always Available", rs
                CheckboxInputEdit COLUMN_HAND_SIZE, "Counts Towards Hand Size", rs
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

        Server.Execute("/CardType/Effect/List.asp")

        Server.Execute("/CardType/StatisticRequirement/List.asp")
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
