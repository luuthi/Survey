jQuery(document).ready(function ($) {

    const tr_ins_mul = "<tr><td width='5%'> <span class='radio-button-display-edit'></span></td> <td width='75%'><input type='text' name='titleQuestion' id='titleQuestion' class='contant-solution form-control' placeholder='Nhập lựa chọn ...' /> </td> <td width='20%'> <i class='addAns fa fa-plus'></i> <i class='delAns fa fa-trash-o'></i></td> </tr>"
    const tr_ins_drop = "<tr><td width='5%'> 2</td> <td width='75%'><input type='text' name='titleQuestion' id='titleQuestion' class='contant-solution form-control' placeholder='Nhập lựa chọn ...' /> </td> <td width='20%'> <i class='addAns fa fa-plus'></i> <i class='delAns fa fa-trash-o'></i></td> </tr>"
    const tr_ins_check = "<tr><td width='5%'>  <span class='checkbox-button-display-edit'></span></td> <td width='75%'><input type='text' name='titleQuestion' id='titleQuestion' class='contant-solution form-control' placeholder='Nhập lựa chọn ...' /> </td> <td width='20%'> <i class='addAns fa fa-plus'></i> <i class='delAns fa fa-trash-o'></i></td> </tr>"
    //thêm 1 row
    $('.questions-container').on('click', '.addAns', function () {
        var idactive = $('.answer-container > div.active').attr('id');
        console.log(idactive);
        var id = $(this).closest('.edit').attr('id');
        if (idactive == "multipleChoice") {
            $('div#' + id + '.edit > .ediQuestion > .editQuestionContent').find('#' + idactive + ' >.answerContainer > .answer-list').append(tr_ins_mul);
        }
        else if (idactive == "dropDown") {
            $('div#' + id + '.edit > .ediQuestion > .editQuestionContent').find('#' + idactive + ' >.answerContainer > .answer-list').append(tr_ins_drop);
        }
        else if (idactive == "checkBoxes") {
            $('div#' + id + '.edit > .ediQuestion > .editQuestionContent').find('#' + idactive + ' >.answerContainer > .answer-list').append(tr_ins_check);
        }
        
    });
    //Xóa 1 row
    $('.questions-container').on('click', '.delAns', function () {
        var idactive = $('.answer-container > div.active').attr('id');
        var id = $(this).closest('.edit').attr('id');
        var rowCount = $('div#' + id + '.edit > .ediQuestion > .editQuestionContent').find('#' + idactive + ' >.answerContainer > .answer-list').children('tr').length;
        console.log(rowCount);
        if (rowCount > 2) {
            $(this).closest("tr").remove();
        }

    });

    $('.questions-container').on('change', '.tab-select', function () {
        var id = $(this).closest('.edit').attr('id');
        setTabVisibility(id);
    });
    //hàm điều chỉnh các tab
    function setTabVisibility(id){
        var selectedVal = $('div#' + id + '.edit').find('.tab-select').val();
        console.log(selectedVal,id);
        if (selectedVal == "MultipleChoice") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#multipleChoice').addClass("in");
            $('div#multipleChoice').addClass("active");
        }
        else if (selectedVal == "Dropdown") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#dropDown').addClass("in");
            $('div#dropDown').addClass("active");
        }
        else if (selectedVal == "Checkboxs") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#checkBoxes').addClass("in");
            $('div#checkBoxes').addClass("active");
        }
        else if (selectedVal == "LinearScale") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#linearScale').addClass("in");
            $('div#linearScale').addClass("active");
        }
        else if (selectedVal == "Paragraph") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#paragraph').addClass("in");
            $('div#paragraph').addClass("active");
        }
        else if (selectedVal == "Date") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#date').addClass("in");
            $('div#date').addClass("active");
        }
        else if (selectedVal == "Time") {
            $.each($('.tab-content'), function (i, tab) {
                $('.tab-content > div', tab).each(function () {
                    $(this).removeClass("in");
                    $(this).removeClass("active");
                });
            });
            $('div#time').addClass("in");
            $('div#time').addClass("active");
        }
    }
});