var mycounter;
$(document).on("click", ".arrivals ul > li.toggle__pros", function () {
    var catId = $(this).attr("id");
    $(".accordionProducts .all").hide().filter("." + catId).show();
    $(".arrivals ul > li.toggle__pros").removeClass("active");
    $(this).addClass("active");
});

$(document).on("click", "#load__more_btn", async function () {

    var count = +$(this).attr("data-skip");
    var totalCount = +$(this).attr("data-totalcount");

    fetch("/Ajax/LoadMoreProducts?count=" + count, { method: "POST" })
        .then(res => res.text())
        .then(function (res) {
            $("#load_more").append(res);

            var newCount = count + 4;
            $("#load__more_btn").attr("data-skip", newCount);

            if (newCount >= totalCount) {
                $("#load__more_btn").remove();
            }
    });

    //$.ajax({
    //    url: "/Ajax/LoadMoreProducts?count=" + count,
    //    method: "POST",
    //    success: function (res) {

    //        //$("#load__more_btn").parent().before(res);
    //        $("#load_more").append(res);

    //        var newCount = count + 4;
    //        $("#load__more_btn").attr("data-skip", newCount);

    //        if (newCount >= totalCount) {
    //            $("#load__more_btn").remove();
    //        }
    //    }
    //});
});

//live event binding
$(document).on("click", ".addToCart", function (e) {
    var proId = $(this).parent().attr("data-id");

    $.ajax({
        url: "/Cart/Add/" + proId,
        success: function (res) {
            if (res.status === 200) {
                $("#cart_count").html(res.data);

                toastr.options = {
                    "closeButton": true,
                    "progressBar": false,
                    "positionClass": "toast-bottom-right",
                    "showDuration": "1000",
                    "timeOut": "5000"
                };

                toastr.success(res.message);
            }
        }
    });
});