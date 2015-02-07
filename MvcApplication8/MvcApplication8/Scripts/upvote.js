function ClickUpvote(obj) {
    //alert("alert test.");

    var Li = {
        UserName: "ab",
        ItemId: obj
    }
    $.ajax({
        type: "POST",
        url: "/Xml2Model/Index",
        data: Li/*,
            success: function (data) {
            }*/
    });

}

//===AJAX, 后台访问url并修改数据库===
$(document).ready(function () {


    $("#upvote-ajax").on("click", function () {
        var Li = {
            UserName: "ab",
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