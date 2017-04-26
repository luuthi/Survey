jQuery(document).ready(function ($) {

    $('.navbar-toggle').click(function () {

        $('.responsive_menu').stop().slideToggle();
    });


    //$('.dropdown').click(function () {
    //    $('.dropdown-menu').slideToggle("slow");
    //    return false;
    //});

    //sự kiện click cho nút view
    $('.icon-view').click(function () {
        var a = $('.fa-list').css('display');
        if (a == 'inline-block') {
            $('.list-survey').show("slow");
            $('.fa-th').css('display', 'inline-block');
            $('.grid-survey').hide("slow");
            $('.fa-list').css('display', 'none');
        }
        if (a == 'none') {
            $('.list-survey').hide("slow");
            $('.fa-th').css('display', 'none');
            $('.fa-list').css('display', 'inline-block');
            $('.grid-survey').show("slow");
        }
    });
        var a = $('.fa-list').css('display');
        var b = $('.fa-th').css('display');
        $('.grid-survey').css('display', a);
        $('.list-survey').css('display', b);

        var isChromium = window.chrome,
        winNav = window.navigator,
        vendorName = winNav.vendor,
        isOpera = winNav.userAgent.indexOf("OPR") > -1,
        isIEedge = winNav.userAgent.indexOf("Edge") > -1,
        isIOSChrome = winNav.userAgent.match("CriOS");
        console.log(isChromium, vendorName);
        if (isIOSChrome) {
            // is Google Chrome on IOS
        } else if (isChromium !== null && isChromium !== undefined && vendorName === "Google Inc." && isOpera == false && isIEedge == false) {
            // is Google Chrome'
            $('.survey-header-title').css({ "display": "-webkit-inline-box", "-webkit-line-clamp": "1", "-webkit-box-orient": "vertical" });
            $('.survey-header-title').removeAttr("display");
            $('.survey-title').css({ "display": "-webkit-inline-box", "-webkit-line-clamp": "1", "-webkit-box-orient": "vertical" });
            $('.survey-title').removeAttr("display");
            $('.survey-description').css({ "display": "-webkit-inline-box", "-webkit-line-clamp": "1", "-webkit-box-orient": "vertical" });
            $('.survey-description').removeAttr("display");

        } else {
            // not Google Chrome 
        }
});