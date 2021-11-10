Imports System.Runtime.InteropServices
Imports MODELO
Imports CONTROLADOR
Public Class Login
    Dim fu As New BDUsuario
    Dim eu As New CUsuario
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(LR As Integer, TR As Integer, RR As Integer, BR As Integer, WE As Integer, HE As Integer) As IntPtr

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 2, Height - 2, 20, 20))
        CheckBox2.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If txtcontraseña.Text <> "" And txtusuario.Text <> "" Then
                Dim dt As New DataTable
                eu.Users1 = txtusuario.Text
                eu.Passwords1 = txtcontraseña.Text
                dt = fu.validar_usuario(eu)
                If dt.Rows.Count > 0 Then
                    Dim nivel As String
                    nivel = dt.Rows(0)("nivel")
                    If nivel = "VENTAS" Then
                        MsgBox("Bienvenido " + txtusuario.Text + Chr(13) + nivel)
                        FrmPrincipal.Show()
                        Me.Hide()
                    ElseIf nivel = "ADMINISTRADOR" Then
                        MsgBox("Bienvenido " + txtusuario.Text + Chr(13) + nivel)
                        FrmPrincipal.Show()
                        Me.Hide()
                    ElseIf nivel = "OBRERO" Then
                        MsgBox("Bienvenido " + txtusuario.Text + Chr(13) + nivel)
                        FrmPrincipal.Show()
                        Me.Hide()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtusuario.Text = ""
        txtcontraseña.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtcontraseña.UseSystemPasswordChar = False
        CheckBox1.Visible = False
        CheckBox2.Visible = True
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        txtcontraseña.UseSystemPasswordChar = True
        CheckBox1.Visible = True
        CheckBox2.Visible = False
    End Sub
End Class
