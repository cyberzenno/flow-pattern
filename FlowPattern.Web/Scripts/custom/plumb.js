CyberzennoPlumb = function () {

    var allSystemParts = $("[data-system-part]");

    var connections = getConnectionsFromPartsAttributes();

    var jsPlumbSettings = {
        anchor: ["Left", "Right"],
        endpoint: "Dot",
        paintStyle: { stroke: "gray", strokeWidth: 3 },
        endpointStyle: { fillStyle: "gray" },
        detachable: false,
    }

    //some private utilities
    function getConnectionsFromPartsAttributes() {

        var conn = [];

        for (var i = 0; i < allSystemParts.length; i++) {

            var part = allSystemParts[i];
            var outputs = part.dataset.output.match(/[^ ]+/g);

            if (outputs) {
                for (var j = 0; j < outputs.length; j++) {
                    conn.push({ s: part.id, t: outputs[j] });
                }
            }

        }

        return conn;
    }


    return {

        init: function () {

            jsPlumb.ready(function () {

                for (var i = 0; i < connections.length; i++) {

                    jsPlumb.connect({
                        source: connections[i].s,
                        target: connections[i].t,
                    }, jsPlumbSettings);
                }

                for (var i = 0; i < allSystemParts.length; i++) {
                    jsPlumb.draggable(allSystemParts[i]);
                }

            });

        }

    }

}