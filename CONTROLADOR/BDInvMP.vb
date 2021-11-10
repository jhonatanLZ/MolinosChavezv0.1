Imports System.Data.SqlClient
Imports MODELO
Public Class BDInvMP
    Inherits ConexionBD
    Dim cmd As New SqlCommand
    Public dr As SqlDataReader

    Public Function agregarInvMP(ByVal dts As CInvMateriaPrima) As Boolean
        conectado()
        cmd = New SqlCommand("agregaMatPrim")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@Articulo", dts.Articulo1)
        cmd.Parameters.AddWithValue("@Ubicacion", dts.Ubicacion1)
        cmd.Parameters.AddWithValue("@UnidadMedida", dts.UnidadMedida1)
        cmd.Parameters.AddWithValue("@Fecha", dts.Fecha1)
        cmd.Parameters.AddWithValue("@Detalle", dts.Detalle1)
        cmd.Parameters.AddWithValue("@CantEntrada", dts.CantEntrada1)
        cmd.Parameters.AddWithValue("@CantSalida", dts.CantSalida1)
        cmd.Parameters.AddWithValue("@CantSaldo", dts.CantSaldo1)
        cmd.Parameters.AddWithValue("@CostDebito", dts.CostDebito1)
        cmd.Parameters.AddWithValue("@CostCredito", dts.CostCredito1)
        cmd.Parameters.AddWithValue("@CostSaldo", dts.CostSaldo1)
        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function eliminarInvMP(ByVal dts As CInvMateriaPrima)
        conectado()
        cmd = New SqlCommand("eliminaInvMP")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@id_mp", dts.IdMP1)

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
    Public Function editaInvMP(ByVal dts As CInvMateriaPrima) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editaInvMP")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@id_mp", dts.IdMP1)
            cmd.Parameters.AddWithValue("@Articulo", dts.Articulo1)
            cmd.Parameters.AddWithValue("@Ubicacion", dts.Ubicacion1)
            cmd.Parameters.AddWithValue("@UnidadMedida", dts.UnidadMedida1)
            cmd.Parameters.AddWithValue("@Fecha", dts.Fecha1)
            cmd.Parameters.AddWithValue("@Detalle", dts.Detalle1)
            cmd.Parameters.AddWithValue("@CantEntrada", dts.CantEntrada1)
            cmd.Parameters.AddWithValue("@CantSalida", dts.CantSalida1)
            cmd.Parameters.AddWithValue("@CantSaldo", dts.CantSaldo1)
            cmd.Parameters.AddWithValue("@CostDebito", dts.CostDebito1)
            cmd.Parameters.AddWithValue("@CostCredito", dts.CostCredito1)
            cmd.Parameters.AddWithValue("@CostSaldo", dts.CostSaldo1)
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



    Public Function mostrarInvMP() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrarInvMP")
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
