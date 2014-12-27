jQuery(document).ready(function ($) {
    $(".container").on("click", "#register-training-btn", function (e) {
        e.preventDefault();
        
        var url = $(e.currentTarget).attr("data-action");
        var rname = $("#rname").val();
        var rphone = $("#rphone").val();
        var rtype = $("#rtype").val();
        var rmail = $("#rmail").val();
        if (rname == "") {
            $("#rname").closest(".item").addClass("has-error");
        } else {
            $("#rname").closest(".item").removeClass("has-error");
        }
        if (rphone == "") {
            $("#rphone").closest(".item").addClass("has-error");
        } else {
            $("#rphone").closest(".item").removeClass("has-error");
        }
        if (rmail == "") {
            $("#rmail").closest(".item").addClass("has-error");
        } else {
            $("#rmail").closest(".item").removeClass("has-error");
        }
        if (rtype == "") {
            $("#rtype").closest(".form-group").addClass("has-error");
        } else {
            $("#rtype").closest(".form-group").removeClass("has-error");
        }
        if (rname != "" && rphone != "" && rtype != "" && rmail != "") {
            $("#reg-form").fadeTo("slow", 0.3);
            $("#ajax-loading").show();
            $.ajax({
                url: url,
                type: "POST",
                data: {
                    rname: rname,
                    rphone: rphone,
                    rtype: rtype,
                    rmail: rmail
                },
                success: function (data) {
                    $("#ajax-loading").hide();
                    $(".form-horizontal").fadeOut();
                    $("#register-training-message").html(data);
                    $("#register-training-message").fadeIn();
            }
            });
        }

    });

    $("#view-returning-btn").on("click", function (e) {
        e.preventDefault();
        var madg = $("#id").val();
        if (madg == "") {
            alert("Nhập mã đọc giả");
        } else {
            $.ajax({
                url: "/circulator/bookreturninghome",
                type: "POST",
                data: {
                    action: "show",
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
            url: "/circulator/bookreturninghome",
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

    $("#return-detail-container").on("click", ".punishment-confirm", function (e) {
        e.preventDefault();
        var madg = $("#id").val();
        var bid = $(e.currentTarget).attr("data-bid");
        var status = $(e.currentTarget).closest(".form-horizontal").find(".status").val();
        $.ajax({
            url: "/circulator/bookreturninghome",
            type: "POST",
            data: {
                action: "punishment",
                madg: madg,
                bid: bid,
                status: status
            },
            success: function (data) {
                $(e.currentTarget).fadeOut();
                $(e.currentTarget).closest(".form-horizontal").find(".punishment-message").html(data);
                $(e.currentTarget).closest(".form-horizontal").find(".punishment-message").fadeIn();
            }
        });
    })

    $("#tm-container").on("change", "#tm-view-type", function (e) {
        var tm_type = $("#tm-view-type").val();
        $.ajax({
            url: "/librariansupporter/trainingmanagement",
            type: "POST",
            data: {
                action: "tmview",
                tmtype: tm_type
            },
            success: function (data) {
                $("#tm-view-container").fadeOut(function () {
                    $("#tm-view-container").empty().html(data).fadeIn();
                });
            }
        });
    })

    $("#tm-container").on("click", "#training-btn", function (e) {
        var day = $("#day").val();
        var month = $("#month").val();
        var year = $("#year").val();
        var number = $("#number").val();
        var type = $("#tm-view-type").val();
        if (day == "") {
            $("#day").closest(".form-horizontal").addClass("has-error");
        } else {
            $("#day").closest(".form-horizontal").removeClass("has-error");
        }
        if (month == "") {
            $("#month").closest(".form-horizontal").addClass("has-error");
        } else {
            $("#month").closest(".form-horizontal").removeClass("has-error");
        }
        if (year == "") {
            $("#year").closest(".form-horizontal").addClass("has-error");
        } else {
            $("#year").closest(".form-horizontal").removeClass("has-error");
        }
        if (number == "") {
            $("#number").closest("div").addClass("has-error");
        } else  {
            $("#number").closest("div").removeClass("has-error");
        }
        if (day != "" && month != "" && year != "" && number != "") {
            $.ajax({
                url: "/librariansupporter/trainingmanagement",
                type: "POST",
                data: {
                    action: "adddate",
                    day: day,
                    month: month,
                    year: year,
                    number: number,
                    tmtype: type
                },
                success: function (data) {
                   
                    $("#tm-view-container").fadeOut(function () {
                        $("#tm-view-container").empty().html(data).fadeIn();
                    });
                }
            });
        }
    })
});
