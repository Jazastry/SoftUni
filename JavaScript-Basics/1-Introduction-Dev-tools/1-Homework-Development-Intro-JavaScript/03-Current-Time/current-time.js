var date = new Date();
var hour = date.getHours();
var minute = date.getMinutes();

if (hour < 10) {
    hour = "0" + hour;
}
if (minute < 10) {
    minute = "0" + minute;
}

console.log(hour + ":" + minute);

