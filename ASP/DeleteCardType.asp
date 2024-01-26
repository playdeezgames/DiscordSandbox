<!--#include file="inc/AdoVbs.inc"-->
<!--#include file="inc/openconn.inc"-->
<%
if Request.Form("ConfirmDelete")=1 then
    Set cmd = Server.CreateObject("ADODB.Command")
    Set cmd.activeconnection=conn
    cmd.CommandType=adCmdText
    cmd.CommandText="DELETE FROM CardTypes WHERE CardTypeId=?;"
    cmd.Parameters.Refresh
    cmd.Parameters(0).Value=Request.Form("CardTypeId")
    cmd.Execute()
end if
Response.Redirect "CardTypeList.asp"
Set cmd=nothing
%>
<!--#include file="inc/closeconn.inc"-->
