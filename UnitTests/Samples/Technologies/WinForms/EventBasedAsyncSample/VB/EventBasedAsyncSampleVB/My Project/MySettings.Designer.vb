'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.41006.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



Partial NotInheritable Class MySettings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared m_Default As MySettings
    
    Private Shared gate As Object = New Object
    
#If _MyType = "WindowsForms" Then 
        <System.Diagnostics.DebuggerNonUserCode(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _ 
        Private Shared Sub AutoSaveSettings(ByVal sender As Object, ByVal e As EventArgs) 
            If My.Application.SaveMySettingsOnExit Then 
                MySettings.Default.Save()
            End If
        End Sub
#End If
    
    Public Shared ReadOnly Property [Default]() As MySettings
        Get
            If (MySettings.m_Default Is Nothing) Then
                System.Threading.Monitor.Enter(MySettings.gate)
                Try 
                    If (MySettings.m_Default Is Nothing) Then
                        Dim tmpObj As MySettings
                        tmpObj = New MySettings
                        System.Threading.Thread.MemoryBarrier
                        MySettings.m_Default = tmpObj
                        #If _MyType = "WindowsForms" Then 
                AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
#End If
                    End If
                Finally
                    System.Threading.Monitor.Exit(MySettings.gate)
                End Try
            End If
            Return MySettings.m_Default
        End Get
    End Property
    
    <System.Configuration.ApplicationScopedSettingAttribute(),  _
     System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
     System.Configuration.DefaultSettingValueAttribute("http://localhost/samplewebservices/SimpleWebService.asmx")>  _
    Public ReadOnly Property EventBasedAsyncSampleVB_SimpleWebServices_SimpleWebService() As String
        Get
            Return CType(Me("EventBasedAsyncSampleVB_SimpleWebServices_SimpleWebService"),String)
        End Get
    End Property
End Class

Namespace My
    
    <Microsoft.VisualBasic.HideModuleName()>  _
    Public Module MySettingsProperty
        
        <System.Diagnostics.DebuggerNonUserCode(),  _
         System.ComponentModel.Design.HelpKeyword("My.Settings")>  _
        Friend ReadOnly Property Settings() As MySettings
            Get
                Return MySettings.Default
            End Get
        End Property
    End Module
End Namespace
