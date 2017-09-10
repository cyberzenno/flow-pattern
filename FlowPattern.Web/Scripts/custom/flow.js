CyberzennoFlow = function (settings) {

    function bindClick() {
        $("[data-system-part]").click(function (e) {
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

                        updateConnector(item.Id, null, color);

                    }


                }

            });


        });
    }

    function updateConnector(tId, sId, color) {

        jsPlumb.select({ source: tId }).setPaintStyle({ stroke: color });
        jsPlumb.selectEndpoints({ element: tId }).setPaintStyle({ fill: color });
        //jsPlumb.selectEndpoints({ element: sId }).setPaintStyle({ fill: color });

    }

    return {
        init: function () {

            bindClick();
        }
    }
}