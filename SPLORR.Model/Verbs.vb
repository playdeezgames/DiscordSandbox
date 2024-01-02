Friend Module Verbs
    Friend Const VERB_FORAGE = "forage"

    Friend Sub OnCharacterForage(character As ICharacterModel, outputter As Action(Of String))
        outputter($"{character.Name} forages....")
    End Sub
End Module
