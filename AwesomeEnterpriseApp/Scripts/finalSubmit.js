$(document).ready(function () {
    // alert("ok?";

    $('button#send').click(function() {

        var filmName = $('select#movieList').children(":selected").html();
        alert("finalSubmit.js:" + filmName);
        var Location = $('select#locationList').children(':selected').html();
        alert(Location);
        var Radius = $('select#radiusList').children(':selected').html();
        alert(Radius);


        $.ajax({
            type: 'POST',
            url: '/RestaurantFinder/getMessage',
            // dataType: 'xml',
            data: { filmName: filmName, location: Location, radius: Radius },
            success: function (data) {
                // $('div#retInf p').empty();
                $('div#retInf').html(data);

                //} else {alert('Error in retrieving data!') }

            },

            error: function showError() {
                alert("There has been an error!")
            }

        })
    });

});