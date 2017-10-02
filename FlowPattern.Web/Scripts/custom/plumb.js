CyberzennoPlumb = function () {

    var allSystemParts = $("[data-system-part]");

   
    var connnections = getConnectionsFromPartsAttributes();

    //js plumb settings
    var common = {
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
            var outputs = part.dataset.output.split(" ");

            for (var j = 0; j < outputs; j++) {
                conn.push({ s: part.id, t: outputs[j] });
            }
        }

        return conn;
    }


    return {

        init: function () {


            jsPlumb.ready(function () {

                for (var i = 0; i < connnections.length; i++) {

                    jsPlumb.connect({
                        source: connnections[i].s,
                        target: connnections[i].t,
                    }, common);
                }

                for (var i = 0; i < allSystemParts.length; i++) {
                    jsPlumb.draggable(allSystemParts[i]);
                }

            });


        }

    }

}