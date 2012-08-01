

$(document).ready(function () {
    // alert("ok?");

    $("select#movieList").change(function () {

        // alert("ok?");
        $("#secondList").show();



        if ($("select#movieList").children(":selected")) {

            var filmName = $("select#movieList").children(":selected").html();

            // alert("secondListAjaxCall:" + filmName);

            $.ajax({
                type: "POST",
                url: "/LocationFinder/getSecondList/",
                // dataType: 'xml',
                data: { filmName: filmName },
                success: function (data) {
                 
                    $('select#locationList').html(data);

                },


                error: function showError() {
                    alert("There has been an error!")
                }

            })
        }
    },



    $('select#radiusList').change(function () {

        if ($('select#radiusList').children(":selected")) {

            var radius = $('select#radiusList').children(':selected').html();
            var filmName = $("select#movieList").children(":selected").html();
            var location = $("select#locationList").children(":selected").html();

            //alert(radius);
            //alert(filmName);
            //alert(location);


            $.ajax({
                type: "POST",
                url: "/RestaurantFinder/getMessage/",
                // dataType: 'xml',
                data: { radius: radius, filmName: filmName, location: location },
                success: function (data) {

                    if (data != null) {
                        $("#retInf").show();
                        $("#retInf").html('<h4>Your selection of restaurants:</h4><br/><p style="margin-left:30px;display:block"></p>' + data + '</p>');
                    }
                    else
                    { $("#retInf p").html('Sorry, no restaurants registered in this area!'); }

                },

                error: function showError() {
                    alert("There has been an error in GetMessage!")
                }

            })

        }
    }))
    //});
    //return false;
});