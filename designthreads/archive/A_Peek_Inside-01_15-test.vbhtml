@Code
    PageData("Title") = "hello world"
    PageData("art_sub_title") = ""
    Layout = "~/_DTLayout.vbhtml"
    PageData("description") = "my desc"
End Code

<div class="spacer"></div>
<p class="opening">@PageData("description")</p>
<div class="spacer"></div>
<p>hello world</p>
