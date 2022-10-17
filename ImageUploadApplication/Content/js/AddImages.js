$(document).ready(function () {
    $('#submit_images').click(function () {
        var urls = [];
        var imgsrc = '';
        $(".photos").each(function () {
            urls.push(this.src);
        });
        var userid = $("#userid").val();
        imgsrc = urls.join('|');
        $.ajax({
            url: '/AddImages/SaveImages',
            type: 'POST',
            dataType : 'json',
            data: { imgsrc: imgsrc, userid: userid},
            success: function (data) {
                if (data.status = 200) {
                    window.location.href = '/GetFolderImages/Index';
                } else {
                    alert(data.message);
                }
            }
        })
    });
});