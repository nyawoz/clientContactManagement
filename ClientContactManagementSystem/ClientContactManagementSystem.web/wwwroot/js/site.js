// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('linkcontactCheckbox').addEventListener('change', function () {
    var modal = new bootstrap.Modal(document.getElementById('linkcontactModal'));
    if (this.checked) {
        modal.show();
    } else {
        modal.hide();
    }
});

function LinkingContacttoClient() {
    var checkboxes = document.querySelectorAll('.form-check-input');

    var selectedInfo = [];
    var selectedContactsCount = Array.from(checkboxes).filter(checkbox => checkbox.checked).length;
    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            var row = checkbox.closest('tr');


            var nameCell = row.cells[1];
            var emailCell = row.cells[2];


            var name = nameCell.textContent.trim();
            var email = emailCell.textContent.trim();

            selectedInfo.push({ name: name, email: email });
            
        }
    });

    if (selectedInfo.length > 0) {
        var message = "Selected Contacts:\n";
        selectedInfo.forEach(function (info) {
            message += "Name: " + info.name + ", Email: " + info.email + "\n";
        });
        window.alert(message + selectedContactsCount);
    } else {
        window.alert("No rows selected.");
    }

    //    if (selectedInfo.length > 0) {
    //        // Send the data to the server via AJAX
    //        $.ajax({
    //            url: '@Url.Action("InsertSelectedContacts", "ClientContactController")',
    //            type: 'POST',
    //            data: JSON.stringify(selectedContactsCount),
    //            contentType: 'application/json',
    //            success: function (response) {
    //                alert("Data successfully inserted!");
    //            },
    //            error: function (error) {
    //                alert("An error occurred: " + error.responseText);
    //            }
    //        });
    //    } else {
    //        alert("No rows selected.");
    //    }
    //}
}


