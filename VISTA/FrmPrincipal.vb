Public Class FrmPrincipal
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub MostrarMenu_Tick(sender As Object, e As EventArgs) Handles MostrarMenu.Tick
        If Panel2.Width >= 290 Then
            Me.MostrarMenu.Enabled = False
        Else
            Me.Panel2.Width = Panel2.Width + 35
        End If
    End Sub

    Private Sub OcultarMenu_Tick(sender As Object, e As EventArgs) Handles OcultarMenu.Tick
        If Panel2.Width <= 80 Then
            Me.OcultarMenu.Enabled = False
        Else
            Me.Panel2.Width = Panel2.Width - 35
        End If
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblHora.Text = DateTime.Now.ToLongTimeString
        lblFecha.Text = DateTime.Now.ToLongDateString
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Panel2.Width = 290 Then
            OcultarMenu.Enabled = True
        ElseIf Panel2.Width = 80 Then
            MostrarMenu.Enabled = True
        End If
    End Sub

    Private Sub AbrirFormEnPanel1(ByRef FormHijo As Object)
        If Me.PanelContenedor.Controls.Count > 0 Then
            Me.PanelContenedor.Controls.RemoveAt(0)
        End If
        Dim fh As Form = TryCast(FormHijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        AbrirFormEnPanel1(New AgregarPersonal)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AbrirFormEnPanel1(New InvMateriaPrima)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AbrirFormEnPanel1(New InvProdTerminado)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AbrirFormEnPanel1(New PruebaArduino)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        System.Diagnostics.Process.Start("C:\Users\JhonatanZarzuri\source\repos\MolinosChavezv0.1\VISTA\bin\Debug\AyudaManejoSoftware.pdf")
    End Sub
End Class