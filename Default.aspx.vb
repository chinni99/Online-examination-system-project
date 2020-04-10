
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = "Welcome to the test, " & Request.QueryString("username")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim h As New HttpCookie("start")
        'Set the time for the test here
        Dim dt As DateTime = Now.AddSeconds(60)
        h.Value = dt
        Response.Cookies.Add(h)
       
        Response.Redirect("default2.aspx")
    End Sub
End Class
