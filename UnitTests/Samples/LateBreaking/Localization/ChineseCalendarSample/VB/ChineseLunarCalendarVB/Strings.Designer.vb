﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.41208.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    Friend Class Strings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If (resourceMan Is Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Strings", GetType(Strings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cast Error!.
        '''</summary>
        Friend Shared ReadOnly Property CastError() As String
            Get
                Return ResourceManager.GetString("CastError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Jia,Yi,Bing,Ding,Wu,Ji,Geng,Xin,Ren,Gui.
        '''</summary>
        Friend Shared ReadOnly Property CelestialStem() As String
            Get
                Return ResourceManager.GetString("CelestialStem", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Rat,Ox,Tiger,Rabbit,Dragon,Snake,Horse,Ram,Monkey,Rooster,Dog,Pig.
        '''</summary>
        Friend Shared ReadOnly Property ChineseZodiac() As String
            Get
                Return ResourceManager.GetString("ChineseZodiac", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Selected date.
        '''</summary>
        Friend Shared ReadOnly Property ExceptionName() As String
            Get
                Return ResourceManager.GetString("ExceptionName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invalid date!Current calendar only supports date from 2000-1-1 to 2020-12-31,please reselect!.
        '''</summary>
        Friend Shared ReadOnly Property OutOfRangeException() As String
            Get
                Return ResourceManager.GetString("OutOfRangeException", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Slight Cold,Great Cold,Spring Begins,Rain Water,Excited Insects,Spring Equinox,Pure Brightness,Grain Rain,Summer Begins,Gain Full,Gain in Ear,Summer Solstice,Slight Heat,Great Heat,Autumn Begins,Limit of Heat,White Dew,Autumnal Equinox,Code Dew,Frost’s Descent,Winter Begins,Slight Snow,Great Snow,Winter Solstice.
        '''</summary>
        Friend Shared ReadOnly Property SolarTerms() As String
            Get
                Return ResourceManager.GetString("SolarTerms", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Zi,Chou,Yin,Mao,Chen,Si,Wu,Wei,Shen,You,Xu,Hai.
        '''</summary>
        Friend Shared ReadOnly Property TerrestrialBranch() As String
            Get
                Return ResourceManager.GetString("TerrestrialBranch", resourceCulture)
            End Get
        End Property
    End Class
End Namespace