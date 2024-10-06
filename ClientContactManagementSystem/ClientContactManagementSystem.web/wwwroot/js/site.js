// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Getting Client Code when button is Clicked

var clientCode;
var selectedContactsCount;
$(document).ready(function () {
    $('.btn-get-info').on('click', function () {
        var row = $(this).closest('tr');
        clientCode = row.find('td:eq(1)').text(); // Client Code
    });
});

// modal pop up
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
    selectedContactsCount = Array.from(checkboxes).filter(checkbox => checkbox.checked).length;
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

    var statusValue = selectedContactsCount;
    var clientId = clientCode;

    if (selectedInfo.length > 0) {
        // Update Number of Linked Contact
        $.ajax({
            url: '/ClientContact/updatenumberofLinkingContact', // The URL of your controller action
            type: 'POST',
            data: { code: clientId, status: statusValue },
            success: function (response) {
                alert('Status updated successfully!');
            },
            error: function (xhr, status, error) {
                alert('Error updating number of linking contacts');
            }
        });
        window.alert(message + selectedContactsCount);
    } else {
        window.alert("No rows selected.");
    }
}
