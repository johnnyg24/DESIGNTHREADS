@code
    Dim designthreads As New designthreads.designthreads
    designthreads.init()

End Code
<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-114180545-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-114180545-1');
    </script>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="google-site-verification" content="tfNSJev25wB6YERaXWiXLI5Pzj6q5TrUOmzC1KgxN7k" />
    <meta name = "viewport" content="width=device-width, initial-scale=1">
    <meta name = "keywords" content="Stout, Interior Design, To the Trade, Wholesale, Fabrics, Trimmings, Drapery Hardware, Marcus William, Cypton, Sunbrella, Nanotex, Upholstery, Drapery, Multipurpose" />
    @If PageData("description") IsNot Nothing Then
        @<meta name="description" content="@PageData("description")">
    Else
        @<meta name="description" content="Stout is a wholesale distributor of decorative fabrics, trimmings, drapery hardware and pillows.">
    End If
    <title>@PageData("Title")</title>
    <link rel="apple-touch-icon" href="~/appimages/mobile-icon.png" />
    <link rel="shortcut icon" href="~/icongif.ico" type="image/x-icon">
    <link href="https://www.estout.com/Content/bundlev2.min.css" rel="stylesheet" />
    <link href="~/Content/designthread-overrides.css" rel="stylesheet" />
    <link href="https://use.fontawesome.com/releases/v5.0.6/css/all.css" rel="stylesheet">
</head>
<body>
    
    <div>
        <div id="social-links">
            <a title="Facebook" class="d-none d-md-inline sb-primary-text" href="//www.facebook.com/stouttextiles"><i class="fab fa-facebook"></i></a>
            <a title="Pinterest" class="d-none d-md-inline sb-primary-text" href="//pinterest.com/stouttextiles"><i class="fab fa-pinterest"></i></a>
            <a title="Instagram" class="d-none d-md-inline sb-primary-text" href="//www.instagram.com/stouttextiles"><i class="fab fa-instagram"></i></a>
        </div>
        <table id="sb-header">
            <tr>
                <td id="sb-logo-wrap">
                    <a href="https://www.estout.com">
                        <img src="~/appimages/logos/stout-logo-rwd.png" />
                    </a>
                </td>
                <td id="sb-title-wrap">
                    
                        <h1>DESIGN THREADS</h1>
                        <h5>a blog for today's designer</h5>
                    
                </td>
                <td id="sb-menu-wrap" class="d-md-none text-right" onclick="$('.nav-toggle').toggle()">
                    <i class="fas fa-bars" style="margin-left:10px"></i>
                </td>
            </tr>
        </table>
    </div>
    
    <div class="text-center sb-primary-bg">
        <div style="min-height:40px">
            <ul id="sb-nav">
                @*<li class="d-md-none"><a onclick="$('.nav-toggle').toggle()">Articles <span class="caret"></span></a></li>*@
                <li class="nav-toggle"><a href="~/index.vbhtml">Featured</a></li>
                <li class="nav-toggle"><a href="~/archive/@(designthreads.cats("Chroma Color"))">Chroma Color</a></li>
                <li class="nav-toggle"><a href="~/archive/@(designthreads.cats("Design Style"))">Design Style</a></li>
                <li class="nav-toggle"><a href="~/archive/@(designthreads.cats("History"))">History</a></li>
                <li class="nav-toggle"><a href="~/archive/@(designthreads.cats("Pattern Playfulness"))">Pattern Playfulness</a></li>
                <li class="nav-toggle"><a href="~/archive/@(designthreads.cats("Trends"))">Trends</a></li>
                <li class="dropdown nav-toggle" style="padding-bottom:20px">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">More <span class="caret"></span></a>
                    <ul class="dropdown-menu sb-primary-bg">
                        <li><a href="~/archive/@(designthreads.cats("Celebrate"))">Celebrate</a></li>
                        <li><a href="~/archive/@(designthreads.cats("A Peek Inside"))">A Peek Inside</a></li>
                        <li><a href="~/archive/@(designthreads.cats("Company News"))">Company News</a></li>
                        <li><a href="#">About Us</a></li>
                    </ul>
                </li>

            </ul>
            <div id="social-icons-mini">
                <a title="Facebook" class="d-inline d-md-none" href="//www.facebook.com/stouttextiles"><i class="fab fa-facebook "></i></a>
                <a title="Pinterest" class="d-inline d-md-none" href="//pinterest.com/stouttextiles"><i class="fab fa-pinterest"></i></a>
                <a title="Instagram" class="d-inline d-md-none" href="//www.instagram.com/stouttextiles"><i class="fab fa-instagram"></i></a>
            </div>
            @If InStr(Request.Url.ToString(), "_") > 0 Then
                @<div id="sb-related" >
                    <a onclick="$('#the-article').toggle()">Related Atricles <span class="caret"></span></a>
                </div>
            End if
            
        </div>
    </div>
    
    <div class="container">
        <div id="body">
            <script src="~/Scripts/bundle.min.js"></script>
            <section class="content-wrapper main-content clear-fix">
                @if InStr(Request.Url.ToString(), "_") > 0 Then
                    @<div Class="row">
                        <div Class="col-xs-12 col-sm-9">
                            <div id="the-article">
                                <h1 class="sb-card-title">@PageData("title")</h1>
                                <div Class=" sb-sub-card-title">@PageData("art_sub_title")</div>
                                <h5>Date: @Replace(Split(Request.Url.ToString(), "-")(1), "_", "/")</h5>
                                @RenderBody()
                            </div>
                        </div>

                        <div Class="col-xs-12 col-sm-3">
                            <div id="related-articles">
                                <div Class="sb-card-title">Related Articles</div>
                                <div Class="list-group">
                                    @For Each a As KeyValuePair(Of String, String) In designthreads.arts.Reverse
                                        Dim n As Object = Split(a.Key, ".")
                                        Dim d As String = Right(n(0), n(0).length - 2) & "/" & Left(n(0), 2)
                                        @<a class="list-group-item" href="~/archive/@a.Value">@n(1) @d</a>
                                    Next
                                </div>
                            </div>
                        </div>
                    </div>
                Else
                    @<div Class="col-xs-12">
                        <div>
                            @RenderBody()
                        </div>
                    </div>
                End If

            </section>
        </div>

    </div>
        
    @RenderSection("CSS", required:=False)
    @RenderSection("Scripts", required:=False)
</body>
</html>
