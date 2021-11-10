Imports MODELO
Imports CONTROLADOR
Imports System.Data.SqlClient
Public Class CrearUsuario
    Dim fp As New BDUsuario
    Dim ep As New CUsuario
    Private dt As New DataTable
    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub mostrar()
        Try
            Dim func As New BDUsuario
            dt = func.mostrarU
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
    Private Sub CrearUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion As String
        conexion = "Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True"
        mostrar()
        Dim DP As New SqlDataAdapter("SELECT * from Personal", conexion)
        Dim DSP As New DataTable

        DP.Fill(DSP)
        ComboBox2.DataSource = DSP
        ComboBox2.DisplayMember = "Nombre"
        ComboBox2.ValueMember = "id_Personal"

        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim adaptador As New SqlDataAdapter("select Nombre, nivel from Personal join Nivel on Personal.id_Nivel = Nivel.id_Nivel where Nombre='" & ComboBox2.Text & "'", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then
            TextBox4.Text = ds.Tables("datos").Rows(0).Item(1).ToString

        Else
            MsgBox("no existe")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox4.Text <> "" And ComboBox2.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.IdPersonal1 = TextBox3.Text
                ep.Users1 = TextBox1.Text
                ep.Passwords1 = TextBox2.Text
                ep.Nivel1 = TextBox4.Text

                Dim ms As New IO.MemoryStream()
                If fp.agregarUsuario(ep) Then
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
        Dim adaptador As New SqlDataAdapter("select * from Usuario where id_Usuario=" & TextBox7.Text & "", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then
            TextBox3.Text = ds.Tables("datos").Rows(0).Item(1).ToString
            TextBox1.Text = ds.Tables("datos").Rows(0).Item(2).ToString
            TextBox2.Text = ds.Tables("datos").Rows(0).Item(3).ToString
            TextBox8.Text = ds.Tables("datos").Rows(0).Item(4).ToString
        Else
            MsgBox("no existe")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dt As New DataTable
            ep.IdUsuario1 = TextBox7.Text
            dt = fp.eliminarUsuario(ep)
            MsgBox("SE ELIMINO CORRECTAMENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox7.Text = ""
        mostrar()
        limpiar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.ValidateChildren = True And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox4.Text <> "" And ComboBox2.Text <> "" Then
            Try
                Dim dt As New DataTable
                ep.IdUsuario1 = TextBox7.Text
                ep.IdPersonal1 = TextBox3.Text
                ep.Users1 = TextBox1.Text
                ep.Passwords1 = TextBox2.Text
                ep.Nivel1 = TextBox4.Text
                If fp.editaUsuario(ep) Then
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

    Private Sub datalistado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellContentClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.datalistado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub datalistado_DoubleClick(sender As Object, e As EventArgs) Handles datalistado.DoubleClick
        TextBox3.Text = datalistado.SelectedCells.Item(2).Value
        TextBox1.Text = datalistado.SelectedCells.Item(3).Value
        TextBox2.Text = datalistado.SelectedCells.Item(4).Value
        TextBox8.Text = datalistado.SelectedCells.Item(5).Value
        TextBox7.Text = datalistado.SelectedCells.Item(1).Value
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim CON As New SqlConnection("Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True")
        Dim DAT_CLI As String = "select Nombre, nivel, id_Personal , Nivel.id_Nivel from Personal join Nivel on Personal.id_Nivel = Nivel.id_Nivel where Nombre='" + ComboBox2.Text + "'"
        Dim CMDP As New SqlCommand(DAT_CLI, CON)
        CON.Open()
        Dim LEER As SqlDataReader = CMDP.ExecuteReader()

        If LEER.Read() = True Then
            TextBox3.Text = LEER("id_Personal").ToString
            TextBox4.Text = LEER("nivel").ToString
            TextBox8.Text = LEER("id_Nivel").ToString
        Else
            TextBox3.Text = ""
        End If
        CON.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim CON As New SqlConnection("Data Source=JHONATAN;Initial Catalog=MolinosChavez;Integrated Security=True")
        Dim DAT_CLI As String = "SELECT * FROM Nivel WHERE nivel ='" + TextBox4.Text + "'"
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
End Class