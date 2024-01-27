<!--#include virtual="inc/Grimoire.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<%
if Request.Form("ConfirmDelete")=1 then
    Set cmd = Server.CreateObject("ADODB.Command")
    Set cmd.activeconnection=conn
    cmd.CommandType=adCmdText
    cmd.CommandText="DELETE FROM " & TABLE_CARDS & " WHERE " & COLUMN_CARD_ID & "=?;"
    cmd.Parameters.Refresh
    cmd.Parameters(0).Value=Request.Form(COLUMN_CARD_ID)
    cmd.Execute()
end if
Response.Redirect "/CardTypeCard/CardTypeCardList.asp?" & COLUMN_CARD_TYPE_ID & "=" & Request.Form(COLUMN_CARD_TYPE_ID)
Set cmd=nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
