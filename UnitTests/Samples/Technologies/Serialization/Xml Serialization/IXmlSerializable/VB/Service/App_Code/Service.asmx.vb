Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.Samples

Public Class Service_asmx

    <WebMethod()> _
    Public Function GetOrder() As Order
        Dim order As Order = New Order()
        order.Fill(5)
        Return order
    End Function

End Class
