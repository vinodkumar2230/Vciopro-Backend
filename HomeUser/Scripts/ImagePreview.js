$(document).ready(function () {


    var readURL = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('.profile-pic').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }


    $(".OrgLogo").on('change', function () {
        readURL(this);
    });

    $(".OrgLogo").on('change', function () {
        $("OrgLogo").click();
    });
});