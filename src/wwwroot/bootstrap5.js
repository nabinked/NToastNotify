const nToastNotify = {

    showToast(message) {

        let template = document.getElementById(message.options["templateId"]);
        var bootstrapToastContainer = document.getElementById(message.options["containerId"]);

        let bootstrapToast = template.content.querySelector(".toast").cloneNode(true);
        bootstrapToast.classList.add(`bg-${message.options["type"]}`);

        let toastBody = bootstrapToast.querySelector(".toast-body");
        toastBody.textContent = message.message;

        bootstrapToastContainer.appendChild(bootstrapToast);

        var toast = new bootstrap.Toast(bootstrapToast);

        if (!document.body.classList.contains("position-class-done")) {
            bootstrapToastContainer.setAttribute("class", bootstrapToastContainer.getAttribute("class") + " " + message.options["positionClass"]);
            bootstrapToastContainer.classList.add("position-class-done");
        }

        toast.show();
    },

    addToastContainerIfMissing(containerId) {
        let bootstrapToastContainer = document.getElementById(containerId);
        if (bootstrapToastContainer == null) {
            let body = document.getElementsByTagName('body')[0];
            let markup = `<div class="toast-container position-absolute p-3" id="${containerId}"></div>`
            body.innerHTML += markup;
        }
    },

    addToastTemplateIfMissing(templateId) {
        let bootstrapToastTemplate = document.getElementById(templateId);
        if (bootstrapToastTemplate == null) {
            let body = document.getElementsByTagName('body')[0];
            let markup =
                `<template id="${templateId}">
                    <div class="toast align-items-center text-white bg-primary border-0" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="d-flex">
                            <div class="toast-body"></div>
                            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                        </div>
                    </div>
                </template>`
            body.innerHTML += markup;
        }
    },

    init(inputFromServer) {

        let first = true;
        if (inputFromServer.messages.length != 0) {
            for (var i in inputFromServer.messages) {
                let message = inputFromServer.messages[i];
                if (first) {
                    this.addToastContainerIfMissing(message.options["containerId"]);
                    this.addToastTemplateIfMissing(message.options["templateId"])
                    first = false;
                }

                this.showToast(message)
            }
        }
    },
};