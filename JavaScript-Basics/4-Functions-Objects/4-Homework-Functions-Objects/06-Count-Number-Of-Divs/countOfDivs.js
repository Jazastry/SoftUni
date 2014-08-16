var input = '<!DOCTYPE html>\
<html>\
<head lang="en">\
    <meta charset="UTF-8">\
    <title>index</title>\
    <script src="/yourScript.js" defer></script>\
</head>\
<body>\
    <div id="outerDiv">\
        <div\
    class="first">\
            <div><div>hello</div></div>\
        </div>\
        <div>hi<div></div></div>\
        <div>I am a div</div>\
    </div>\
</body>\
</html>\
';

countDivs(input);

function countDivs(html) {

	var inString = html;

    var res = inString.match(/<div/g);

	console.log(res.length);
}

