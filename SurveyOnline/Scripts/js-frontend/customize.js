jQuery(document).ready(function ($) {

    //chỉnh toolbox
    var targetOffset = $(".main-design").offset().top - 50;
    var $w = $(window).scroll(function () {
        if ($w.scrollTop() > targetOffset) {
            $('.toolbox-scrollbox').css({ "top": $w.scrollTop() - 30 });
        }
        else {
            $('.toolbox-scrollbox').css({ "top": "20%" });
        }
    });




    $('.question-row > div.model').hover(
         function () {
             $(this).addClass("hvr");
             $(this).append("<nav class='questionActions'><a class='btn btn-primary btn-edit-ques' href='javascript:void()' name='Edit'>Sửa</a><a class='btn btn-copy-ques btn-warning   ' href='javascript:void()' name='Copy'>Copy</a><a class='btn btn-del-ques btn-danger' href='javascript:void()' name=Delete'>Xoá</a></nav>")
         },
         function () {
             $(this).removeClass("hvr");
             $(this).children('nav').remove();
         });
    //sửa 1 câu hỏi
    $('.model').on('click', '.question-container', function () {
        var id = $(this).parent().attr('id');
        $('#' + id + '.edit').removeClass('hide');
        //$(element + ' > div.ediQuestion').css('z-index', '9');
    });
    $('.questions-container').on('click', '.btn-del-ques', function () {
        var del =confirm("Bạn có chăc chắn xóa?");
        if (del) {
            alert("ĐÃ xóa")
        } 
    });
    //hủy sửa câu hỏi
    $('.questions-container').on('click', '#btn-cancel', function () {
        var id = $(this).closest('.edit').attr('id');
        $('#' + id + '.edit').addClass('hide');
    });

    //lưu câu hỏi vừa thêm
    $('.edit#new').on('click', '#btn-save', function () {
        $.ajax({
            type: "POST",
            url: '/DesignSurvey/AppendNewQuestionSection',
            success: function (result) {
                $("#new.edit").before(result);
                $('#new.edit').addClass("hide");
            },
            error: function (req, status, error) {
            }
        });
    });
    //$('.questions-container').on('click', '#btn-cancel', function () {
    //    $('#new.addnew > div.ediQuestion').remove();
    //});
    //ajax append new edit quétion
    $('.btn-add-question').click(function () {
        $.ajax({
            type: "POST",
            url: '/DesignSurvey/AddNewQuestionSection',
            success: function (result) {
                $(".edit#new > .ediQuestion").remove();
                $(".edit#new > .editsection").remove();
                $(".edit#new").append(result);
                $(".edit#new").removeClass("hide");
                $('html,body').animate({
                    scrollTop: $("#new").offset().top
                },
        'slow');
            },
            error: function (req, status, error) {
            }
        });
    });
    // add new title
    $('.btn-add-title').click(function () {
        $.ajax({
            type: "POST",
            url: '/DesignSurvey/AddNewTitle',
            success: function (result) {
                $(".edit#new > .editsection").remove();
                $(".edit#new > .ediQuestion").remove();
                $(".edit#new").append(result);
                $(".edit#new").removeClass("hide");
                $(".edit#new > .editsection > #surveyDescriptionForm").show("fast");
                $(".edit#new > .editsection").css("border-bottom", "none");
                $('html,body').animate({
                    scrollTop: $("#new").offset().top
                },
        'slow');
            },
            error: function (req, status, error) {
            }
        });
    });

    $('.header > div.hoverable').hover(
        function () {
            $(this).addClass("hvr");
            var w = $(window).width();
            if (w > 768) {
                $(this).children('div').removeClass('hidden');
            }
        },
        function () {
            $(this).removeClass("hvr");
            $('.editingbtn').addClass('hidden');
        });


    //sự kienj click vào sửa tên survey và mô tả
    $('.survey-page-header').click(
       function () {
           $("#surveyTitleForm").slideToggle("slow");
           $("#surveyDescriptionForm").slideUp("slow");
           var old_name = $('.survey-title').text();
           $('.nameTitle').val(old_name);
       });

    $('.survey-page-description').click(
       function () {
           $("#surveyDescriptionForm").slideToggle("slow");
           $("#surveyTitleForm").slideUp("slow");
           var old_name = $('.survey-description').text();
           $('.desTitle').val(old_name);

       });
    // sự kiện nhấn nút lưu tên survey
    $('#btn-save-title').click(
        function () {
            var title = $(".nameTitle").val();
            if (title == "") {
                $(".ttp").css('display', 'none');
                $(".err").css('display', 'block');
                $(".nameTitle").focus();
            }
            else {
                $(".ttp").css('display', 'block');
                $(".err").css('display', 'none');
                $('.survey-title').text(title);
                $("#surveyTitleForm").slideUp("slow");
            }
        });
    $('.header').on('click', '#btn-cancel-title', function () {
        $(".ttp").css('display', 'block');
        $(".err").css('display', 'none');
        $("#surveyTitleForm").slideUp("slow");
    });
    // sự kiện nhấn nút lưu mô tả survey
    $('#btn-save-des').click(
        function () {
            var des = $(".desTitle").val();
            $('.survey-description').text(des);
            $("#surveyDescriptionForm").slideUp("slow");

        });
    $('.header').on('click', '#btn-cancel-des', function () {
    //$('#btn-cancel-des').click(function () {
        $("#surveyDescriptionForm").slideUp("slow");
       
    });
    $('.questions-container').on('click', '#btn-cancel-des', function () {
        $('#new.edit').addClass("hide")
    });
    $('.questions-container').on('click', '#btn-save-des', function () {
        $.ajax({
            type: "POST",
            url: '/DesignSurvey/AppendNewTitle',
            success: function (result) {
                $("#new.edit").before(result);
                $('#new.edit').addClass("hide");
            },
            error: function (req, status, error) {
            }
        });
    });
});