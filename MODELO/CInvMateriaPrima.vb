Public Class CInvMateriaPrima
    Private idMP As Integer
    Private Articulo As String
    Private ubicacion As String
    Private UnidadMedida As String
    Private Fecha As String
    Private Detalle As String
    Private cantEntrada As Integer
    Private CantSalida As Integer
    Private CantSaldo As Integer
    Private CostDebito As Integer
    Private CostCredito As Integer
    Private CostSaldo As Integer

    Public Property IdMP1 As Integer
        Get
            Return idMP
        End Get
        Set(value As Integer)
            idMP = value
        End Set
    End Property

    Public Property Articulo1 As String
        Get
            Return Articulo
        End Get
        Set(value As String)
            Articulo = value
        End Set
    End Property

    Public Property Ubicacion1 As String
        Get
            Return ubicacion
        End Get
        Set(value As String)
            ubicacion = value
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

    Public Property Fecha1 As String
        Get
            Return Fecha
        End Get
        Set(value As String)
            Fecha = value
        End Set
    End Property

    Public Property Detalle1 As String
        Get
            Return Detalle
        End Get
        Set(value As String)
            Detalle = value
        End Set
    End Property

    Public Property CantEntrada1 As Integer
        Get
            Return cantEntrada
        End Get
        Set(value As Integer)
            cantEntrada = value
        End Set
    End Property

    Public Property CantSalida1 As Integer
        Get
            Return CantSalida
        End Get
        Set(value As Integer)
            CantSalida = value
        End Set
    End Property

    Public Property CantSaldo1 As Integer
        Get
            Return CantSaldo
        End Get
        Set(value As Integer)
            CantSaldo = value
        End Set
    End Property

    Public Property CostDebito1 As Integer
        Get
            Return CostDebito
        End Get
        Set(value As Integer)
            CostDebito = value
        End Set
    End Property

    Public Property CostCredito1 As Integer
        Get
            Return CostCredito
        End Get
        Set(value As Integer)
            CostCredito = value
        End Set
    End Property

    Public Property CostSaldo1 As Integer
        Get
            Return CostSaldo
        End Get
        Set(value As Integer)
            CostSaldo = value
        End Set
    End Property
End Class
