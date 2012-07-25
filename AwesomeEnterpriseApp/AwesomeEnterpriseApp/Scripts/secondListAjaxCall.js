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
                url: '/LocationFinder/getStubData/',
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



    $('button#send').click(function () {



        var radius = $('select#radiusList').children(':selected').html();
        alert(radius);


        $.ajax({
            type: 'POST',
            url: '/RestaurantFinder/GetMessage/',
            // dataType: 'xml',
            data: {radius:radius},
            success: function (data) {
                // $('div#retInf p').empty();
                if (data != null) {
                    $('#retInf').show();
                    $('#retInf').html("<h5>"+data+"</h5>");
                }
                //} else {alert('Error in retrieving data!') }

            },

            error: function showError() {
                alert("There has been an error!")
            }

        })
    });
    //});
    //return false;
});