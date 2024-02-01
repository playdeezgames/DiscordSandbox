<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardTypeGenerator"

    StartPage
    BackToListLink SubPath, "Card Type Generator"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_CARD_TYPE_GENERATORS, _
            Array(COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_GENERATOR_NAME), _
            Array(COLUMN_CARD_TYPE_GENERATOR_ID), _
            Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)))

        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CARD_TYPE_GENERATOR_ID, "Id", rs
                TextInputEdit COLUMN_CARD_TYPE_GENERATOR_NAME, "Name", rs
                SubmitButton
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_CARD_TYPE_GENERATOR_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm

        Server.Execute("/CardTypeGenerator/CardType/List.asp")
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
