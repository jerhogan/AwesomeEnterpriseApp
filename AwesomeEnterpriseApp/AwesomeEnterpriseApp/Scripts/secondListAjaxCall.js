$(document).ready(function () {
    // alert("ok?";

    $("select#movieList").change(function () {

        // alert("ok?");
        $("#secondList").show();



        if ($('select#movieList').children(":selected")) {

            var filmName = $('select#movieList').children(":selected").html();

            alert(filmName);

            $.ajax({
                type: 'POST',
                url: '/LocationFinder/getStubData',
                // dataType: 'xml',
                data: { filmName: filmName },
                success: function (data) {

                    $('select#locationList').html('<option>' + data + '</option>');
                                   },

                error: function showError() {
                    alert("There has been an error!")
                }

            })
        }
    });
});