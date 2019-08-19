// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// url: 'https://localhost:44351/Administration/Repair/Description/Edit',
// Write your JavaScript code.



function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

function externalEdit() {
    let description = $("#description").val();
    let saveDescription = escapeHtml(description);
    let id = $("#id").val();

    $.post({
        url: 'https://localhost:44351/api/api/EditExternalDetails',
        headers: {
            'Content-Type': 'application/json',
        },
        data: JSON.stringify({
            description: saveDescription,
            id: id
        }),
        success: function success(data) {
            console.log(description);
            console.log(id);
            console.log(description);
            console.log(id);
        },
        error: function error(error) {
            console.log(error);
        }
    })
}
