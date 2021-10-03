Class MyConfig

  Friend CloneZone As JHSoftware.SimpleDNS.DomName
  'Friend TLD3 As SortedDictionary(Of JHSoftware.SimpleDNS.Plugin.DomainName, Object)
  Friend PSLFile As String

  'Property TLD3String() As String
  '  Get
  '    Dim sb As New System.Text.StringBuilder
  '    For Each dom In TLD3.Keys
  '      If sb.Length > 0 Then sb.Append(","c)
  '      sb.Append(dom.ToString)
  '    Next
  '    Return sb.ToString
  '  End Get
  '  Set(ByVal value As String)
  '    Dim sa = value.Split(","c)
  '    TLD3 = New SortedDictionary(Of JHSoftware.SimpleDNS.Plugin.DomainName, Object)
  '    Dim tld As JHSoftware.SimpleDNS.Plugin.DomainName
  '    For Each s In sa
  '      tld = JHSoftware.SimpleDNS.Plugin.DomainName.Parse(s)
  '      If Not TLD3.ContainsKey(tld) Then TLD3.Add(tld, Nothing)
  '    Next
  '  End Set
  'End Property

  Friend Function Save() As String
    'Return "1|" & _
    '       PipeEncode(CloneZone.ToString) & "|" & _
    '       PipeEncode(TLD3String)
    Return "2|" & _
       PipeEncode(CloneZone.ToString) & "|" & _
       PipeEncode(PSLFile)
  End Function

  Friend Shared Function Load(ByVal s As String) As MyConfig
    Dim sa = PipeDecode(s)
    Dim rv As New MyConfig
    Select Case sa(0)
      Case "1"
        rv.CloneZone = DomName.Parse(sa(1))
        rv.PSLFile = ""
      Case "2"
        rv.CloneZone = DomName.Parse(sa(1))
        rv.PSLFile = sa(2)
      Case Else
        Throw New Exception("Uknown config data version")
    End Select
    Return rv
  End Function

End Class
