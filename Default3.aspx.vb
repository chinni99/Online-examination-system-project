
Partial Class Default3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label2.Text = " " & Request.QueryString("marks")
        ' You may hold this in the DB to record the result

    End Sub
End Class
