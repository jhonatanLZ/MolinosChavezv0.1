Public Class PruebaArduino
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.PortName = ComboBox1.Text
        ListBox1.Items.Add("PUERTO DE COMUNICACIONES ASIGNADO")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Open()
        ListBox1.Items.Add("PUERTO ABIERTO")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.Write(ComboBox2.Text)
        ListBox1.Items.Add("DATO ENVIADO")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SerialPort1.Close()
        ListBox1.Items.Add("PUERTO CERRADO")
    End Sub
End Class