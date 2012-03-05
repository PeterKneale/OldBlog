var config;

$(function () {
    // Perform Configuration
    config = {
        total:                  $("#Total"),
        time:                   $("#Time"),
        cars:                   $("#Cars"),
        randomCars:             $("#RandomCars"),
        RunSingleResultDemo:    $("#RunSingleResultDemo"),
        RunMultiResultDemo:     $("#RunMultiResultDemo")
    };

    // Bind the click on the link to the function
    config.RunSingleResultDemo.click(function () {
        PerformAjaxRequest($(this).data("url"), UpdateSingleDemoUi);
    });
    config.RunMultiResultDemo.click(function () {
        PerformAjaxRequest($(this).data("url"), UpdateMultiDemoUi);
    });
});

function PerformAjaxRequest(url, onSuccess) {
    // Makes a generic ajax GET request to an action that returns the new JsonDataResult
    $.ajax({
        type: "GET",
        cache: false, // this needed to stop IE caching the GET requests
        url: url,
        dataType: "json",
        success: function (data, textStatus, jqxhr) {
            // Call the onSoccess method method, passing the returned HtmlData and JsonData
            onSuccess(data.HtmlData, data.JsonData);
        },
        error: function (data, text, error) {
            alert("Error: " + error);
        }
    });
}

function UpdateSingleDemoUi(htmlData, jsonData) {
    // Update the UI with the data returned
    config.cars.html(htmlData);
    config.total.text(jsonData.Total);
    config.time.text(jsonData.Time);
}

function UpdateMultiDemoUi(htmlData, jsonData) {
    // Update the UI with the data returned
    config.cars.html(htmlData.All); // Note that the htmlData.key syntax is used.
    config.randomCars.html(htmlData.Random);
    config.total.text(jsonData.Total);
    config.time.text(jsonData.Time);
}
