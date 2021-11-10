Public Class CPersonal
    Private idPersonal As Integer
    Private nombre As String
    Private apellido As String
    Private ci As String
    Private direccion As String
    Private nroCelular As String
    Private IdNivel As Integer
    Private fechaContrato As String

    Public Property Nombre1 As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property Apellido1 As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property Ci1 As String
        Get
            Return ci
        End Get
        Set(value As String)
            ci = value
        End Set
    End Property

    Public Property Direccion1 As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property NroCelular1 As String
        Get
            Return nroCelular
        End Get
        Set(value As String)
            nroCelular = value
        End Set
    End Property



    Public Property FechaContrato1 As String
        Get
            Return fechaContrato
        End Get
        Set(value As String)
            fechaContrato = value
        End Set
    End Property

    Public Property IdPersonal1 As Integer
        Get
            Return idPersonal
        End Get
        Set(value As Integer)
            idPersonal = value
        End Set
    End Property

    Public Property IdNivel1 As Integer
        Get
            Return IdNivel
        End Get
        Set(value As Integer)
            IdNivel = value
        End Set
    End Property
End Class
