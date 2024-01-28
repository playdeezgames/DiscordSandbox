<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardType/CardTypeList.asp">Back to Card Type List</a></p>
        <%
        Set cmd=server.CreateObject("adodb.command")
        Set cmd.activeconnection=conn
        cmd.CommandType=adCmdText
        cmd.CommandText="SELECT CardTypeId, CardTypeName, DeleteOnPlay FROM CardTypes WHERE CardTypeId=?;"
        cmd.Parameters.Refresh
        cmd.Parameters(0).Value=Request.QueryString("CardTypeId")
        set rs = cmd.Execute()
        rs.movefirst
        %>
        <form action="/CardType/UpdateCardType.asp" method="POST">
            <p>Card Type Id: <%=rs("CardTypeId")%><input name="<%=COLUMN_CARD_TYPE_ID%>" type="hidden" value="<%=rs(COLUMN_CARD_TYPE_ID)%>"/></p>
            <p>Card Type Name: <input name="<%=COLUMN_CARD_TYPE_NAME%>" type="text" size="100" maxlength="100" value="<%=rs(COLUMN_CARD_TYPE_NAME)%>"/></p>
            <p>Delete on Play? <input type="checkbox" name="<%=COLUMN_DELETE_ON_PLAY%>" value="1" <%
                if rs(COLUMN_DELETE_ON_PLAY) then 
                %> checked="checked" <%
                end if%>/></p>
            <p><input type="submit"/></p>
        </form>
        <%
        set rs=nothing  
        %>
    </body>
</html>
<!--#include virtual="inc/closeconn.inc"-->