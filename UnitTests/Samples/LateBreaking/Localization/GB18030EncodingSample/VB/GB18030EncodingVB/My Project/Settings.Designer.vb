﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.41206.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

<Assembly: Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="GB18030EncodingVB.Settings.get_Default():GB18030EncodingVB.Settings"),  _
 Assembly: Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="GB18030EncodingVB.My.MySettingsProperty.get_Settings():GB18030EncodingVB.Settings")> 


<Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial NotInheritable Class Settings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Private Shared defaultInstance As Settings = New Settings
    
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Private Shared addedHandler As Boolean

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _ 
    Private Shared Sub AutoSaveSettings(ByVal sender As Object, ByVal e As EventArgs) 
        If My.Application.SaveMySettingsOnExit Then 
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As Settings
        Get
            
#If _MyType = "WindowsForms" Then
            If Not addedHandler Then
                AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                addedHandler = True
            End If
#End If
            Return defaultInstance
        End Get
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.GB18030EncodingVB.Settings
            Get
                Return Global.GB18030EncodingVB.Settings.Default
            End Get
        End Property
    End Module
End Namespace
