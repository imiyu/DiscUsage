﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50613.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50613.0.
'
Namespace localhost
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", ""),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WebSettingsServiceSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WebSettingsService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetServerTimeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetAppConfigPropertyOperationCompleted As System.Threading.SendOrPostCallback
        
        Private SetAppConfigPropertyOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Microsoft.Samples.Windows.Forms.WebSettingsClient.Settings.Default.WebSettingsClient_localhost_WebSettingsService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GetServerTimeCompleted As GetServerTimeCompletedEventHandler
        
        '''<remarks/>
        Public Event GetAppConfigPropertyCompleted As GetAppConfigPropertyCompletedEventHandler
        
        '''<remarks/>
        Public Event SetAppConfigPropertyCompleted As SetAppConfigPropertyCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServerTime", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetServerTime() As String
            Dim results() As Object = Me.Invoke("GetServerTime", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetServerTimeAsync()
            Me.GetServerTimeAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetServerTimeAsync(ByVal userState As Object)
            If (Me.GetServerTimeOperationCompleted Is Nothing) Then
                Me.GetServerTimeOperationCompleted = AddressOf Me.OnGetServerTimeOperationCompleted
            End If
            Me.InvokeAsync("GetServerTime", New Object(-1) {}, Me.GetServerTimeOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetServerTimeOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetServerTimeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetServerTimeCompleted(Me, New GetServerTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAppConfigProperty", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetAppConfigProperty(ByVal appName As String, ByVal propName As String) As Object
            Dim results() As Object = Me.Invoke("GetAppConfigProperty", New Object() {appName, propName})
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetAppConfigPropertyAsync(ByVal appName As String, ByVal propName As String)
            Me.GetAppConfigPropertyAsync(appName, propName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetAppConfigPropertyAsync(ByVal appName As String, ByVal propName As String, ByVal userState As Object)
            If (Me.GetAppConfigPropertyOperationCompleted Is Nothing) Then
                Me.GetAppConfigPropertyOperationCompleted = AddressOf Me.OnGetAppConfigPropertyOperationCompleted
            End If
            Me.InvokeAsync("GetAppConfigProperty", New Object() {appName, propName}, Me.GetAppConfigPropertyOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetAppConfigPropertyOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetAppConfigPropertyCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetAppConfigPropertyCompleted(Me, New GetAppConfigPropertyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetAppConfigProperty", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub SetAppConfigProperty(ByVal appName As String, ByVal propName As String, ByVal newvalue As String)
            Me.Invoke("SetAppConfigProperty", New Object() {appName, propName, newvalue})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SetAppConfigPropertyAsync(ByVal appName As String, ByVal propName As String, ByVal newvalue As String)
            Me.SetAppConfigPropertyAsync(appName, propName, newvalue, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SetAppConfigPropertyAsync(ByVal appName As String, ByVal propName As String, ByVal newvalue As String, ByVal userState As Object)
            If (Me.SetAppConfigPropertyOperationCompleted Is Nothing) Then
                Me.SetAppConfigPropertyOperationCompleted = AddressOf Me.OnSetAppConfigPropertyOperationCompleted
            End If
            Me.InvokeAsync("SetAppConfigProperty", New Object() {appName, propName, newvalue}, Me.SetAppConfigPropertyOperationCompleted, userState)
        End Sub
        
        Private Sub OnSetAppConfigPropertyOperationCompleted(ByVal arg As Object)
            If (Not (Me.SetAppConfigPropertyCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SetAppConfigPropertyCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", "")>  _
    Public Delegate Sub GetServerTimeCompletedEventHandler(ByVal sender As Object, ByVal e As GetServerTimeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", ""),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetServerTimeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", "")>  _
    Public Delegate Sub GetAppConfigPropertyCompletedEventHandler(ByVal sender As Object, ByVal e As GetAppConfigPropertyCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", ""),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetAppConfigPropertyCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Object
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Object)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("", "")>  _
    Public Delegate Sub SetAppConfigPropertyCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
End Namespace
