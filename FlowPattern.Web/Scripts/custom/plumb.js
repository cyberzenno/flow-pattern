CyberzennoPlumb = function () {

    //PRE-REFACTORING NOTE:
    //this is why we need the Factory Pattern

    //setup jsplumb
    var connnections = [
        { s: "generator0", t: "switchA" },
        { s: "switchA", t: "bulbA" },
     
    ];
    var draggables = [
                        "generator0",
                        "switchA",
                        "bulbA",
                     ];

    var common = {
        anchor: ["Left", "Right"],
        endpoint: "Dot",
        paintStyle: { stroke: "gray", strokeWidth: 3 },
        endpointStyle: { fillStyle: "gray" },
        detachable: false,
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

                for (var i = 0; i < draggables.length; i++) {
                    jsPlumb.draggable(draggables[i]);
                }

            });


        }

    }

}