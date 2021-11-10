Imports MODELO
Imports CONTROLADOR
Imports System.Data.SqlClient
Public Class AgregarNivel
    Dim fp As New BDNivel
    Dim ep As New CNivel
    Private dt As New DataTable
    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox7.Text = ""
    End Sub
    Private Sub mostrar()
        Try
            Dim func As New BDNivel
            dt = func.mostrarN
            datalistado.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                datalistado.DataSource = dt
                datalistado.ColumnHeadersVisible = True
                inexistente.Visible = False
            Else
                datalistado.DataSource = Nothing

                datalistado.ColumnHeadersVisible = False
                inexistente.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.Nivel1 = TextBox1.Text
                Dim ms As New IO.MemoryStream()
                If fp.agregarNivel(ep) Then
                    MsgBox("SE AGREGO CORRECTAMENTE  " + TextBox1.Text)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Falta ingresar algunos datos", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        limpiar()
        mostrar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox7.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.IdNivel1 = TextBox7.Text
                ep.Nivel1 = TextBox1.Text

                If fp.editaNivel(ep) Then
                    MsgBox("se edito correctamente")
                Else
                    MsgBox("FALLO AL EDITAR INTENTE DE NUEVO")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("LLene todos los campos")
        End If
        mostrar()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dt As New DataTable
            ep.IdNivel1 = TextBox7.Text
            dt = fp.eliminarNivel(ep)
            MsgBox("SE ELIMINO CORRECTAMENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox7.Text = ""
        mostrar()
        limpiar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellContentClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.datalistado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub datalistado_DoubleClick(sender As Object, e As EventArgs) Handles datalistado.DoubleClick
        TextBox1.Text = datalistado.SelectedCells.Item(2).Value

        TextBox7.Text = datalistado.SelectedCells.Item(1).Value
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim conexion As String
        conexion = "Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim adaptador As New SqlDataAdapter("select * from Nivel where id_Nivel=" & TextBox7.Text & "", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then
            TextBox1.Text = ds.Tables("datos").Rows(0).Item(1).ToString
        Else
            MsgBox("no existe")
        End If
    End Sub

    Private Sub AgregarNivel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub
End Class