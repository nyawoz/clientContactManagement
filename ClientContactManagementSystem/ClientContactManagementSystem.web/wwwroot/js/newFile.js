$(document).ready(function() {
    $('#addnewclientform').on('submit', function(e) {
        e.preventDefault();
        var formData = $(this).serialize();
        $.ajax({
            url: '/ClientContact/AddNewClient',
            type: 'POST',
            data: formData,
            success: function(response) {

                alert("Data successfully inserted!");

                $('#addnewclientform').trigger("reset");

            },
            error: function(error) {
                alert("An error occurred: " + error.responseText);
            }
        });
    });
});
