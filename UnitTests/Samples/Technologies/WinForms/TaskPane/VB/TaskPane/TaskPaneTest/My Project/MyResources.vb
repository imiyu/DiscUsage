'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.40527.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.IO
Imports System.Resources

Namespace My.Resources
    
    'This class was auto-generated by the Strongly Typed Resource Builder
    'class via a tool like ResGen or Visual Studio.NET.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''   A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Module MyResources

        Private _resMgr As System.Resources.ResourceManager

        Private _resCulture As System.Globalization.CultureInfo

        '''<summary>
        '''   Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ResourceManager() As System.Resources.ResourceManager
            Get
                If (_resMgr Is Nothing) Then
                    Dim temp As System.Resources.ResourceManager = New System.Resources.ResourceManager("Microsoft.Samples.BoosterSamples.TaskPaneTest.MyResources", GetType(MyResources).Assembly)
                    _resMgr = temp
                End If
                Return _resMgr
            End Get
        End Property

        '''<summary>
        '''   Overrides the current thread's CurrentUICulture property for all
        '''   resource lookups using this strongly typed resource class.
        '''</summary>
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property Culture() As System.Globalization.CultureInfo
            Get
                Return _resCulture
            End Get
            Set(ByVal value As System.Globalization.CultureInfo)
                _resCulture = Value
            End Set
        End Property

        Public ReadOnly Property Icon() As System.Drawing.Bitmap
            Get
                Return CType(ResourceManager.GetObject("Icon", _resCulture), System.Drawing.Bitmap)
            End Get
        End Property

        Public ReadOnly Property zabba() As System.Drawing.Bitmap
            Get
                Return CType(ResourceManager.GetObject("zabba", _resCulture), System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
