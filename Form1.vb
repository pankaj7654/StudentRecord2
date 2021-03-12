Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim cnn As SqlConnection = New SqlConnection("Data Source=DESKTOP-BA8E536;Initial Catalog=student2;Integrated Security=True")
    Dim cmd As SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim query As String
        query = "insert into s_details2 values(@roll, @name, @father, @city, @contact);"

        Dim cmd As SqlCommand = New SqlCommand(query, cnn)

        cmd.Parameters.AddWithValue("@roll", Int32.Parse(TextBox1.Text))
        cmd.Parameters.AddWithValue("@name", TextBox2.Text)
        cmd.Parameters.AddWithValue("@father", TextBox3.Text)
        cmd.Parameters.AddWithValue("@city", TextBox4.Text)
        cmd.Parameters.AddWithValue("@contact", TextBox4.Text)


        cmd.CommandType = CommandType.Text

        connection()


        If (cmd.ExecuteNonQuery().Equals(1)) Then
            MsgBox("values inserted in database")
        Else
            MsgBox("not inserted values")
        End If

        cnn.Close()

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim query As String = "select * from s_details2;"

        Dim da As SqlDataAdapter = New SqlDataAdapter(query, cnn)
        connection()

        Dim ds As DataSet = New DataSet
        da.Fill(ds, "s_details2")
        cmd.ExecuteNonQuery()
        cnn.Close()

        DataGridView1.DataSource = ds.Tables("s_details2")
        'DataGridView1.DataMember = "s_details2"


    End Sub

    Sub connection()
        If cnn.State = ConnectionState.Open Then cnn.Close()

        cnn.Open()
    End Sub

End Class
