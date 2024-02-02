<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "StatisticType"
    StartPage
        BackToListLink SubPath, "Statistic Type"

        StartInsertForm SubPath
            StartTable 
                TextInputAdd COLUMN_STATISTIC_TYPE_NAME, "Name"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
