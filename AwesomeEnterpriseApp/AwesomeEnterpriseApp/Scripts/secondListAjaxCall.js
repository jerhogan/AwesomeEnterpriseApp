$(document).ready(function () {

    $('#firstList option').click(function () {
        $('#secondList').show();
        $.ajax({
            type: 'POST',
            url: 'HomeController.cs',
            dataType: 'xml',
            complete: function addContent(msg) {
                $('select').append('<option></option>');
                //$('#ajax').append(msg.responseXML.getElementsByTagName('div')[0]);
            },
            error: function showError() {
                //$('#sidebar').append('<div id="ajax"><a href="embed-ajax.xhtml">Error</a></div>');
            }
        })

    });
});