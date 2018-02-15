@Code
    'remove the old sitemap if it exsists
    Dim filepath As String = "\\WEBSERVER2\blog\sitemap.xml"
    If File.Exists(filepath) Then
        My.Computer.FileSystem.DeleteFile(filepath)
    End If

    'create the textfile
    Dim xmlfile As StreamWriter
    xmlfile = My.Computer.FileSystem.OpenTextFileWriter(filepath, True)

    'creat the datatable that will srote the sitemap
    Dim validURL As New Data.DataTable
    validURL.Columns.Add("loc", GetType(String))
    validURL.Columns.Add("changefreq", GetType(String))

    'monthly pages
    Dim monthly As String() = {""}
    For Each m In monthly
        Dim r As Data.DataRow = validURL.NewRow()
        r("loc") = "http://blog.estout.com" & m
        r("changefreq") = "monthly"
        validURL.Rows.Add(r)
    Next

    'design threads
    Dim di As New DirectoryInfo("\\WEBSERVER2\blog\archive")
    Dim fiArr As FileInfo() = di.GetFiles()
    Dim fri As FileInfo
    For Each fri In fiArr
        Dim r As Data.DataRow = validURL.NewRow()
        r("loc") = "http://blog.estout.com/archive/" & fri.Name
        r("changefreq") = "monthly"
        validURL.Rows.Add(r)
    Next fri

    'write the sitemap
    xmlfile.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
    xmlfile.WriteLine("<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">")
    For Each loc As Data.DataRow In validURL.Rows
        xmlfile.WriteLine("<url>")
        xmlfile.WriteLine("<loc>" & loc("loc") & "</loc>")
        xmlfile.WriteLine("<changefreq>" & loc("changefreq") & "</changefreq>")
        xmlfile.WriteLine("</url>")
    Next
    xmlfile.WriteLine("</urlset>")
    xmlfile.Close()
End Code


