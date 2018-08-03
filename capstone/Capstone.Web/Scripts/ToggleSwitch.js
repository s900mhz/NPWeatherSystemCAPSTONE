$(document).ready(function () {
    $("#scale").change(function () {
        let isF
        if ($(this).prop('checked')) {
            $(".f").toggle()
            $(".c").toggle(false)
        }
        else {
            $(".f").toggle(false)
            $(".c").toggle()
        }
       
        console.log(isF)
    });

});