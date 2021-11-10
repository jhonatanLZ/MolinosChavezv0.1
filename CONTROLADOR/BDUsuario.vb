Imports System.Data.SqlClient
Imports MODELO
Public Class BDUsuario
    Inherits ConexionBD
    Dim cmd As New SqlCommand
    Public dr As SqlDataReader
    Public Function validar_usuario(ByVal dts As MODELO.CUsuario)
        conectado()
        cmd = New SqlCommand("validar_usuario")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn

        cmd.Parameters.AddWithValue("@users", dts.Users1)
        cmd.Parameters.AddWithValue("@password", dts.Passwords1)
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

    Public Function agregarUsuario(ByVal dts As CUsuario) As Boolean
        conectado()
        cmd = New SqlCommand("agregarUsuario")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@id_personal", dts.IdPersonal1)
        cmd.Parameters.AddWithValue("@users", dts.Users1)
        cmd.Parameters.AddWithValue("@password", dts.Passwords1)
        cmd.Parameters.AddWithValue("@nivel", dts.Nivel1)
        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function eliminarUsuario(ByVal dts As CUsuario)
        conectado()
        cmd = New SqlCommand("eliminaUsuario")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@idUsuario", dts.IdUsuario1)

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
    Public Function editaUsuario(ByVal dts As CUsuario) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editaUsuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@idUsuario", dts.IdUsuario1)
            cmd.Parameters.AddWithValue("@id_personal", dts.IdPersonal1)
            cmd.Parameters.AddWithValue("@users", dts.Users1)
            cmd.Parameters.AddWithValue("@password", dts.Passwords1)
            cmd.Parameters.AddWithValue("@nivel", dts.Nivel1)

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
    Public Function mostrarU() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarUsuario")
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
