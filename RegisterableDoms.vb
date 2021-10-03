Public Class RegisterableDomains

  Private PositiveRules As RuleList
  Private NegativeRules As RuleList

  Public Function Load(ByVal fileName As String) As Boolean
    PositiveRules = New RuleList
    NegativeRules = New RuleList
    Dim fs = System.IO.File.Open(fileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
    Dim rdr = New System.IO.StreamReader(fs, System.Text.Encoding.UTF8)
    Dim x As String
    Dim i As Integer
    Dim d As JHSoftware.SimpleDNS.DomName
    Dim WhiteSpace = New Char() {" "c, ChrW(9)}
    Dim NotRule, WildcardRule As Boolean
    While Not rdr.EndOfStream
      x = rdr.ReadLine()
      If x.Length = 0 Then Continue While
      If x.StartsWith("//") Then Continue While
      i = x.IndexOfAny(WhiteSpace)
      If i > 0 Then x = x.Substring(0, i)
      NotRule = False
      If x.StartsWith("!") Then NotRule = True : x = x.Substring(1)
      If x.StartsWith(".") Then x = x.Substring(1)
      WildcardRule = False
      If x.StartsWith("*.") Then WildcardRule = True : x = x.Substring(2)
      If x.Length = 0 Then Continue While
      If Not JHSoftware.SimpleDNS.DomName.TryParse(x, d) Then Continue While
      If NotRule Then NegativeRules.Add(d, WildcardRule) Else PositiveRules.Add(d, WildcardRule)
    End While
    rdr.Close()
    fs.Close()
  End Function

  Public Function GetZoneLabelCount(ByVal d As JHSoftware.SimpleDNS.DomName) As Integer
    Dim sc = d.SegmentCount
    If sc < 2 Then Return -1
    For i = sc To 2 Step -1
      d = d.Parent
      If NegativeRules.Contains(d) Then Continue For
      If PositiveRules.Contains(d) Then Return i
    Next
    Return -1
  End Function

  Class RuleList
    Private Domains As New Dictionary(Of JHSoftware.SimpleDNS.DomName, Object)
    Private Wildcards As New Dictionary(Of JHSoftware.SimpleDNS.DomName, Object)

    Friend Sub Add(ByVal d As JHSoftware.SimpleDNS.DomName, ByVal wild As Boolean)
      If wild Then
        If Not Wildcards.ContainsKey(d) Then Wildcards.Add(d, Nothing)
      Else
        If Not Domains.ContainsKey(d) Then Domains.Add(d, Nothing)
      End If
    End Sub

    Friend Function Contains(ByVal d As JHSoftware.SimpleDNS.DomName) As Boolean
      If Domains.ContainsKey(d) Then Return True
      If Wildcards.Count = 0 Then Return False
      Return Wildcards.ContainsKey(d.Parent)
    End Function


  End Class

End Class
