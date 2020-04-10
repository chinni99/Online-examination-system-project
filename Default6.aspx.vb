
Partial Class Default6
    Inherits System.Web.UI.Page


    Dim count As Integer
    Dim ans As String
    Dim a(4), t As Integer
    Dim adp As New OdbcDataAdapter
    Dim ds As New DataSet
    Dim ctr As Integer
    Dim cnn As New OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=asp; User=root;Password=;")
    Dim mydate As DateTime
    Dim cmd As New OdbcCommand
    Dim dt As New DataTable
    Dim dr As DataRow

    Sub Show()
        dt = Session("Answered")
      
        
        Me.Label11.Text = dt.Rows(ctr).Item("Serial")

        Me.Label12.Text = dt.Rows(ctr).Item("question")



       
        Me.RadioButtonList1.Items.Clear()
        Me.RadioButtonList1.Items.Add(dt.Rows(ctr).Item("choice1"))
        Me.RadioButtonList1.Items.Add(dt.Rows(ctr).Item("choice2"))
        Me.RadioButtonList1.Items.Add(dt.Rows(ctr).Item("choice3"))
        Me.RadioButtonList1.Items.Add(dt.Rows(ctr).Item("choice4"))
        Me.RadioButtonList1.SelectedIndex = dt.Rows(ctr).Item("selected")



        Session("ctr") = ctr
    End Sub




    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim mydate2 As DateTime = Now
        Dim mydate3 As DateTime

        Try
            mydate3 = (mydate - mydate2).ToString
            Me.Label10.Text = "Time Left: " & mydate3.ToShortTimeString
        Catch ex As Exception
            Me.Label10.Text = "Error Setting up the Timer. Contact Admin"
        End Try

        If mydate3.ToShortTimeString = "00:00:00" Then
            Response.Redirect("default3.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        mydate = Request.Cookies("start").Value



        If Not IsPostBack Then
            cnn.Open()
            cmd.Connection = cnn

            For j = 0 To Session.Keys.Count - 1
                a(j) = Session.Keys(j)

            Next


            For i = 0 To 4
                cmd.CommandText = "select * from test where Serial=" & a(i)
                adp.SelectCommand = cmd
                adp.Fill(ds, "test")
            Next

            cnn.Close()

            dt = New DataTable("Answered")
            dt.Columns.Add("Serial", GetType(Integer))
            dt.Columns.Add("question", GetType(String))
            dt.Columns.Add("choice1", GetType(String))
            dt.Columns.Add("choice2", GetType(String))
            dt.Columns.Add("choice3", GetType(String))
            dt.Columns.Add("choice4", GetType(String))
            dt.Columns.Add("correct", GetType(String))
            dt.Columns.Add("selected", GetType(Integer))

            Dim r As DataRow

            For Each r In ds.Tables("test").Rows
                dr = dt.NewRow
                dr("Serial") = dt.Rows.Count + 1
                dr("question") = r.Item("question")
                dr("choice1") = r.Item("choice1")
                dr("choice2") = r.Item("choice2")
                dr("choice3") = r.Item("choice3")
                dr("choice4") = r.Item("choice4")
                dr("correct") = r.Item("correct")
                dr("selected") = -1

            Next

            Session("Answered") = dt

            'Call Show()


        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Me.Label4.Visible = False
        ctr = Session("ctr")
        dt = Session("Answered")
        Session("ctr") = ctr
        Show()
        ctr += 1
        If ctr = 4 Then
            Me.Button2.Enabled = False
            'Me.Label3.Text = "LAST QUESTION"
        End If
        'Me.Button1.Enabled = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Label3.Visible = False
        ctr = Session("ctr")
        dt = Session("Answered")
        ctr = ctr - 1
        If ctr = 0 Then
            Me.Button1.Enabled = False
            'Me.Label4.Text = "FIRST QUESTION"

        End If
        Session("ctr") = ctr
        Me.Button2.Enabled = True
        Show()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        dt = Session("Answered")
        For Each drow In dt.Rows
            If drow("Serial") = Me.Label11.Text Then
                drow("Selected") = Me.RadioButtonList1.SelectedIndex
                Exit For


            End If
        Next

        Session("Answered") = dt


    End Sub




    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim marks As Integer
        dt = Session("Answered")

        For Each x In dt.Rows
            If x("Selected") + 1 = x("correct") Then
                marks += 2

            End If
        Next
        Response.Redirect("default3.aspx?marks=" & marks)
    End Sub
End Class
