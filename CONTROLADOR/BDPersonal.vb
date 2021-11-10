Imports System.Data.SqlClient
Imports MODELO
Public Class BDPersonal
    Inherits ConexionBD
    Dim cmd As New SqlCommand
    Public dr As SqlDataReader


    Public Function agregarPersonal(ByVal dts As CPersonal) As Boolean
        conectado()
        cmd = New SqlCommand("agregar_personal")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@nombre", dts.Nombre1)
        cmd.Parameters.AddWithValue("@apellido", dts.Apellido1)
        cmd.Parameters.AddWithValue("@ci", dts.Ci1)
        cmd.Parameters.AddWithValue("@direccion", dts.Direccion1)
        cmd.Parameters.AddWithValue("@nroCelular", dts.NroCelular1)
        cmd.Parameters.AddWithValue("@id_Nivel", dts.IdNivel1)
        cmd.Parameters.AddWithValue("@fechaContrato", dts.FechaContrato1)
        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function eliminarPersonal(ByVal dts As CPersonal)
        conectado()
        cmd = New SqlCommand("elimina_personal")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@id_personal", dts.IdPersonal1)

        If cmd.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function

    Public Function editaPersonal(ByVal dts As CPersonal) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("edita_personal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@id_personal", dts.IdPersonal1)
            cmd.Parameters.AddWithValue("@nombre", dts.Nombre1)
            cmd.Parameters.AddWithValue("@apellido", dts.Apellido1)
            cmd.Parameters.AddWithValue("@ci", dts.Ci1)
            cmd.Parameters.AddWithValue("@direccion", dts.Direccion1)
            cmd.Parameters.AddWithValue("@nroCelular", dts.NroCelular1)
            cmd.Parameters.AddWithValue("@id_Nivel", dts.IdNivel1)
            cmd.Parameters.AddWithValue("@fechaContrato", dts.FechaContrato1)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function



    Public Function mostrarP() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarPersonal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function
End Class
