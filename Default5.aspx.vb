Imports System.Data.Odbc
Imports System.Data

Partial Class Default5
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=asp; User=root;Password=;")
        cn.Open()
        'Look at the login table for login credentials.
        Dim cmd As New OdbcCommand("Select * from login where username=? and password=?", cn)

        cmd.Parameters.Add("@username", OdbcType.VarChar)
        cmd.Parameters("@username").Value = Me.TextBox1.Text

        cmd.Parameters.Add("@password", OdbcType.VarChar)
        cmd.Parameters("@password").Value = Me.TextBox2.Text

        Dim dr As OdbcDataReader

        dr = cmd.ExecuteReader

        If dr.HasRows Then
            Response.Redirect("default.aspx?username=" & Me.TextBox1.Text)

        End If

        cn.Close()


    End Sub
End Class
