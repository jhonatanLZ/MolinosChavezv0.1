Imports System.Data.SqlClient
Imports MODELO
Public Class BDNivel
    Inherits ConexionBD
    Dim cmd As New SqlCommand
    Public dr As SqlDataReader

    Public Function agregarNivel(ByVal dts As CNivel) As Boolean
        conectado()
        cmd = New SqlCommand("agregarNivel")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@Nivel", dts.Nivel1)
        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function eliminarNivel(ByVal dts As CNivel)
        conectado()
        cmd = New SqlCommand("eliminaNivel")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@idNivel", dts.IdNivel1)

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
    Public Function editaNivel(ByVal dts As CNivel) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editaNivel")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@idNivel", dts.IdNivel1)
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



    Public Function mostrarN() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarNivel")
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
