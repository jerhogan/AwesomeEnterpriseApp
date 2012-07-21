$(document).ready(function () {
    // alert("ok?";

    $("select#movieList").change(function () {

        alert("ok?");
        $("#secondList").show();

       

        if ($('select#movieList').children(":selected")) {

            var filmName = $('select#movieList').children(":selected").html();
            
             alert(filmName);

            $.ajax({
                type: 'POST',
                url: 'selectedFilmLocationsUI.cs',
                dataType: 'xml',
                data:filmName,
                success: function (filmName) {

                    $('select#locationList').append(data.responseXML);

                },

                error: function showError() {
                    alert("There has been an error!")
                      }

            })
        }
    });
});