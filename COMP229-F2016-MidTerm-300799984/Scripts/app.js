/*  Author: Sam Buensuceso
    Student#:300799984
    Date Modified:Oct19,2016
*/

$(document).ready(function () {

    console.log("app started");

    $("a.btn.btn-danger.btn-sm").click(function () {
        return confirm("Are you sure you want to delete this record?");
    });
});