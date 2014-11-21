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

    $("#view-returning-btn").on("click", function (e) {
        e.preventDefault();
        var madg = $("#id").val();
        if (madg == "") {
            alert("Nhập mã đọc giả");
        } else {
            $.ajax({
                url: "/librarian/bookreturninghome",
                type: "POST",
                data: {
                    madg: madg, 
                },
                success: function (data) {
                    $("#return-detail-container").html(data);
                    $("#return-detail-container").fadeIn("slow");
                }
            });
        }
    })

    $("#return-detail-container").on("click", ".return-confirm-btn", function (e) {
        e.preventDefault();
        var lhid = $(e.currentTarget).attr("data-lhid");
        $.ajax({
            url: "/librarian/bookreturninghome",
            type: "POST",
            data: {
                action: "confirm",
                lhid: lhid
            },
            success: function (data) {
                $(e.currentTarget).closest(".col-sm-8.col-md-8.book-returning-form").empty().hide().html(data).fadeIn("slow");
                //$(e.currentTarget).closest(".col-sm-8.col-md-8.book-returning-form").empty();
                //$(e.currentTarget).closest(".col-sm-8.col-md-8.book-returning-form").html(data);
                //$(e.currentTarget).closest(".col-sm-8.col-md-8.book-returning-form").fadeIn("slow");
            }
        });
    })
});
