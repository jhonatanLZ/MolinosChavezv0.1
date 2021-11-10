﻿Imports MODELO
Imports CONTROLADOR
Imports System.Data.SqlClient

Public Class InvMateriaPrima
    Dim fp As New BDInvMP
    Dim ep As New CInvMateriaPrima
    Private dt As New DataTable
    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""

    End Sub
    Private Sub mostrar()
        Try
            Dim func As New BDInvMP
            dt = func.mostrarInvMP
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
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox6.Text <> "" And TextBox10.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.Articulo1 = TextBox1.Text
                ep.Ubicacion1 = TextBox2.Text
                ep.UnidadMedida1 = TextBox3.Text
                ep.Fecha1 = TextBox4.Text
                ep.Detalle1 = TextBox5.Text
                ep.CantEntrada1 = TextBox6.Text
                ep.CantSalida1 = TextBox7.Text
                ep.CantSaldo1 = TextBox8.Text
                ep.CostDebito1 = TextBox9.Text
                ep.CostCredito1 = TextBox10.Text
                ep.CostSaldo1 = TextBox11.Text

                Dim ms As New IO.MemoryStream()
                If fp.agregarInvMP(ep) Then
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

    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellContentClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.datalistado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub datalistado_DoubleClick(sender As Object, e As EventArgs) Handles datalistado.DoubleClick
        TextBox1.Text = datalistado.SelectedCells.Item(2).Value
        TextBox2.Text = datalistado.SelectedCells.Item(3).Value
        TextBox3.Text = datalistado.SelectedCells.Item(4).Value
        TextBox4.Text = datalistado.SelectedCells.Item(5).Value
        TextBox5.Text = datalistado.SelectedCells.Item(6).Value
        TextBox6.Text = datalistado.SelectedCells.Item(7).Value
        TextBox7.Text = datalistado.SelectedCells.Item(8).Value
        TextBox8.Text = datalistado.SelectedCells.Item(9).Value
        TextBox9.Text = datalistado.SelectedCells.Item(10).Value
        TextBox10.Text = datalistado.SelectedCells.Item(11).Value
        TextBox11.Text = datalistado.SelectedCells.Item(12).Value
        TextBox12.Text = datalistado.SelectedCells.Item(1).Value

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox11.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.IdMP1 = TextBox12.Text
                ep.Articulo1 = TextBox1.Text
                ep.Ubicacion1 = TextBox2.Text
                ep.UnidadMedida1 = TextBox3.Text
                ep.Fecha1 = TextBox4.Text
                ep.Detalle1 = TextBox5.Text
                ep.CantEntrada1 = TextBox6.Text
                ep.CantSalida1 = TextBox7.Text
                ep.CantSaldo1 = TextBox8.Text
                ep.CostDebito1 = TextBox9.Text
                ep.CostCredito1 = TextBox10.Text
                ep.CostSaldo1 = TextBox11.Text
                If fp.editaInvMP(ep) Then
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
            ep.IdMP1 = TextBox12.Text
            dt = fp.eliminarInvMP(ep)
            MsgBox("SE ELIMINO CORRECTAMENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox7.Text = ""
        mostrar()
        limpiar()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim conexion As String
        conexion = "Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim adaptador As New SqlDataAdapter("select * from InvMateriaPrima where id_MP=" & TextBox12.Text & "", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then

            TextBox1.Text = ds.Tables("datos").Rows(0).Item(1).ToString
            TextBox2.Text = ds.Tables("datos").Rows(0).Item(2).ToString
            TextBox3.Text = ds.Tables("datos").Rows(0).Item(3).ToString
            TextBox4.Text = ds.Tables("datos").Rows(0).Item(4).ToString
            TextBox5.Text = ds.Tables("datos").Rows(0).Item(5).ToString
            TextBox6.Text = ds.Tables("datos").Rows(0).Item(6).ToString
            TextBox7.Text = ds.Tables("datos").Rows(0).Item(7).ToString
            TextBox8.Text = ds.Tables("datos").Rows(0).Item(8).ToString
            TextBox9.Text = ds.Tables("datos").Rows(0).Item(9).ToString
            TextBox10.Text = ds.Tables("datos").Rows(0).Item(10).ToString
            TextBox11.Text = ds.Tables("datos").Rows(0).Item(11).ToString
        Else
            MsgBox("no existe")
        End If
    End Sub

    Private Sub InvMateriaPrima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Dock = DockStyle.Fill
        AbrirFormEnPanel1(New ReporteInvMateriaPrima)
    End Sub
    Private Sub AbrirFormEnPanel1(ByRef FormHijo As Object)
        If Me.Panel1.Controls.Count > 0 Then
            Me.Panel1.Controls.RemoveAt(0)
        End If
        Dim fh As Form = TryCast(FormHijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.Panel1.Controls.Add(fh)
        Me.Panel1.Tag = fh
        fh.Show()
    End Sub
End Class