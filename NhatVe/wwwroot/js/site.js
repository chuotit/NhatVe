// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $.ajax({
        url: 'https://www.bestprice.vn/ajax-search-flight-bp',
        type: 'get',
        data: {
            From: 'H%C3%A0+N%E1%BB%99i+%28HAN%29',
            From_Code: 'HAN',
            To: 'H%E1%BB%93+Ch%C3%AD+Minh+%28SGN%29',
            To_Code: 'SGN',
            Depart: '28%2F11%2F2018',
            Return: '',
            Type: 'oneway',
            ADT: 1,
            CHD: 0,
            INF: 0,
            is_domistic: 1,
            Airline: 'BL%2CVN%2CVJ',
            vnisc_sid: '15410098857b6bbdcd',
            previous_flights: '',
            flight_type: 'depart',
            previous_airline: '',
            time_first_call: '',
            airline_search: 'VJ'
        },
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert(response.status);
        },
        error: function () {
            alert("error");
        }
    });
});