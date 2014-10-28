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
  
/*   $("#login-submit").on("click",function(e){
	e.preventDefault();
	$("#error-login-message").show();
  }) */

});