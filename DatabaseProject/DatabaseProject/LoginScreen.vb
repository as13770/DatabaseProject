Imports System.Data.SqlClient

Public Class LoginScreen
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Dim sqlconnection As New SqlConnection("Server=ALSANDERS\SQLEXPRESS01; Database = MyGuitarShop; Integrated Security = true")
    Dim dr As SqlClient.SqlDataReader
    Dim com As SqlCommand

    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Connect.Click

        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            Connection_Status.ForeColor = Color.Blue
            Connection_Status.Text = "Missing Username and/or Password"


        ElseIf sqlconnection.State = ConnectionState.Closed Then
            Try
                Connection_Status.ForeColor = Color.DarkGoldenrod
                Connection_Status.Text = "Connecting..."
                My.Application.DoEvents()
                sqlconnection.Open()

                Connection_Status.ForeColor = Color.Green
                Connection_Status.Text = "Connection to SQL Server Successful"

                'Need Username/Password database to compare username and password to
                'Then need section of code to compare it to
                'use this:
                'https://www.daniweb.com/programming/software-development/threads/478759/check-if-record-exist-in-sql-database

                My.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                MainScreen.UName.Text = TextBox1.Text
                MainScreen.Show()
                Me.Hide()
            Catch ex As System.Data.SqlClient.SqlException
                Connection_Status.ForeColor = Color.Red
                Connection_Status.Text = "Connection Failed"
                sqlconnection.Close()
            End Try

            '        ElseIf sqlconnection.State = ConnectionState.Broken Or sqlconnection.State = ConnectionState.Connecting Then
            '        sqlconnection.Close()
            '        Connect_Click(sender, e)

        End If
    End Sub

End Class
