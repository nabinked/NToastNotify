function genericToastNotify(message, options) {
    debugger;

    var top = 0;
    var lastOffset = null;
    var allObjects = $(".dx-toast-content");

    if (allObjects.length > 0) { /* If there is no toast object it fails to find offset and throws exception. */
        lastOffset = allObjects.last().offset();
    }

    if (lastOffset !== null) {
        top = lastOffset.top;
    }
    if (top <= 0)
        top = 20;
    else {
        top = window.innerHeight - top;
        top += 5;
    }

    DevExpress.ui.notify({
        message: message,
        type: options.type || "info",
        displayTime: options.displayTime || 10000,
        height: "auto",
        width: "auto",
        closeOnClick: true,
        hoverStateEnabled: true,
        minWidth: 500,
        position: {
            my: "bottom right",
            at: "bottom right",
            of: null,
            offset: "0 -" + top
        },
        animation: { show: { type: 'fade', duration: 400, from: 0, to: 1 }, hide: { type: 'fade', duration: 400, from: 1, to: 0 } }
        //animation: { show: { type: 'slide', duration: 200, from: { position: { my: 'right', at: 'left', of: window } } }, hide: { type: 'slide', duration: 200, to: { position: { my: 'top', at: 'bottom', of: window } } } }
    });

    //DevExpress.ui.notify(message, 'info', 1000);
}