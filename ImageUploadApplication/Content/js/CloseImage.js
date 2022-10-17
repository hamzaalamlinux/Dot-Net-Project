$('.close').click(function () {
    if (confirm("Are you sure ?")) {
        var id = $(this).attr('id');
        console.log(id);
        $.ajax({
            url: '/RemoveImage/Remove/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.status == 200) {
                    window.location.reload();
                } else {
                    alert(data.message);
                }
            }
        })
            
    }
});