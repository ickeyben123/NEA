<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FORM1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim TITLE As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.QUESTION_CHOOSER_LIST = New System.Windows.Forms.ListBox()
        Me.MODE_STUDENT = New System.Windows.Forms.Button()
        Me.MODE_GROUP = New System.Windows.Forms.GroupBox()
        Me.MODE_TEACHER = New System.Windows.Forms.Button()
        Me.MODE_TITLE = New System.Windows.Forms.Label()
        Me.LOGIN_GROUP = New System.Windows.Forms.GroupBox()
        Me.LOGIN_BUTTON = New System.Windows.Forms.Button()
        Me.LOGIN_INPUT = New System.Windows.Forms.TextBox()
        Me.Q_CONTROL_GROUP_LISTBOX = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TEACHER_GROUP = New System.Windows.Forms.GroupBox()
        Me.TEACHER_MARK_SUBMISSIONS = New System.Windows.Forms.Button()
        Me.TEACHER_CREATE_QUESTIONS = New System.Windows.Forms.Button()
        Me.Q_CONTROL_GROUP = New System.Windows.Forms.GroupBox()
        Me.Q_CONTROL_GROUP_ADD_QUESTION = New System.Windows.Forms.Button()
        Me.QUESTION_CHOOSER = New System.Windows.Forms.GroupBox()
        Me.QUESTION_CHOOSER_BACK = New System.Windows.Forms.Button()
        Me.QUESTION_CHOOSER_CREATE = New System.Windows.Forms.Button()
        Me.QUESTION_INPUT = New System.Windows.Forms.RichTextBox()
        Me.QUESTION_COUNT = New System.Windows.Forms.Label()
        Me.QUESTION_CREATE = New System.Windows.Forms.Button()
        Me.QUESTION_REMOVE = New System.Windows.Forms.Button()
        Me.QUESTION_CREATION_ANSWER = New System.Windows.Forms.RichTextBox()
        Me.QUESTION_INPUT1 = New System.Windows.Forms.GroupBox()
        Me.QUESTION_RECOMPUTE_ANSWER = New System.Windows.Forms.Button()
        Me.QUESTION_CREATION_EXIT = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.QUESTION_DISPLAY = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        TITLE = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Me.MODE_GROUP.SuspendLayout()
        Me.LOGIN_GROUP.SuspendLayout()
        Me.TEACHER_GROUP.SuspendLayout()
        Me.Q_CONTROL_GROUP.SuspendLayout()
        Me.QUESTION_CHOOSER.SuspendLayout()
        Me.QUESTION_INPUT1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(520, 495)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(131, 20)
        Label2.TabIndex = 2
        Label2.Text = "Input Code Here:"
        '
        'Label1
        '
        Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(432, 117)
        Label1.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(464, 82)
        Label1.TabIndex = 1
        Label1.Text = "Please Login"
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TITLE
        '
        TITLE.AutoSize = True
        TITLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TITLE.Location = New System.Drawing.Point(238, 198)
        TITLE.Name = "TITLE"
        TITLE.Size = New System.Drawing.Size(849, 82)
        TITLE.TabIndex = 2
        TITLE.Text = "What do you want to do?"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(34, 62)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(1080, 82)
        Label8.TabIndex = 0
        Label8.Text = "Available Questions Templates."
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(34, 62)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(353, 82)
        Label3.TabIndex = 0
        Label3.Text = "Question:"
        '
        'QUESTION_CHOOSER_LIST
        '
        Me.QUESTION_CHOOSER_LIST.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CHOOSER_LIST.FormattingEnabled = True
        Me.QUESTION_CHOOSER_LIST.ItemHeight = 32
        Me.QUESTION_CHOOSER_LIST.Location = New System.Drawing.Point(48, 165)
        Me.QUESTION_CHOOSER_LIST.Name = "QUESTION_CHOOSER_LIST"
        Me.QUESTION_CHOOSER_LIST.Size = New System.Drawing.Size(678, 676)
        Me.QUESTION_CHOOSER_LIST.TabIndex = 7
        '
        'MODE_STUDENT
        '
        Me.MODE_STUDENT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MODE_STUDENT.AutoSize = True
        Me.MODE_STUDENT.BackColor = System.Drawing.Color.SandyBrown
        Me.MODE_STUDENT.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MODE_STUDENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MODE_STUDENT.Location = New System.Drawing.Point(448, 325)
        Me.MODE_STUDENT.Name = "MODE_STUDENT"
        Me.MODE_STUDENT.Size = New System.Drawing.Size(426, 155)
        Me.MODE_STUDENT.TabIndex = 0
        Me.MODE_STUDENT.Text = "Student"
        Me.MODE_STUDENT.UseVisualStyleBackColor = False
        '
        'MODE_GROUP
        '
        Me.MODE_GROUP.Controls.Add(Me.MODE_TEACHER)
        Me.MODE_GROUP.Controls.Add(Me.MODE_STUDENT)
        Me.MODE_GROUP.Controls.Add(Me.MODE_TITLE)
        Me.MODE_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MODE_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.MODE_GROUP.Name = "MODE_GROUP"
        Me.MODE_GROUP.Size = New System.Drawing.Size(1324, 1062)
        Me.MODE_GROUP.TabIndex = 3
        Me.MODE_GROUP.TabStop = False
        Me.MODE_GROUP.Text = "Mode Selection"
        '
        'MODE_TEACHER
        '
        Me.MODE_TEACHER.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MODE_TEACHER.AutoSize = True
        Me.MODE_TEACHER.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MODE_TEACHER.Location = New System.Drawing.Point(448, 575)
        Me.MODE_TEACHER.Name = "MODE_TEACHER"
        Me.MODE_TEACHER.Size = New System.Drawing.Size(426, 155)
        Me.MODE_TEACHER.TabIndex = 1
        Me.MODE_TEACHER.Text = "Teacher"
        Me.MODE_TEACHER.UseVisualStyleBackColor = True
        '
        'MODE_TITLE
        '
        Me.MODE_TITLE.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MODE_TITLE.AutoSize = True
        Me.MODE_TITLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MODE_TITLE.Location = New System.Drawing.Point(405, 117)
        Me.MODE_TITLE.Name = "MODE_TITLE"
        Me.MODE_TITLE.Size = New System.Drawing.Size(514, 82)
        Me.MODE_TITLE.TabIndex = 2
        Me.MODE_TITLE.Text = "What are you?"
        '
        'LOGIN_GROUP
        '
        Me.LOGIN_GROUP.Controls.Add(Me.LOGIN_BUTTON)
        Me.LOGIN_GROUP.Controls.Add(Label2)
        Me.LOGIN_GROUP.Controls.Add(Me.LOGIN_INPUT)
        Me.LOGIN_GROUP.Controls.Add(Label1)
        Me.LOGIN_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LOGIN_GROUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LOGIN_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.LOGIN_GROUP.Name = "LOGIN_GROUP"
        Me.LOGIN_GROUP.Size = New System.Drawing.Size(1324, 1062)
        Me.LOGIN_GROUP.TabIndex = 4
        Me.LOGIN_GROUP.TabStop = False
        Me.LOGIN_GROUP.Text = "Login Screen"
        Me.LOGIN_GROUP.Visible = False
        '
        'LOGIN_BUTTON
        '
        Me.LOGIN_BUTTON.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LOGIN_BUTTON.Location = New System.Drawing.Point(525, 595)
        Me.LOGIN_BUTTON.Name = "LOGIN_BUTTON"
        Me.LOGIN_BUTTON.Size = New System.Drawing.Size(284, 69)
        Me.LOGIN_BUTTON.TabIndex = 3
        Me.LOGIN_BUTTON.Text = "Login"
        Me.LOGIN_BUTTON.UseVisualStyleBackColor = True
        '
        'LOGIN_INPUT
        '
        Me.LOGIN_INPUT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LOGIN_INPUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOGIN_INPUT.Location = New System.Drawing.Point(525, 522)
        Me.LOGIN_INPUT.MaxLength = 12
        Me.LOGIN_INPUT.Name = "LOGIN_INPUT"
        Me.LOGIN_INPUT.Size = New System.Drawing.Size(284, 39)
        Me.LOGIN_INPUT.TabIndex = 0
        Me.LOGIN_INPUT.UseSystemPasswordChar = True
        '
        'Q_CONTROL_GROUP_LISTBOX
        '
        Me.Q_CONTROL_GROUP_LISTBOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Q_CONTROL_GROUP_LISTBOX.FormattingEnabled = True
        Me.Q_CONTROL_GROUP_LISTBOX.ItemHeight = 25
        Me.Q_CONTROL_GROUP_LISTBOX.Location = New System.Drawing.Point(18, 46)
        Me.Q_CONTROL_GROUP_LISTBOX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Q_CONTROL_GROUP_LISTBOX.Name = "Q_CONTROL_GROUP_LISTBOX"
        Me.Q_CONTROL_GROUP_LISTBOX.Size = New System.Drawing.Size(775, 979)
        Me.Q_CONTROL_GROUP_LISTBOX.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(818, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(355, 61)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "QUESTION 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(822, 117)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(247, 29)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Algebra Simplification"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(828, 200)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(452, 83)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "EDIT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(828, 309)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(452, 83)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "REMOVE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Green
        Me.Button3.Location = New System.Drawing.Point(828, 942)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(462, 83)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "EXPORT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(831, 776)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(462, 126)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "CLEAR ALL"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TEACHER_GROUP
        '
        Me.TEACHER_GROUP.Controls.Add(TITLE)
        Me.TEACHER_GROUP.Controls.Add(Me.TEACHER_MARK_SUBMISSIONS)
        Me.TEACHER_GROUP.Controls.Add(Me.TEACHER_CREATE_QUESTIONS)
        Me.TEACHER_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TEACHER_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.TEACHER_GROUP.Name = "TEACHER_GROUP"
        Me.TEACHER_GROUP.Size = New System.Drawing.Size(1324, 1062)
        Me.TEACHER_GROUP.TabIndex = 5
        Me.TEACHER_GROUP.TabStop = False
        Me.TEACHER_GROUP.Text = "Main Menu"
        Me.TEACHER_GROUP.Visible = False
        '
        'TEACHER_MARK_SUBMISSIONS
        '
        Me.TEACHER_MARK_SUBMISSIONS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEACHER_MARK_SUBMISSIONS.Location = New System.Drawing.Point(831, 514)
        Me.TEACHER_MARK_SUBMISSIONS.Name = "TEACHER_MARK_SUBMISSIONS"
        Me.TEACHER_MARK_SUBMISSIONS.Size = New System.Drawing.Size(258, 231)
        Me.TEACHER_MARK_SUBMISSIONS.TabIndex = 1
        Me.TEACHER_MARK_SUBMISSIONS.Text = "Answer Submissions"
        Me.TEACHER_MARK_SUBMISSIONS.UseVisualStyleBackColor = True
        '
        'TEACHER_CREATE_QUESTIONS
        '
        Me.TEACHER_CREATE_QUESTIONS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEACHER_CREATE_QUESTIONS.Location = New System.Drawing.Point(210, 514)
        Me.TEACHER_CREATE_QUESTIONS.Name = "TEACHER_CREATE_QUESTIONS"
        Me.TEACHER_CREATE_QUESTIONS.Size = New System.Drawing.Size(258, 231)
        Me.TEACHER_CREATE_QUESTIONS.TabIndex = 0
        Me.TEACHER_CREATE_QUESTIONS.Text = "Create Questions"
        Me.TEACHER_CREATE_QUESTIONS.UseVisualStyleBackColor = True
        '
        'Q_CONTROL_GROUP
        '
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Q_CONTROL_GROUP_ADD_QUESTION)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Button4)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Button3)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Button2)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Button1)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Label5)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Label4)
        Me.Q_CONTROL_GROUP.Controls.Add(Me.Q_CONTROL_GROUP_LISTBOX)
        Me.Q_CONTROL_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Q_CONTROL_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.Q_CONTROL_GROUP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Q_CONTROL_GROUP.Name = "Q_CONTROL_GROUP"
        Me.Q_CONTROL_GROUP.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Q_CONTROL_GROUP.Size = New System.Drawing.Size(1324, 1062)
        Me.Q_CONTROL_GROUP.TabIndex = 8
        Me.Q_CONTROL_GROUP.TabStop = False
        Me.Q_CONTROL_GROUP.Text = "Question Control"
        '
        'Q_CONTROL_GROUP_ADD_QUESTION
        '
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Q_CONTROL_GROUP_ADD_QUESTION.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Location = New System.Drawing.Point(826, 423)
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Name = "Q_CONTROL_GROUP_ADD_QUESTION"
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Size = New System.Drawing.Size(452, 83)
        Me.Q_CONTROL_GROUP_ADD_QUESTION.TabIndex = 7
        Me.Q_CONTROL_GROUP_ADD_QUESTION.Text = "ADD NEW QUESTION"
        Me.Q_CONTROL_GROUP_ADD_QUESTION.UseVisualStyleBackColor = True
        '
        'QUESTION_CHOOSER
        '
        Me.QUESTION_CHOOSER.Controls.Add(Me.QUESTION_CHOOSER_BACK)
        Me.QUESTION_CHOOSER.Controls.Add(Me.QUESTION_CHOOSER_LIST)
        Me.QUESTION_CHOOSER.Controls.Add(Me.QUESTION_CHOOSER_CREATE)
        Me.QUESTION_CHOOSER.Controls.Add(Label8)
        Me.QUESTION_CHOOSER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QUESTION_CHOOSER.Location = New System.Drawing.Point(0, 0)
        Me.QUESTION_CHOOSER.Name = "QUESTION_CHOOSER"
        Me.QUESTION_CHOOSER.Size = New System.Drawing.Size(1324, 1062)
        Me.QUESTION_CHOOSER.TabIndex = 9
        Me.QUESTION_CHOOSER.TabStop = False
        Me.QUESTION_CHOOSER.Text = "Question Chooser"
        '
        'QUESTION_CHOOSER_BACK
        '
        Me.QUESTION_CHOOSER_BACK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_CHOOSER_BACK.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CHOOSER_BACK.ForeColor = System.Drawing.Color.Maroon
        Me.QUESTION_CHOOSER_BACK.Location = New System.Drawing.Point(1185, 970)
        Me.QUESTION_CHOOSER_BACK.Name = "QUESTION_CHOOSER_BACK"
        Me.QUESTION_CHOOSER_BACK.Size = New System.Drawing.Size(127, 80)
        Me.QUESTION_CHOOSER_BACK.TabIndex = 8
        Me.QUESTION_CHOOSER_BACK.Text = "Exit"
        Me.QUESTION_CHOOSER_BACK.UseVisualStyleBackColor = True
        '
        'QUESTION_CHOOSER_CREATE
        '
        Me.QUESTION_CHOOSER_CREATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_CHOOSER_CREATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CHOOSER_CREATE.ForeColor = System.Drawing.Color.Green
        Me.QUESTION_CHOOSER_CREATE.Location = New System.Drawing.Point(58, 937)
        Me.QUESTION_CHOOSER_CREATE.Name = "QUESTION_CHOOSER_CREATE"
        Me.QUESTION_CHOOSER_CREATE.Size = New System.Drawing.Size(410, 80)
        Me.QUESTION_CHOOSER_CREATE.TabIndex = 4
        Me.QUESTION_CHOOSER_CREATE.Text = "Create Question"
        Me.QUESTION_CHOOSER_CREATE.UseVisualStyleBackColor = True
        '
        'QUESTION_INPUT
        '
        Me.QUESTION_INPUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_INPUT.Location = New System.Drawing.Point(57, 248)
        Me.QUESTION_INPUT.MaxLength = 500
        Me.QUESTION_INPUT.Name = "QUESTION_INPUT"
        Me.QUESTION_INPUT.Size = New System.Drawing.Size(762, 244)
        Me.QUESTION_INPUT.TabIndex = 1
        Me.QUESTION_INPUT.Text = "3X+5Y-3X+2Y"
        '
        'QUESTION_COUNT
        '
        Me.QUESTION_COUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_COUNT.AutoSize = True
        Me.QUESTION_COUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_COUNT.Location = New System.Drawing.Point(1214, 22)
        Me.QUESTION_COUNT.Name = "QUESTION_COUNT"
        Me.QUESTION_COUNT.Size = New System.Drawing.Size(76, 82)
        Me.QUESTION_COUNT.TabIndex = 3
        Me.QUESTION_COUNT.Text = "2"
        Me.QUESTION_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QUESTION_CREATE
        '
        Me.QUESTION_CREATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_CREATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CREATE.ForeColor = System.Drawing.Color.Green
        Me.QUESTION_CREATE.Location = New System.Drawing.Point(58, 937)
        Me.QUESTION_CREATE.Name = "QUESTION_CREATE"
        Me.QUESTION_CREATE.Size = New System.Drawing.Size(410, 80)
        Me.QUESTION_CREATE.TabIndex = 4
        Me.QUESTION_CREATE.Text = "Add to list"
        Me.QUESTION_CREATE.UseVisualStyleBackColor = True
        '
        'QUESTION_REMOVE
        '
        Me.QUESTION_REMOVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_REMOVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_REMOVE.ForeColor = System.Drawing.Color.Maroon
        Me.QUESTION_REMOVE.Location = New System.Drawing.Point(494, 937)
        Me.QUESTION_REMOVE.Name = "QUESTION_REMOVE"
        Me.QUESTION_REMOVE.Size = New System.Drawing.Size(410, 80)
        Me.QUESTION_REMOVE.TabIndex = 5
        Me.QUESTION_REMOVE.Text = "Remove from list"
        Me.QUESTION_REMOVE.UseVisualStyleBackColor = True
        Me.QUESTION_REMOVE.Visible = False
        '
        'QUESTION_CREATION_ANSWER
        '
        Me.QUESTION_CREATION_ANSWER.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CREATION_ANSWER.Location = New System.Drawing.Point(58, 614)
        Me.QUESTION_CREATION_ANSWER.MaxLength = 500
        Me.QUESTION_CREATION_ANSWER.Name = "QUESTION_CREATION_ANSWER"
        Me.QUESTION_CREATION_ANSWER.Size = New System.Drawing.Size(762, 244)
        Me.QUESTION_CREATION_ANSWER.TabIndex = 6
        Me.QUESTION_CREATION_ANSWER.Text = "7Y"
        '
        'QUESTION_INPUT1
        '
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_RECOMPUTE_ANSWER)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_CREATION_EXIT)
        Me.QUESTION_INPUT1.Controls.Add(Me.Label6)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_CREATION_ANSWER)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_REMOVE)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_CREATE)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_COUNT)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_DISPLAY)
        Me.QUESTION_INPUT1.Controls.Add(Me.QUESTION_INPUT)
        Me.QUESTION_INPUT1.Controls.Add(Label3)
        Me.QUESTION_INPUT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QUESTION_INPUT1.Location = New System.Drawing.Point(0, 0)
        Me.QUESTION_INPUT1.Name = "QUESTION_INPUT1"
        Me.QUESTION_INPUT1.Size = New System.Drawing.Size(1324, 1062)
        Me.QUESTION_INPUT1.TabIndex = 6
        Me.QUESTION_INPUT1.TabStop = False
        Me.QUESTION_INPUT1.Text = "Question Creation"
        '
        'QUESTION_RECOMPUTE_ANSWER
        '
        Me.QUESTION_RECOMPUTE_ANSWER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_RECOMPUTE_ANSWER.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_RECOMPUTE_ANSWER.ForeColor = System.Drawing.Color.Black
        Me.QUESTION_RECOMPUTE_ANSWER.Location = New System.Drawing.Point(607, 503)
        Me.QUESTION_RECOMPUTE_ANSWER.Name = "QUESTION_RECOMPUTE_ANSWER"
        Me.QUESTION_RECOMPUTE_ANSWER.Size = New System.Drawing.Size(212, 58)
        Me.QUESTION_RECOMPUTE_ANSWER.TabIndex = 10
        Me.QUESTION_RECOMPUTE_ANSWER.Text = "Recompute"
        Me.QUESTION_RECOMPUTE_ANSWER.UseVisualStyleBackColor = True
        '
        'QUESTION_CREATION_EXIT
        '
        Me.QUESTION_CREATION_EXIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QUESTION_CREATION_EXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_CREATION_EXIT.ForeColor = System.Drawing.Color.Maroon
        Me.QUESTION_CREATION_EXIT.Location = New System.Drawing.Point(1185, 970)
        Me.QUESTION_CREATION_EXIT.Name = "QUESTION_CREATION_EXIT"
        Me.QUESTION_CREATION_EXIT.Size = New System.Drawing.Size(127, 80)
        Me.QUESTION_CREATION_EXIT.TabIndex = 9
        Me.QUESTION_CREATION_EXIT.Text = "Exit"
        Me.QUESTION_CREATION_EXIT.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(47, 536)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(421, 55)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Computed Answer"
        '
        'QUESTION_DISPLAY
        '
        Me.QUESTION_DISPLAY.AutoSize = True
        Me.QUESTION_DISPLAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUESTION_DISPLAY.Location = New System.Drawing.Point(47, 165)
        Me.QUESTION_DISPLAY.Name = "QUESTION_DISPLAY"
        Me.QUESTION_DISPLAY.Size = New System.Drawing.Size(715, 55)
        Me.QUESTION_DISPLAY.TabIndex = 2
        Me.QUESTION_DISPLAY.Text = "Simplify the following expression"
        '
        'FORM1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 1062)
        Me.Controls.Add(Me.QUESTION_INPUT1)
        Me.Controls.Add(Me.Q_CONTROL_GROUP)
        Me.Controls.Add(Me.TEACHER_GROUP)
        Me.Controls.Add(Me.LOGIN_GROUP)
        Me.Controls.Add(Me.MODE_GROUP)
        Me.Controls.Add(Me.QUESTION_CHOOSER)
        Me.Name = "FORM1"
        Me.Text = "Form1"
        Me.MODE_GROUP.ResumeLayout(False)
        Me.MODE_GROUP.PerformLayout()
        Me.LOGIN_GROUP.ResumeLayout(False)
        Me.LOGIN_GROUP.PerformLayout()
        Me.TEACHER_GROUP.ResumeLayout(False)
        Me.TEACHER_GROUP.PerformLayout()
        Me.Q_CONTROL_GROUP.ResumeLayout(False)
        Me.Q_CONTROL_GROUP.PerformLayout()
        Me.QUESTION_CHOOSER.ResumeLayout(False)
        Me.QUESTION_CHOOSER.PerformLayout()
        Me.QUESTION_INPUT1.ResumeLayout(False)
        Me.QUESTION_INPUT1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MODE_GROUP As GroupBox
    Friend WithEvents MODE_TEACHER As Button
    Friend WithEvents MODE_TITLE As Label
    Friend WithEvents MODE_STUDENT As Button
    Friend WithEvents LOGIN_GROUP As GroupBox
    Friend WithEvents LOGIN_BUTTON As Button
    Friend WithEvents LOGIN_INPUT As TextBox
    Friend WithEvents Q_CONTROL_GROUP As GroupBox
    Friend WithEvents TEACHER_GROUP As GroupBox
    Friend WithEvents TEACHER_MARK_SUBMISSIONS As Button
    Friend WithEvents TEACHER_CREATE_QUESTIONS As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Q_CONTROL_GROUP_LISTBOX As ListBox
    Friend WithEvents QUESTION_CHOOSER As GroupBox
    Friend WithEvents QUESTION_CHOOSER_CREATE As Button
    Friend WithEvents Q_CONTROL_GROUP_ADD_QUESTION As Button
    Friend WithEvents QUESTION_CHOOSER_LIST As ListBox
    Friend WithEvents QUESTION_CHOOSER_BACK As Button
    Friend WithEvents QUESTION_INPUT As RichTextBox
    Friend WithEvents QUESTION_COUNT As Label
    Friend WithEvents QUESTION_CREATE As Button
    Friend WithEvents QUESTION_REMOVE As Button
    Friend WithEvents QUESTION_CREATION_ANSWER As RichTextBox
    Friend WithEvents QUESTION_INPUT1 As GroupBox
    Friend WithEvents QUESTION_DISPLAY As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents QUESTION_CREATION_EXIT As Button
    Friend WithEvents QUESTION_RECOMPUTE_ANSWER As Button
End Class
