﻿Imports System.Threading.Tasks

Public Class CloneResponsePlugIn
  Implements JHSoftware.SimpleDNS.Plugin.ICloneAnswer
  Implements IOptionsUI

  Private Cfg As MyConfig
  Private RegDoms As RegisterableDomains

  Public Property Host As IHost Implements IPlugInBase.Host

#Region "not implemented"
  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub

#End Region

  Public Function GetPlugInTypeInfo() As TypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetTypeInfo
    Dim rv As TypeInfo
    rv.Name = "Clone Response"
    rv.Description = "Clones as response from data for another domain"
    rv.InfoURL = "https://simpledns.plus/plugin-cloneresponse"
    Return rv
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As System.Guid, ByVal dataPath As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    Cfg = MyConfig.Load(config)
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As System.Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI.GetOptionsUI
    Return New OptionsUI
  End Function

  Private Function StartService() As Task Implements IPlugInBase.StartService
    RegDoms = New RegisterableDomains
    RegDoms.Load(Cfg.PSLFile)
    Return Task.CompletedTask
  End Function

  Public Function LookupCloneAnswer(request As IRequestContext) As Task(Of ICloneAnswer.Result) Implements ICloneAnswer.LookupCloneAnswer
    Return Task.FromResult(Lookup2(request))
  End Function

  Private Function Lookup2(request As IRequestContext) As ICloneAnswer.Result
    Dim qnlc = request.QName.SegmentCount
    If qnlc < 2 Then Return Nothing
    Dim zlc = RegDoms.GetZoneLabelCount(request.QName)
    If zlc < 0 Then Return Nothing
    Return New ICloneAnswer.Result With {.CloneFromZone = Cfg.CloneZone, .PrefixLabels = qnlc - zlc, .ForceAA = False}
  End Function

End Class
