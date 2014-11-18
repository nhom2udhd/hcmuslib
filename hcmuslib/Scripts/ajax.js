jQuery(document).ready(function ($) {
    $(".container").on("click", "#register-training-btn", function (e) {
        e.preventDefault();
        
        var url = $(e.currentTarget).attr("data-action");
        var type = $("#training-type").val();
        var number = 1;
        if (type == 'group') {
            number = $("#number").val();
        }
        $.ajax({
            url: url,
            type: "POST",
            data: {
                type: type,
                number: number
            },
            success: function(data){
                $("#register-training-message").html(data);
        }
        });
    });
});
