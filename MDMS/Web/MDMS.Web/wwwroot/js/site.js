﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
    let saveId = escapeHtml(id);

    $.post({
        url: 'https://localhost:44351/api/api/EditExternalDetails',
        headers: {
            'Content-Type': 'application/json',
        },
        data: JSON.stringify({
            description: saveDescription,
            id: saveId
        }),
        success: function success(data) {
        },
        error: function error(error) {
            console.log(error);
        }
    })
}

function internalEdit() {
    let description = $("#descriptionExternal").val();
    let saveDescription = escapeHtml(description);
    let id = $("#id").val();
    let saveId = escapeHtml(id);

    $.post({
        url: 'https://localhost:44351/api/api/EditInternalDetails',
        headers: {
            'Content-Type': 'application/json',
        },
        data: JSON.stringify({
            description: saveDescription,
            id: saveId
        }),
        success: function success(data) {
        },
        error: function error(error) {
            console.log(error);
        }
    })
}

function ShowExternalRepairs() {
    $('#vehicleInfoHolder').hide();
    $('#vehicleExternalRepairs').show();
    $('#vehicleInternalRepairs').hide();
}

function ShowInternalRepairs() {
    $('#vehicleInfoHolder').hide();
    $('#vehicleExternalRepairs').hide();
    $('#vehicleInternalRepairs').show();
}

function ShowVehicleInfoHolder() {
    $('#vehicleInfoHolder').show();
    $('#vehicleExternalRepairs').hide();
    $('#vehicleInternalRepairs').hide();
}
