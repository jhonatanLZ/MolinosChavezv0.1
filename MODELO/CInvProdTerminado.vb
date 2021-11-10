Public Class CInvProdTerminado
    Private idPT As Integer
    Private Fecha As String
    Private Descripcion As String
    Private UnidadMedida As String
    Private cantidad As String
    Private costUnitario As String

    Public Property IdPT1 As Integer
        Get
            Return idPT
        End Get
        Set(value As Integer)
            idPT = value
        End Set
    End Property

    Public Property Fecha1 As String
        Get
            Return Fecha
        End Get
        Set(value As String)
            Fecha = value
        End Set
    End Property

    Public Property Descripcion1 As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property UnidadMedida1 As String
        Get
            Return UnidadMedida
        End Get
        Set(value As String)
            UnidadMedida = value
        End Set
    End Property

    Public Property Cantidad1 As String
        Get
            Return cantidad
        End Get
        Set(value As String)
            cantidad = value
        End Set
    End Property

    Public Property CostUnitario1 As String
        Get
            Return costUnitario
        End Get
        Set(value As String)
            costUnitario = value
        End Set
    End Property
End Class
