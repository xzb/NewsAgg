/*function ClickUpvote() {
    alert("alert test.");
}*/

//===AJAX, 后台访问url并修改数据库===
$(document).ready(function () {


    $("#upvote-ajax").on("click", function () {
        var Li = {
            UserId: 1,
            ItemId: 13
        }
        $.ajax({
            type: "POST",
            url: "/Xml2Model/Index",
            data: Li/*,
            success: function (data) {
            }*/
        });
    });

});