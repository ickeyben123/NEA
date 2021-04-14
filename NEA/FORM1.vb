' The Account Class contains the methods for authentication. 
' Events 'Login' and 'Logout' are to be connected to the respective buttons.

' Items are named first as their page, in form page_x.

' GLOBAL ENUMS

' Login enum for the login_mode of the account. 
' It is also used to state what mode the account is in (once logged in).
Imports System.Text.RegularExpressions
Public Enum LOGIN_MODE
    TEACHER
    STUDENT
End Enum

' This enum contains all the available questions

' The class for the form.
Public Class FORM1

    ' Main Sub
    Private Sub Main(sender As Object, e As EventArgs) Handles Me.Shown

        SHOW_MODE_SCREEN()


    End Sub

    ' EVENTS

    Dim WithEvents ACCOUNT_OBJECT As New ACCOUNT
    Dim WithEvents NOTIFICATIONS_OBJECT As New NOTIFICATIONS(Me)
    Dim DATA_HANDLER As DATA_HANDLE

    '/////////////////////////////
    ' General Form Subroutines
    '/////////////////////////////

    Public Function CLEAR_ALL()
        For Each cControl As Control In Controls  'Loops through all 'controls' in the form
            If TypeOf cControl Is GroupBox Then
                cControl.Visible = False
            End If
        Next
        Return True
    End Function

    Private Sub SHOW_LOGIN_SCREEN() Handles ACCOUNT_OBJECT.LOGIN_SCREEN
        CLEAR_ALL()
        LOGIN_GROUP.Visible = True
    End Sub

    Private Sub SHOW_MODE_SCREEN() Handles ACCOUNT_OBJECT.MODE_SCREEN
        CLEAR_ALL()
        MODE_GROUP.Visible = True
    End Sub

    Private Function TOGGLE_CERTAIN_SCREEN(SCREEN, SETTING)
        CLEAR_ALL()
        SCREEN.Visible = SETTING
        Return True
    End Function


    ' Account Login Subroutines

    Public Function UPPER_CASE(ByVal Match As Match) As String
        ' Used for .Replace regex to set a match upper case
        Return Match.ToString.ToUpper()
    End Function

    Public Sub ATTEMPT_LOGIN() Handles LOGIN_BUTTON.MouseClick ' This fires when the user clicks the login buttonm
        Dim result As Boolean = ACCOUNT_OBJECT.LOGIN(LOGIN_INPUT.Text) ' Calls login method in the account object.
        If result Then 'if it was correct
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Correct Login Info! Transferring to " & ACCOUNT_OBJECT.ACCOUNT_TYPE.ToString & " Screen", Color.Green)

            If ACCOUNT_OBJECT.ACCOUNT_TYPE = LOGIN_MODE.STUDENT Then

            Else
                TOGGLE_CERTAIN_SCREEN(TEACHER_GROUP, True)
                AddHandler TEACHER_CREATE_QUESTIONS.Click, Function(sender, e) SETUP_QUESTION_CREATOR()
                DATA_HANDLER = New DATA_HANDLE(Me)

                ' Update the question chooser with the current available enums.
                Dim ENUMS As New List(Of QUESTION_TYPE)(System.Enum.GetValues(GetType(QUESTION_TYPE)))
                ' Setup common events for the teacher.
                AddHandler Q_CONTROL_GROUP_ADD_QUESTION.Click, Function(sender, e) SETUP_QUESTION_CHOOSER()
                AddHandler QUESTION_CHOOSER_BACK.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)
                AddHandler QUESTION_CHOOSER_CREATE.Click, Function(sender, e) CREATE_QUESTION()
                AddHandler QUESTION_CREATION_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(QUESTION_CHOOSER, True)
                AddHandler QUESTION_CREATE.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)
                AddHandler Q_CONTROL_GROUP_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEACHER_GROUP, True)
                AddHandler Q_CONTROL_GROUP_EDIT.Click, Function(SENDER, E) EDIT()

                ' Update the question chooser listview.
                For Each ENUM_ITEM As QUESTION_TYPE In ENUMS
                    Dim MODIFIABLE As String = ENUM_ITEM.ToString.ToLower()
                    Dim SPACE As New Regex("_")
                    Dim CAPITALISE As New Regex("[ ]\w|(^\w)") ' Gets every first letter.
                    MODIFIABLE = SPACE.Replace(MODIFIABLE, " ")
                    MODIFIABLE = CAPITALISE.Replace(MODIFIABLE, New MatchEvaluator(AddressOf UPPER_CASE))
                    QUESTION_CHOOSER_LIST.Items.Add(MODIFIABLE)
                Next

            End If

        Else
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Wrong Login Info!", Color.Red)
        End If
    End Sub

    Public Sub MODE_CLICK(sender As Object, e As EventArgs) Handles MODE_STUDENT.MouseClick, MODE_TEACHER.MouseClick
        If sender Is MODE_STUDENT Then ' This means they chose to be a student
            ACCOUNT_OBJECT.SELECT_MODE(LOGIN_MODE.STUDENT)
        Else ' They chose teacher
            ACCOUNT_OBJECT.SELECT_MODE(LOGIN_MODE.TEACHER)
        End If
    End Sub


    '/////////////////////////////
    ' END
    '////////////////////////////


    '//////////////////////////////
    ' Teacher UI Subroutines.
    '/////////////////////////////

    Private Function SETUP_QUESTION_CREATOR()
        TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True) ' Shows the question creator screen.
        Return True
    End Function

    Private Function SETUP_QUESTION_CHOOSER()
        TOGGLE_CERTAIN_SCREEN(QUESTION_CHOOSER, True) ' Shows the question creator chooser screen.
        Return True
    End Function

    Private Function CREATE_QUESTION()
        If QUESTION_CHOOSER_LIST.SelectedItems.Count = 1 Then
            Dim NEW_QUESTION As New QUESTION(DATA_HANDLER)
            NEW_QUESTION.CHOSEN_QUESTION_TO_CREATE()
            TOGGLE_CERTAIN_SCREEN(QUESTION_INPUT1, True)
        End If
        Return True
    End Function

    Private Function EXIT_QUESTION_CREATOR()

    End Function

    Private Sub LISTBOX_MOUSE_UP(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles Q_CONTROL_GROUP_LISTBOX.MouseUp
        Dim CMS = New ContextMenuStrip
        Dim SELECTED_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedItem
        If Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then
            If E.Button = MouseButtons.Right Then
                If Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then
                    Dim ITEM1 = CMS.Items.Add("Edit " & SELECTED_ITEM.ToString)
                    ITEM1.Tag = 1
                    AddHandler ITEM1.Click, AddressOf EDIT
                    Dim ITEM2 = CMS.Items.Add("Delete " & SELECTED_ITEM.ToString)
                    ITEM2.Tag = 2
                    AddHandler ITEM2.Click, AddressOf DELETE
                End If
                Dim ITEM3 = CMS.Items.Add("Add new question")
                ITEM3.Tag = 3
                AddHandler ITEM3.Click, AddressOf SETUP_QUESTION_CHOOSER
                CMS.Show(Q_CONTROL_GROUP_LISTBOX, E.Location)
            Else
                Dim INDEX_OF_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedIndex
                Debug.WriteLine("lolol" & INDEX_OF_ITEM & SELECTED_ITEM.ToString)
                QUESTION_TITLE_NUMBER.Text = "QUESTION " & (INDEX_OF_ITEM + 1)
                QUESTION_TITLE_NAME.Text = DATA_HANDLER.RETURN_QUESTIONS()(INDEX_OF_ITEM).TYPE
            End If
        End If
    End Sub

    Private Function EDIT()
        If Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then ' Edit the selected question item.
            Dim INDEX_OF_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedIndex
            DATA_HANDLER.RETURN_QUESTIONS()(INDEX_OF_ITEM).EDIT_QUESTION(INDEX_OF_ITEM)
            TOGGLE_CERTAIN_SCREEN(QUESTION_INPUT1, True)
            Return True
        End If
        Return False
    End Function

    Private Sub DELETE()

    End Sub

    Private Function ADD()

        Return True
    End Function


    '/////////////////////////////
    ' END
    '////////////////////////////


End Class


' A custom class for notification creation. An optional addition that I made... because I like to waste time.
Class NOTIFICATIONS ' Handles notifications, has a max of 6 notifications at one time. 

    ' Possible improvement*
    '//Make the timer reset on each new notification.//

    Private WINDOW_WIDTH
    Private WINDOW_HEIGHT
    Private FORM As Form
    Private NOTIFICATIONS As New Stack(Of Label) ' Will be in the form { Label,Label }, it is used to hold the notifications.
    Private INTERNAL_REMOVAL As Boolean = False
    Private TIMER As System.Timers.Timer

    ' Window Resize Handling

    ' Delegate for control changing (due to thread differences this is required for invoking)
    Private Delegate Sub PROPERTY_CONTROL(Label As Label)
    Private Delegate Sub PROPERTY_CONTROL_LOCATION(Label As Label, POINT As Point)

    Private Sub E_RESIZE() 'Changes the WINDOW_WIDTH & WINDOW_HEIGHT whenever window is resized
        Debug.Print(Me.FORM.Height & Me.FORM.Width)
        Me.WINDOW_HEIGHT = FORM1.LOGIN_GROUP.Height ' The group has an offset, allowing the placing to be pleasing to the eye.
        Me.WINDOW_WIDTH = FORM1.LOGIN_GROUP.Width
    End Sub

    Sub New(ByRef FORM_INPUT As Form) ' This is sent a reference for the form, so it can access it.
        Me.FORM = FORM_INPUT ' Sets private variable
        AddHandler Me.FORM.ResizeEnd, AddressOf E_RESIZE 'Adds the resize handler to the E_RESIZE subroutine.
        Threading.Thread.Sleep(500)
        Me.WINDOW_HEIGHT = 690
        Me.WINDOW_WIDTH = 883 ' Initialises the variables
    End Sub

    ' Delegate methods used for thread communication.
    Private Sub REMOVE(INPUT As Label) ' Removes a control.
        INPUT.Dispose()
    End Sub

    Private Sub LOCATION(INPUT As Label, POINT As Point) ' Used to change controls position.
        INPUT.Location = POINT
    End Sub

    ' Notification System

    Private Sub ELAPSED()
        If Me.NOTIFICATIONS.Count = 0 Then ' If there are no more notifications.
            TIMER.Dispose()
            Me.INTERNAL_REMOVAL = False ' Disables the check variable so this sub can be initialised again.
            Return
        End If
        Dim REMOVED As Label = Me.NOTIFICATIONS.Pop() ' Gets the popped label so we can dispose of it.
        Dim REMOVE_DELEGATE As PROPERTY_CONTROL = New PROPERTY_CONTROL(AddressOf REMOVE) ' Creates a delegate that points to the remove subroutines
        REMOVED.Invoke(REMOVE_DELEGATE, New Object() {REMOVED}) 'Passes the delegate (ie a pointer to a function) with the paramter of the label. This removes the control within the controls thread. 
        Dim Count As Integer = 0 ' Used to stack the notifications.
        Dim POSITION_DELEGATE As PROPERTY_CONTROL_LOCATION = New PROPERTY_CONTROL_LOCATION(AddressOf LOCATION) ' Creates a delegate for position changing.
        For Each ILabel As Label In Me.NOTIFICATIONS 'Rearrange them
            Count += 1
            ILabel.Invoke(POSITION_DELEGATE, New Object() {REMOVED, New Point(Me.WINDOW_WIDTH - ILabel.Width, (Me.WINDOW_HEIGHT - ILabel.Height) - ILabel.Height * (Count))}) ' Sends both argurments with the delegate to run in the correct thread.
        Next
    End Sub

    Private Sub INTERNAL_NOTIFICATION() ' Intermediate subroutine for elapsed subroutines.
        Me.INTERNAL_REMOVAL = True ' Enables the check variable so this cannot be called again.
        TIMER = New System.Timers.Timer(3000) ' Creates a timer.
        TIMER.Enabled = True
        AddHandler TIMER.Elapsed, AddressOf ELAPSED ' Connects the event of the timer to the elapsed subroutines, making it run ever 3 seconds.
    End Sub


    Public Sub ADD_NOTIFICATION(Message As String, Colour As Color)
        If Me.NOTIFICATIONS.Count < 6 Then
            ' Create Label
            Dim Label As New Label
            Debug.Print(FORM1.Controls.Count)
            FORM1.Controls.Add(Label)
            Label.Text = Message
            Label.AutoSize = True
            Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label.Refresh()
            Label.Location = New System.Drawing.Point(Me.WINDOW_WIDTH - Label.Size.Width, (Me.WINDOW_HEIGHT - Label.Size.Height / 2) - Label.Height * (Me.NOTIFICATIONS.Count + 1)) ' Positions it in the corner.
            Label.TabIndex = 4
            Label.Anchor = System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Bottom ' Anchors it so that it moves when resized.
            Label.BringToFront() ' Brings it to the front so it can be seen.
            Label.ForeColor = Colour ' Sets the arguement colour.
            Me.NOTIFICATIONS.Push(Label)
            If Not Me.INTERNAL_REMOVAL Then 'Starts a thread to automatically remove notifications every 3 seconds.
                Me.INTERNAL_NOTIFICATION()
            End If
        End If
    End Sub

End Class

' Handles the logging in of an account.
Class ACCOUNT

    ' INITIATOR

    Public Sub New()

    End Sub

    ' EVENTS 

    ' Page Events
    ' Fire when the program should change page.

    Public Event LOGIN_SCREEN()
    Public Event MODE_SCREEN()

    ' Properties

    ' Account Properties
    Private Property LOGGING_MODE As LOGIN_MODE ' This determines whether the student is logging in as a teacher or a student.
    Private Property MODE As LOGIN_MODE ' This is the property for the accounts actual mode. This is changed when logging in.

    Private CODE As New Dictionary(Of LOGIN_MODE, String) From {{LOGIN_MODE.STUDENT, "student"}, {LOGIN_MODE.TEACHER, "teacher"}} ' Used for easy indexing of the login codes.

    ' Methods

    ' Account Methods

    ' Subroutines
    Public Sub SELECT_MODE(INPUT As LOGIN_MODE) ' The input must be in the Enum form. This selects the mode 
        Me.LOGGING_MODE = INPUT
        RaiseEvent LOGIN_SCREEN() ' Shows the login screen. 
    End Sub

    ' Functions
    Public Function LOGIN(INPUT As String)
        If Me.CODE.Item(Me.LOGGING_MODE) = INPUT Then 'They entered the correct code
            Me.MODE = Me.LOGGING_MODE 'Set the current mode the program is in.
            Return True
        End If
        Return False
    End Function

    Public Function ACCOUNT_TYPE()
        Return Me.MODE
    End Function

End Class

