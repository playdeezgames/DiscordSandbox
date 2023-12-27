﻿Imports Shouldly
Imports Xunit

Public Class CharacterModel_should
    <Fact>
    Sub have_name()
        Dim subject = CreateSubject()
        subject.Name.ShouldNotBeNull
    End Sub

    Private Shared Function CreateSubject() As ICharacterModel
        Const authorId As ULong = 0
        Dim worldModel As IWorldModel = New WorldModel
        Dim playerModel = worldModel.GetPlayer(authorId)
        playerModel.CreateCharacter()
        Return playerModel.Character
    End Function
End Class
