var nToastNotify =
/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
__webpack_require__(1);
var libToastr = {
    options: null,
    fetchHeaderValue: 'Fetch',
    init: function (options) {
        this.options = Object.assign({}, this.defaults, options);
        this.handleEvents();
        this.interceptXmlRequest();
        this.interceptNativeFetch();
    },
    isToastrLibLoaded: function () {
        return typeof toastr !== 'undefined';
    },
    loadLib: function () {
        this.loadScript();
    },
    loadScript: function () {
        var _this = this;
        var script = document.createElement('script');
        script.setAttribute('src', this.options.tostrLibCdnSrcScript);
        script.onload = function (e) {
            _this.init(_this.options);
        };
        document.head.appendChild(script);
    },
    handleEvents: function () {
        document && document.addEventListener('DOMContentLoaded', this.domContentLoadedHandler.bind(this));
    },
    getResponseHeaderKey: function () {
        return this.options.responseHeaderKey;
    },
    interceptNativeFetch: function () {
        var self = this;
        var oldFetch = window.fetch;
        if (oldFetch) {
            window.fetch = function () {
                var input = arguments[0];
                self.prepareRequestInfo(input);
                var init = arguments.length > 1 ? arguments[1] : {};
                self.prepareReuqestInit(init);
                return oldFetch.apply(this, [input, init]);
            };
        }
    },
    prepareRequestInfo: function (input) {
        if (input instanceof Request) {
            input.headers.append(this.options.requestHeaderKey, this.fetchHeaderValue);
        }
    },
    prepareReuqestInit: function (init) {
        if (init) {
            //if headers is not defined yet. define one
            if (!init.headers) {
                var newHeaders = new Headers();
                newHeaders.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                init.headers = newHeaders;
            }
            else {
                if (init.headers instanceof Headers) {
                    init.headers.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                }
                else if (init.headers instanceof Object) {
                    init.headers[this.options.requestHeaderKey] = this.fetchHeaderValue;
                }
                else {
                    console.warn('NToastNotify header not set. Toast notification will not work');
                }
            }
        }
    },
    interceptXmlRequest: function () {
        var self = this;
        // store the native send()
        var oldSend = XMLHttpRequest.prototype.send;
        // override the native send()
        XMLHttpRequest.prototype.send = function () {
            this.setRequestHeader(self.options.requestHeaderKey, 'XMLHttpRequest');
            // process the callback queue
            this.onload = self.xmlRequestOnLoadHandler.bind(self, this);
            // call the native send()
            oldSend.apply(this, arguments);
        };
    },
    xmlRequestOnLoadHandler: function (xmlHttpRequest) {
        var messages = this.xmlGetMessagesFromResponse(xmlHttpRequest);
        this.showToasts(messages);
    },
    xmlGetMessagesFromResponse: function (xmlHttpRequest) {
        var messagesStr = xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey);
        if (messagesStr) {
            return JSON.parse(messagesStr);
        }
        return null;
    },
    fetchGetMessagesFromResponse: function (response) {
        var messageStr = response.headers.get(this.options.responseHeaderKey);
        if (messageStr) {
            return JSON.parse(messageStr);
        }
        else {
            return null;
        }
    },
    domContentLoadedHandler: function () {
        if (toastr) {
            toastr.options = this.options.globalToastMessageOptions;
            this.showToasts(this.options.messages);
        }
    },
    showToasts: function (messages) {
        var _this = this;
        if (messages && messages.length) {
            messages.forEach(function (message, index, array) {
                _this.show(message);
            });
        }
    },
    show: function (message) {
        var args = [];
        args.push(message.message);
        args.push(message.title);
        if (message.toastOptions) {
            args.push(message.toastOptions);
        }
        toastr[message.toastType.toLowerCase()].apply(toastr, args);
    },
    defaults: {
        firstLoadEvent: 'DOMContentLoaded',
        globalToastMessageOptions: null,
        messages: [],
        responseHeaderKey: 'NToastNotify-Messages',
        requestHeaderKey: 'NToastNotify-Request-Type',
        tostrLibCdnSrcScript: 'https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js'
    }
};
exports.toastr = libToastr;


/***/ }),
/* 1 */
/***/ (function(module, exports) {

if (typeof Object.assign != 'function') {
    // Must be writable: true, enumerable: false, configurable: true
    Object.defineProperty(Object, 'assign', {
        value: function (target) {
            'use strict';
            if (target == null) {
                throw new TypeError('Cannot convert undefined or null to object');
            }
            var to = Object(target);
            for (var index = 1; index < arguments.length; index++) {
                var nextSource = arguments[index];
                if (nextSource != null) {
                    for (var nextKey in nextSource) {
                        // Avoid bugs when hasOwnProperty is shadowed
                        if (Object.prototype.hasOwnProperty.call(nextSource, nextKey)) {
                            to[nextKey] = nextSource[nextKey];
                        }
                    }
                }
            }
            return to;
        },
        writable: true,
        configurable: true
    });
}


/***/ })
/******/ ]);
//# sourceMappingURL=toastr.js.map