$(document).ready(function () {
    // alert("ok?";

    $('input[type="submit"]').change(function () {

            
            var filmName = $('select#movieList').children(":selected").html();

            var Location = $('select#locationList').children(":selected").html();
           
            var Radius = $('select#Radius').children(":selected").html();

            //alert(filmName + "," + Location + "," + Radius) ;

            $.ajax({
                type: 'POST',
                url: '/RestaurantFinder/getRestaurantsWithinRadius',
                // dataType: 'xml',
                data: { filmName: filmName, location: Location, radius: Radius },
                success: function (data) {
                 if (data == null) {

                    $('div#retInf').html(data);
                } else {

                    $('div#retInf').html('There are no restaurants reported in the area, sorry...');
                }


                },

                error: function showError() {
                    alert("There has been an error!")
                }

            })
        
    });
});