$(document).ready(function () {
    $('#add_images').click(function () {
        var urls = [];
        var imgsrc = '';
        $(".folder_img").each(function () {
            urls.push(this.src);
        });
        var userid = $("#user_ids").val();
        imgsrc = urls.join('|');
        $.ajax({
            url: '/GetFolderImages/SaveImages',
            type: 'POST',
            dataType: 'json',
            data: { imgsrc: imgsrc, userid: userid },
            success: function (data) {
                if (data.status = 200) {
                    window.location.reload();
                } else {
                    alert(data.message);
                }
            }
        })
    });
});