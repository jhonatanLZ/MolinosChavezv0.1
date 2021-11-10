Imports System.Data.SqlClient
Imports MODELO
Public Class BDInvPT
    Inherits ConexionBD
    Dim cmd As New SqlCommand
    Public dr As SqlDataReader
    Public Function agregarInvPT(ByVal dts As CInvProdTerminado) As Boolean
        conectado()
        cmd = New SqlCommand("agregaPT")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@Fecha", dts.Fecha1)
        cmd.Parameters.AddWithValue("@Descripcion", dts.Descripcion1)
        cmd.Parameters.AddWithValue("@UnidadMedida", dts.UnidadMedida1)
        cmd.Parameters.AddWithValue("@Cantidad", dts.Cantidad1)
        cmd.Parameters.AddWithValue("@CostoUnitario", dts.CostUnitario1)

        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function eliminarInvPT(ByVal dts As CInvProdTerminado)
        conectado()
        cmd = New SqlCommand("eliminaInvPT")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@id_pt", dts.IdPT1)

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
    Public Function editaInvPT(ByVal dts As CInvProdTerminado) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editaInvPT")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@id_pt", dts.IdPT1)
            cmd.Parameters.AddWithValue("@Fecha", dts.Fecha1)
            cmd.Parameters.AddWithValue("@Descripcion", dts.Descripcion1)
            cmd.Parameters.AddWithValue("@UnidadMedida", dts.UnidadMedida1)
            cmd.Parameters.AddWithValue("@Cantidad", dts.Cantidad1)
            cmd.Parameters.AddWithValue("@CostoUnitario", dts.CostUnitario1)
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
    Public Function mostrarInvPT() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarInvPT")
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
