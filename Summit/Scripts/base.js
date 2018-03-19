$(document).ready(function ($) {

    if ($('#section-graduationprofiles').length > 0) {
        var jssor_1_options = {
            $AutoPlay: 1,
            $Idle: 0,
            $SlideDuration: 5000,
            $SlideEasing: $Jease$.$Linear,
            $PauseOnHover: 4,
            $SlideWidth: 150,
            $Align: 0
        };

        var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);
        var jssor_2_slider = new $JssorSlider$("jssor_2", jssor_1_options);
        var jssor_3_slider = new $JssorSlider$("jssor_3", jssor_1_options);
        /*#region responsive code begin*/

        var MAX_WIDTH = 1000;

        function ScaleSlider() {
            var containerElement = jssor_1_slider.$Elmt.parentNode;
            var containerElement = jssor_2_slider.$Elmt.parentNode;
            var containerElement = jssor_3_slider.$Elmt.parentNode;
            var containerWidth = containerElement.clientWidth;

            if (containerWidth) {

                var expectedWidth = Math.min(MAX_WIDTH || containerWidth, containerWidth);

                jssor_1_slider.$ScaleWidth(expectedWidth);
            }
            else {
                window.setTimeout(ScaleSlider, 30);
            }
        }

        ScaleSlider();
    }
    

    $(window).bind("load", ScaleSlider);
    $(window).bind("resize", ScaleSlider);
    $(window).bind("orientationchange", ScaleSlider);

    $('.region,.program').hover(function () {

        $(this).addClass("hover-region");

    }, function () {
        $(this).removeClass("hover-region");
    });
    $('.region').on('click', function () {
        $('.selected-region').removeClass("selected-region");
        $(this).addClass("selected-region");
        var region = $(this).text();
        var program = $('.selected-program').text();
        if (region != "" && program != "") {
            //alert("Refreshing page based on region- " + program + "|" + region);
            reloadPage(region, program);
        }
    });
    $('.program').on('click', function () {
        $('.selected-program').removeClass("selected-program");
        $(this).addClass("selected-program");
        var program = $(this).text();
        var region = $('.selected-region').text();
        if (region != "" && program != "") {
            // alert("Refreshing page based on program - "+program+"|"+region);
            reloadPage(region, program);

        }
    });

    function getBaseUrl(address) {

        var path = "";
        if (window.location.hostname.toLowerCase() == "localhost") {
            path = location.protocol + "//" + location.host + "/";
        }
        else {
            path = location.protocol + "//" + location.host + "/";
            //path = location.protocol + "//" + location.host + "/" + location.pathname.split('/')[1] + "/";
        }
        return path;
    }

    function reloadPage(region, program) {
        location.href = getBaseUrl() + "Home/Index?Region=" + region + "&Program=" + program;
        //$.ajax({
        //    contentType: "application/json; charset=utf-8",
        //    url: 'Index',
        //    type: 'post',
        //    data: JSON.stringify({
        //        Region: region,
        //        Program: program
        //    }),
        //    success: function (result) {
        //        alert("Data has been added successfully.");
        //    },
        //    error: function (result) {
        //        alert("Error while inserting data");
        //    }
        //});
    }

    $(document).on('change', '.btn-file :file', function () {
        var input = $(this),
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [label]);
    });

    $('.btn-file :file').on('fileselect', function (event, label) {

        var input = $(this).parents('.input-group').find(':text'),
            log = label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#img-upload').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }


    $("#imgInp").change(function () {
        readURL(this);
    });

});
function register() {
    var name = $("#name").val();
    var badgeid = $("#badgeid").val();
    var program = $("#program").val();
    var city = $("#city").val();
    var country = $("#country").val();
    var tshirtSize = $("#tshirtSize").val();
    var meal = $('input[name=meal]:checked').val();
    var gender = $("input[name=gender]:checked").val();
    var data = {
        username: name,
        region: city,
        city: city,
        country: country,
        isITDP: program == "ITDP" ? true : false,
        isITLP: program == "ITLP" ? true : false,
        isLeader: program == "LEADER" ? true : false,
        tShirtSize: tshirtSize
    }
    $.ajax({
        contentType: "application/json; charset=utf-8",
        url: "http://annualsummit.aus.amer.dell.com/summitAPI" + 'api/Users',
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json/text',
        success: function (message) {
            $("#errorMsg").html(message);
        },
        fail: function (message) {
            $("#errorMsg").html("Error in updating: " + message);
        },
        error: function (jqXHR, exception) {
            if (jqXHR.status === 200) {
                msg = jqXHR.responseText;
            }
            else if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status === 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status === 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            $("#errorMsg1").html(msg);
        }
    });
}