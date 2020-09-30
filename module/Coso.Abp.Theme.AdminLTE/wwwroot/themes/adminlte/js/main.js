/**
 * AdminLTE Demo Menu
 * ------------------
 * You should not use this file in production.
 * This file is for demo purposes only.
 */
(function ($) {

    $("#btnFullscreen").bind("click", function () {
        if (!$(this).attr('fullscreen')) {
            $(this).attr('fullscreen', 'true');
            $(".fa-expand").hide();
            $(".fa-compress").show()
            requestFullScreen();
        } else {
            $(this).removeAttr('fullscreen');
            $(".fa-compress").hide();
            $(".fa-expand").show();
            exitFullscreen();
        }

        //if ($(this).hasClass("ExpandDiv")) {
        //    $(this).removeClass("ExpandDiv");
        //    $(".collapse-col").css("display", "initial");
        //    $(".expand-col").removeClass("col-md-12");
        //    $(this).find("i").removeClass("fa-angle-right");
        //} else {
        //    $(this).addClass("ExpandDiv");
        //    $(".collapse-col").css("display", "none");
        //    $(".expand-col").addClass("col-md-12");
        //    $(this).find("i").addClass("fa-angle-right");
        //}
    });


    function requestFullScreen() {
        var de = document.documentElement;
        if (de.requestFullscreen) {
            de.requestFullscreen();
        } else if (de.mozRequestFullScreen) {
            de.mozRequestFullScreen();
        } else if (de.webkitRequestFullScreen) {
            de.webkitRequestFullScreen();
        }
    }
    function exitFullscreen() {
        var de = document;
        if (de.exitFullscreen) {
            de.exitFullscreen();
        } else if (de.mozCancelFullScreen) {
            de.mozCancelFullScreen();
        } else if (de.webkitCancelFullScreen) {
            de.webkitCancelFullScreen();
        }
    }


})(jQuery)
