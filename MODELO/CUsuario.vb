Public Class CUsuario
    Private idUsuario As Integer
    Private idPersonal As Integer
    Private users As String
    Private passwords As String
    Private Nivel As String

    Public Property IdUsuario1 As Integer
        Get
            Return idUsuario
        End Get
        Set(value As Integer)
            idUsuario = value
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

    Public Property Users1 As String
        Get
            Return users
        End Get
        Set(value As String)
            users = value
        End Set
    End Property

    Public Property Passwords1 As String
        Get
            Return passwords
        End Get
        Set(value As String)
            passwords = value
        End Set
    End Property

    Public Property Nivel1 As String
        Get
            Return Nivel
        End Get
        Set(value As String)
            Nivel = value
        End Set
    End Property
End Class
