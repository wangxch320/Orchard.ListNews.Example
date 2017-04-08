$("#listNews-title>ul>li").mouseenter(function () {
    var index = $(this).index();
    var listNews_content = $(".listNews-content");
    listNews_content.css("display", "none");
    listNews_content.eq(index).css("display", "block");
});

$("#ListNewsDetailPart_NewsDate").bootstrapDatepickr({ date_format: "Y-m-d" });

$(".form-control").focus(function () {
    $(this).css("border-color", "#66AFE9");
});

$(".form-control").blur(function () {
    $(this).css("border-color", "#CCCCCC");
});