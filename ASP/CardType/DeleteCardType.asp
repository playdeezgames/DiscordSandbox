<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<%
if Request.Form("ConfirmDelete")=1 then
    Set cmd = Server.CreateObject("ADODB.Command")
    Set cmd.activeconnection=conn
    cmd.CommandType=adCmdText
    cmd.CommandText="DELETE FROM " & TABLE_CARD_TYPES & " WHERE " & COLUMN_CARD_TYPE_ID & "=?;"
    cmd.Parameters.Refresh
    cmd.Parameters(0).Value=Request.Form(COLUMN_CARD_TYPE_ID)
    cmd.Execute()
end if
Response.Redirect "/CardType/CardTypeList.asp"
Set cmd=nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
