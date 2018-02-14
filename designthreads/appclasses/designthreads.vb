Imports System.IO

Public Class designthreads

    Public cats As New SortedDictionary(Of String, String)
    Public arts As New SortedDictionary(Of String, String)
    Public catsdt As New SortedDictionary(Of String, Integer)


    Sub init()
        Dim di As New DirectoryInfo("\\webserver2\blog\archive")
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim objFile As FileInfo

        Dim fullUrl As String = HttpContext.Current.Request.Url.ToString()
        Dim lastPart As String = fullUrl.Split("/"c).Last()
        Dim c As Object = Split(lastPart, "-")
        Dim cat As String = c(0)
        cat = Replace(cat, "_", " ")

        For Each objFile In fiArr
            Dim o As Object = Split(objFile.Name, "-")

            If UBound(o) > 1 Then 'only select filename that have multiple '-' init to remove non category files
                ReDim Preserve o(2) 'redim to be sure we have 3 index
                Dim adate As String = o(1)
                Dim yr As String = Split(adate, "_")(1)
                Dim mo As String = Split(adate, "_")(0)

                Dim d = Int(yr & mo)
                Dim acat As String = o(0)
                acat = Replace(acat, "_", " ")
                'add the category name if it's not already listed
                If Not (cats.ContainsKey(acat)) Then
                    cats.Add(acat, objFile.Name)
                    catsdt.Add(acat, d)
                End If
                'check date the article was produced and add the newest to the category listing link

                If d >= catsdt(acat) Then
                    cats(acat) = objFile.Name
                    catsdt(acat) = d
                End If
                'build the related articles list
                If acat = cat Then
                    Dim aname As String = Split(o(2), ".")(0)
                    aname = Replace(aname, "_", " ")
                    arts(yr & mo & "." & aname) = objFile.Name
                End If
            End If


        Next

    End Sub



End Class
