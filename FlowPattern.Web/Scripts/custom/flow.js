/// <reference path="../jquery-3.1.1.intellisense.js" />
//Settings to have the Flow Pattern working
CyberzennoFlow = function (settings) {

    var custom_event = $.support.touch ? "tap" : "dblclick";

    function bindClick() {
        $("[data-system-part]").on(custom_event, function (e) {
            console.log(e.currentTarget.id)
            $.ajax({

                url: settings.executeActionUrl + "?_id=" + e.currentTarget.id + "&_action=toggle",
                success: function (data) {


                    for (var i = 0; i < data.length; i++) {

                        var item = data[i];

                        $("#" + item.Id).removeClass("active");
                        $("#" + item.Id).removeClass("activated");
                        $("#" + item.Id).addClass(item.ActiveCssClass);
                        $("#" + item.Id).addClass(item.ActivatedCssClass);

                        var color = item.ActiveCssClass == "active" && item.ActivatedCssClass == "activated" ? "green" : "gray";

                        updateConnector(item.Id, color);

                    }


                }

            });


        });
    }

    function updateConnectors() {
        var allSystemParts = $("[data-system-part]");

        for (var i = 0; i < allSystemParts.length; i++) {

            var part = allSystemParts[i];
            var outputs = part.dataset.output.match(/[^ ]+/g);

            if (outputs) {
                for (var j = 0; j < outputs.length; j++) {

                    var color = $(part).hasClass("active") && $(part).hasClass("activated") ? "green" : "gray";
                    updateConnector(part.id, color)

                }
            }

        }
    }

    function updateConnector(sId, color) {

        jsPlumb.select({ source: sId }).setPaintStyle({ stroke: color });
        var connections = jsPlumb.getConnections({ source: sId });

        for (var c in connections) {

            var connection = connections[c];
            if (connection) {
                for (var e in connection.endpoints) {
                    connection.endpoints[e].setPaintStyle({ fill: color });
                }
            }

        }

    }

    return {
        init: function () {
            bindClick();
        },
        updateConnectors: function () {
            updateConnectors();
        }
    }
}