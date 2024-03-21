// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap.bundle")

// Write your JavaScript code.

$(document).ready(function () {
    //Hide Menus when document ready.
    $("#GLOTCEQOptions").hide();
    $("#CrestwoodOptions").hide();
    $("#OtherReportsOptions").hide();
    $("#ManagerToolsOptions").hide();
    $("#NorthwindOptions").hide();

    //Show specific menu when clicked, hide all others.
    $("#GLOTCEQMenu").click(function () {
        $("#GLOTCEQOptions").toggle();
        $("#CrestwoodOptions").hide();
        $("#OtherReportsOptions").hide();
        $("#ManagerToolsOptions").hide();
        $("#NorthwindOptions").hide();
    });

    $("#CrestwoodMenu").click(function () {
        $("#CrestwoodOptions").toggle();
        $("#GLOTCEQOptions").hide();
        $("#OtherReportsOptions").hide();
        $("#ManagerToolsOptions").hide();
        $("#NorthwindOptions").hide();
    });
    $("#NorthwindMenu").click(function () {
        $("#NorthwindOptions").toggle();
        $("#CrestwoodOptions").hide();
        $("#GLOTCEQOptions").hide();
        $("#OtherReportsOptions").hide();
        $("#ManagerToolsOptions").hide();
    });

    $("#OtherReportsMenu").click(function () {
        $("#OtherReportsOptions").toggle();
        $("#CrestwoodOptions").hide();
        $("#GLOTCEQOptions").hide();
        $("#ManagerToolsOptions").hide();
        $("#NorthwindOptions").hide();
    });

    $("#ManagerToolsMenu").click(function () {
        $("#ManagerToolsOptions").toggle();
        $("#CrestwoodOptions").hide();
        $("#OtherReportsOptions").hide();
        $("#GLOTCEQOptions").hide();
        $("#NorthwindOptions").hide();
    });
});