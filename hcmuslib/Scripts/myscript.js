$(document).ready(function(){
  $("#login-btn").on("click",function(){
	window.location.href = "login.html";
  })
  
  $("#search-btn").on("click",function(){
	$(".widget.search").toggle("slow");
  })
  
  $("#contact-us-btn").on("click",function(){
	window.location.href = "contact-us.html";
  })
  
  var type = $("#training-type").val();
  if (type == "personal") {
		$("#personal-training-wrapper").show();
		$("#group-training-wrapper").hide();
	}
	else if (type == "group") {
		$("#group-training-wrapper").show();
		$("#personal-training-wrapper").hide();
	}
  $("#training-type").on("change",function(){
	var type = $(this).val();
	if (type == "personal") {
		$("#personal-training-wrapper").show();
		$("#group-training-wrapper").hide();
	}
	else if (type == "group") {
		$("#group-training-wrapper").show();
		$("#personal-training-wrapper").hide();
	}
  })
  
  $("#return-detail-container").on("change", ".form-control.status", function (e) {
      var status = $(e.currentTarget).val();
      if (status != 'normal') {
          $(e.currentTarget).closest(".form-horizontal").find(".form-group.punishment-container").fadeIn();
      } else {
          $(e.currentTarget).closest(".form-horizontal").find(".form-group.punishment-container").fadeOut();
      }
  })
/*   $("#login-submit").on("click",function(e){
	e.preventDefault();
	$("#error-login-message").show();
  }) */
  $("#tm-container").on("change", "#tm-view-type", function (e) {
      var tm_type = $("#tm-view-type").val();
      if (tm_type != "requested") {
          $("#request-info").fadeOut();
      } else {
          $("#request-info").fadeIn();
      }
  });
});