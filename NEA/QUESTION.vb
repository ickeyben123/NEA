' This is the class that is used to create questions.
' Handles the storage of answers and the custom interfaces it uses. 
Class QUESTION

    Protected TYPE As QUESTION_TYPE
    Protected ANSWER_MENU As GroupBox 'Every Question has an group box which contains the correct controls.
    Protected Properties As List(Of Array()) ' The properties of this group box, typically in form { {CONTROL_NAME,VALUE} } , this changes the text
    Protected ANSWER As String
    Protected ENABLED As Boolean = True ' Determines if editable.

    Public Overridable Sub SUBMIT_ANSWER(INPUT As String) 'Submits answer..
        Me.ANSWER = INPUT
    End Sub

    Public Sub MENU_VISIBILITY(INPUT As Boolean) ' Sets the menu visibility when needing to edit.
        Me.ANSWER_MENU.Visible = INPUT
    End Sub

    Public Sub SET_ANSWER_MENU() ' Sets the answer menu's (groupbox) properties.
        For Each IARRAY As Array In Properties ' Loop through the properties list
            If ANSWER_MENU.Controls.ContainsKey(IARRAY(0)) Then
                Dim LOCAL_CONTROL As Array = ANSWER_MENU.Controls.Find(IARRAY(0), True)
                For Each ICONTROL As Control In LOCAL_CONTROL
                    ICONTROL.Text = IARRAY(1)
                Next
            End If
        Next
    End Sub

End Class