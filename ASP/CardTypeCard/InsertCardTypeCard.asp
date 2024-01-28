<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
if request.form("CardState")=COLUMN_IN_DRAW_PILE then
    cmd.CommandText="INSERT INTO " & TABLE_CARDS & "(" & COLUMN_CARD_TYPE_ID & "," & COLUMN_CHARACTER_ID & "," & COLUMN_IN_DRAW_PILE & "," & COLUMN_IN_HAND & "," & COLUMN_IN_DISCARD_PILE & "," & COLUMN_DRAW_ORDER & ") VALUES (?,?,?,?,?,?);"
else
    cmd.CommandText="INSERT INTO " & TABLE_CARDS & "(" & COLUMN_CARD_TYPE_ID & "," & COLUMN_CHARACTER_ID & "," & COLUMN_IN_DRAW_PILE & "," & COLUMN_IN_HAND & "," & COLUMN_IN_DISCARD_PILE & ") VALUES (?,?,?,?,?);"
end if
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form(COLUMN_CARD_TYPE_ID)
cmd.Parameters(1).Value=Request.Form(COLUMN_CHARACTER_ID)
select case Request.Form("CardState")
case COLUMN_IN_DRAW_PILE
    cmd.Parameters(2).Value=True
    cmd.Parameters(3).Value=False
    cmd.Parameters(4).Value=False
    cmd.Parameters(5).Value=Request.Form(COLUMN_DRAW_ORDER)
case COLUMN_IN_HAND
    cmd.Parameters(2).Value=False
    cmd.Parameters(3).Value=True
    cmd.Parameters(4).Value=False
case COLUMN_IN_DISCARD_PILE
    cmd.Parameters(2).Value=False
    cmd.Parameters(3).Value=False
    cmd.Parameters(4).Value=True
end select
cmd.Execute()
Response.Redirect "/CardTypeCard/CardTypeCardList.asp?" & COLUMN_CARD_TYPE_ID & "=" & Request.Form(COLUMN_CARD_TYPE_ID)
Set cmd=nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
