Public Class CloneResponsePlugIn
  Implements JHSoftware.SimpleDNS.Plugin.ICloneAnswerPlugIn

  Private Cfg As MyConfig
  Private RegDoms As RegisterableDomains

#Region "events"
  Public Event AsyncError(ByVal ex As System.Exception) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.AsyncError
  Public Event LogLine(ByVal text As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LogLine
  Public Event SaveConfig(ByVal config As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveConfig
#End Region
#Region "not implemented"
  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub LoadState(ByVal state As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub

  Public Function GetDNSAskAbout() As JHSoftware.SimpleDNS.Plugin.DNSAskAbout Implements JHSoftware.SimpleDNS.Plugin.ICloneAnswerPlugIn.GetDNSAskAbout
  End Function
#End Region

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    Dim rv As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo
    rv.Name = "Clone Response"
    rv.Description = "Clones as response from data for another domain"
    rv.InfoURL = "http://www.simpledns.com/kb.aspx?kbid=1289"
    rv.MultiThreaded = False
    rv.ConfigFile = False
    Return rv
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As System.Guid, ByVal dataPath As String, ByRef maxThreads As Integer) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    Cfg = MyConfig.Load(config)
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As System.Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New OptionsUI
  End Function

  Public Sub StartService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
    RegDoms = New RegisterableDomains
    RegDoms.Load(Cfg.PSLFile)
  End Sub

  Public Sub Lookup(ByVal request As JHSoftware.SimpleDNS.Plugin.IDNSRequest, ByRef cloneFromZone As JHSoftware.SimpleDNS.Plugin.DomainName, ByRef prefixLabels As Integer, ByRef forceAA As Boolean) Implements JHSoftware.SimpleDNS.Plugin.ICloneAnswerPlugIn.Lookup
    Dim qnlc = request.QName.SegmentCount
    If qnlc < 2 Then cloneFromZone = Nothing : Exit Sub

    'If Cfg.TLD3.ContainsKey(request.QName.GetSegments(qnlc - 1, 1)) Then
    '  If qnlc < 3 Then cloneFromZone = Nothing : Exit Sub
    '  cloneFromZone = Cfg.CloneZone
    '  prefixLabels = qnlc - 3
    'Else
    '  cloneFromZone = Cfg.CloneZone
    '  prefixLabels = qnlc - 2
    'End If

    Dim zlc = RegDoms.GetZoneLabelCount(request.QName)
    If zlc < 0 Then cloneFromZone = Nothing : Exit Sub

    cloneFromZone = Cfg.CloneZone
    prefixLabels = qnlc - zlc
    forceAA = False
  End Sub

End Class
