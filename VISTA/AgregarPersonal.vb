Imports MODELO
Imports CONTROLADOR
Imports System.Data.SqlClient
Public Class AgregarPersonal
    Dim fp As New BDPersonal
    Dim ep As New CPersonal
    Private dt As New DataTable

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
    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        TextBox6.Text = ""
    End Sub
    Private Sub mostrar()
        Try
            Dim func As New BDPersonal
            dt = func.mostrarP
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
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox6.Text <> "" And ComboBox1.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.Nombre1 = TextBox1.Text
                ep.Apellido1 = TextBox2.Text
                ep.Ci1 = TextBox3.Text
                ep.Direccion1 = TextBox4.Text
                ep.NroCelular1 = TextBox5.Text
                ep.IdNivel1 = TextBox8.Text
                ep.FechaContrato1 = TextBox6.Text
                Dim ms As New IO.MemoryStream()
                If fp.agregarPersonal(ep) Then
                    MsgBox("SE AGREGO CORRECTAMENTE AL SR. " + TextBox1.Text)
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim conexion As String
        conexion = "Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim adaptador As New SqlDataAdapter("select * from Personal where id_Personal=" & TextBox7.Text & "", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then
            TextBox1.Text = ds.Tables("datos").Rows(0).Item(1).ToString
            TextBox2.Text = ds.Tables("datos").Rows(0).Item(2).ToString
            TextBox3.Text = ds.Tables("datos").Rows(0).Item(3).ToString
            TextBox4.Text = ds.Tables("datos").Rows(0).Item(4).ToString
            TextBox5.Text = ds.Tables("datos").Rows(0).Item(5).ToString
            TextBox8.Text = ds.Tables("datos").Rows(0).Item(6).ToString
            TextBox6.Text = ds.Tables("datos").Rows(0).Item(7).ToString
        Else
            MsgBox("no existe")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dt As New DataTable
            ep.IdPersonal1 = TextBox7.Text
            dt = fp.eliminarPersonal(ep)
            MsgBox("SE ELIMINO CORRECTAMENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox7.Text = ""
        mostrar()
        limpiar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And ComboBox1.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.IdPersonal1 = TextBox7.Text
                ep.Nombre1 = TextBox1.Text
                ep.Apellido1 = TextBox2.Text
                ep.Ci1 = TextBox3.Text
                ep.Direccion1 = TextBox4.Text
                ep.NroCelular1 = TextBox5.Text
                ep.IdNivel1 = TextBox8.Text
                ep.FechaContrato1 = TextBox6.Text
                If fp.editaPersonal(ep) Then
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

    Private Sub AgregarPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Dim conexion As New SqlConnection("Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True")
        'INICIALIZA UN OBJETO DE LA CLASE SQLCONNECTION
        Dim DA As New SqlDataAdapter("SELECT * from Nivel", conexion)
        Dim DTT As New DataTable

        DA.Fill(DTT)
        ComboBox1.DataSource = DTT
        ComboBox1.DisplayMember = "nivel"
        ComboBox1.ValueMember = "id_Nivel"
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
        TextBox8.Text = datalistado.SelectedCells.Item(7).Value
        TextBox6.Text = datalistado.SelectedCells.Item(8).Value
        TextBox7.Text = datalistado.SelectedCells.Item(1).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox8.Visible = False
        AbrirFormEnPanel1(New CrearUsuario)
        Panel1.Dock = DockStyle.Fill
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Dock = DockStyle.Fill
        TextBox8.Visible = False
        AbrirFormEnPanel1(New AgregarNivel)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim CON As New SqlConnection("Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True")
        Dim DAT_CLI As String = "SELECT * FROM Nivel WHERE nivel ='" + ComboBox1.Text + "'"
        Dim CMDP As New SqlCommand(DAT_CLI, CON)
        CON.Open()
        Dim LEER As SqlDataReader = CMDP.ExecuteReader()

        If LEER.Read() = True Then
            TextBox8.Text = LEER("id_Nivel").ToString
        Else
            TextBox8.Text = ""
        End If
        CON.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel1.Dock = DockStyle.Fill
        Button7.Visible = False
        TextBox8.Visible = False
        AbrirFormEnPanel1(New ReporteEmpleados)
    End Sub
End Class