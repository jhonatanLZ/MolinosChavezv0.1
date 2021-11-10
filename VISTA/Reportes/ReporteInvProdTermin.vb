Public Class ReporteInvProdTermin
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        Dim OBJEREP As New CrystalReport2
        CrystalReportViewer1.ReportSource = OBJEREP
    End Sub
End Class