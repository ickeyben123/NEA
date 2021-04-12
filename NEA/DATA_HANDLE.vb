' This handles the exporting/importing of a set of questions.
Class DATA_HANDLE

    Protected QUESTIONS As List(Of QUESTION)
    Protected Event QUESTION_LIST_CHANGE()

    Sub New()
        AddHandler QUESTION_LIST_CHANGE, AddressOf UPDATE_QUESTION_LIST
    End Sub

    Sub REMOVE(QUESTION_OBJECT As QUESTION)
        QUESTIONS.Remove(QUESTION_OBJECT)
        RaiseEvent QUESTION_LIST_CHANGE()
    End Sub

    Sub ADD(QUESTION_OBJECT As QUESTION)
        QUESTIONS.Add(QUESTION_OBJECT)
        RaiseEvent QUESTION_LIST_CHANGE()
    End Sub

    Sub UPDATE_QUESTION_LIST()

    End Sub

End Class
