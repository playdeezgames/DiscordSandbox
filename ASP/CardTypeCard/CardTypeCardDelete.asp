<!--#include virtual="inc/Grimoire.asp"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardTypeCard/CardTypeCardEdit.asp?<%=COLUMN_CARD_ID%>=<%=Request.QueryString(COLUMN_CARD_ID)%>">Back to Card</a></p>
        <form action="/CardTypeCard/DeleteCardTypeCard.asp" method="POST">
            <input type="hidden" name="<%=COLUMN_CARD_ID%>" value="<%=Request.QueryString(COLUMN_CARD_ID)%>"/>
            <input type="hidden" name="<%=COLUMN_CARD_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>"/>
            <p>Confirm Delete? <input name="ConfirmDelete" type="checkbox" value="1"/></p>
            <input type="submit"/>
        </form>
    </body>
</html>
