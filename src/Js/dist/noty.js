!function(e,t){for(var n in t)e[n]=t[n]}(window,function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={i:o,l:!1,exports:{}};return e[o].call(r.exports,r,r.exports,n),r.l=!0,r.exports}return n.m=e,n.c=t,n.d=function(e,t,o){n.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:o})},n.r=function(e){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},n.t=function(e,t){if(1&t&&(e=n(e)),8&t)return e;if(4&t&&"object"==typeof e&&e&&e.__esModule)return e;var o=Object.create(null);if(n.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)n.d(o,r,function(t){return e[t]}.bind(null,r));return o},n.n=function(e){var t=e&&e.__esModule?function(){return e.default}:function(){return e};return n.d(t,"a",t),t},n.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},n.p="",n(n.s=3)}([function(e,t,n){"use strict";var o=this&&this.__awaiter||function(e,t,n,o){return new(n||(n=Promise))(function(r,i){function s(e){try{u(o.next(e))}catch(e){i(e)}}function a(e){try{u(o.throw(e))}catch(e){i(e)}}function u(e){e.done?r(e.value):new n(function(t){t(e.value)}).then(s,a)}u((o=o.apply(e,t||[])).next())})},r=this&&this.__generator||function(e,t){var n,o,r,i,s={label:0,sent:function(){if(1&r[0])throw r[1];return r[1]},trys:[],ops:[]};return i={next:a(0),throw:a(1),return:a(2)},"function"==typeof Symbol&&(i[Symbol.iterator]=function(){return this}),i;function a(i){return function(a){return function(i){if(n)throw new TypeError("Generator is already executing.");for(;s;)try{if(n=1,o&&(r=2&i[0]?o.return:i[0]?o.throw||((r=o.return)&&r.call(o),0):o.next)&&!(r=r.call(o,i[1])).done)return r;switch(o=0,r&&(i=[2&i[0],r.value]),i[0]){case 0:case 1:r=i;break;case 4:return s.label++,{value:i[1],done:!1};case 5:s.label++,o=i[1],i=[0];continue;case 7:i=s.ops.pop(),s.trys.pop();continue;default:if(!(r=(r=s.trys).length>0&&r[r.length-1])&&(6===i[0]||2===i[0])){s=0;continue}if(3===i[0]&&(!r||i[1]>r[0]&&i[1]<r[3])){s.label=i[1];break}if(6===i[0]&&s.label<r[1]){s.label=r[1],r=i;break}if(r&&s.label<r[2]){s.label=r[2],s.ops.push(i);break}r[2]&&s.ops.pop(),s.trys.pop();continue}i=t.call(e,s)}catch(e){i=[6,e],o=0}finally{n=r=0}if(5&i[0])throw i[1];return{value:i[0]?i[1]:void 0,done:!0}}([i,a])}}};Object.defineProperty(t,"__esModule",{value:!0}),n(1);var i=function(){function e(){this.options=null,this.fetchHeaderValue="Fetch"}return e.prototype.init=function(t){this.options=Object.assign({},e.defaults,t),this.options.disableAjaxToasts||(this.interceptXmlRequest(),this.interceptNativeFetch()),this.handleEvents()},e.prototype.ensureLibExists=function(){return!!this.libPresentAlready()||this.loadLibAsync()},e.prototype.libPresentAlready=function(){return void 0!==window[this.options.libraryDetails.varName]},e.prototype.loadLibAsync=function(){return Promise.all([this.loadStyleAsync(),this.loadScriptAsync()])},e.prototype.loadScriptAsync=function(){var e=this;return new Promise(function(t,n){if(e.options.libraryDetails.scriptSrc){var o=document.createElement("script");o.setAttribute("src",e.options.libraryDetails.scriptSrc),o.onload=function(){t()},o.onerror=function(e){n(e)},document.head.appendChild(o)}else t()})},e.prototype.loadStyleAsync=function(){var e=this;return new Promise(function(t,n){if(e.options.libraryDetails.scriptSrc){var o=document.createElement("link");o.setAttribute("rel","stylesheet"),o.type="text/css",o.href=e.options.libraryDetails.styleHref,o.onload=function(){t()},o.onerror=function(e){n(e)},document.head.appendChild(o)}else t()})},e.prototype.handleEvents=function(){document&&document.addEventListener(this.options.firstLoadEvent,this.domContentLoadedHandler.bind(this))},e.prototype.interceptNativeFetch=function(){var e=this,t=window.fetch;t&&(window.fetch=function(){var n=arguments[0];e.prepareRequestInfo(n);var o=arguments.length>1?arguments[1]:{};return e.prepareReuqestInit(o),t.apply(this,[n,o])})},e.prototype.prepareRequestInfo=function(e){e instanceof Request&&e.headers.append(this.options.requestHeaderKey,this.fetchHeaderValue)},e.prototype.prepareReuqestInit=function(e){if(e)if(e.headers)e.headers instanceof Headers?e.headers.set(this.options.requestHeaderKey,this.fetchHeaderValue):e.headers instanceof Object?e.headers[this.options.requestHeaderKey]=this.fetchHeaderValue:console.warn("NToastNotify header not set. Toast notification will not work");else{var t=new Headers;t.set(this.options.requestHeaderKey,this.fetchHeaderValue),e.headers=t}},e.prototype.getMessagesFromFetchResponse=function(e){var t=e.headers.get(this.options.responseHeaderKey);return t?JSON.parse(this.urlDecode(t)):null},e.prototype.interceptXmlRequest=function(){var e=this,t=XMLHttpRequest.prototype.send;XMLHttpRequest.prototype.send=function(){this.addEventListener("load",e.xmlRequestOnLoadHandler.bind(e,this)),t.apply(this,arguments)}},e.prototype.xmlRequestOnLoadHandler=function(e){var t=this.getMessagesFromXmlResponse(e);this.showMessages(t)},e.prototype.getMessagesFromXmlResponse=function(e){if(e.getAllResponseHeaders().indexOf(this.options.responseHeaderKey)>-1){var t=e.getResponseHeader(this.options.responseHeaderKey);if(t)return JSON.parse(this.urlDecode(t))}return null},e.prototype.domContentLoadedHandler=function(){return o(this,void 0,void 0,function(){return r(this,function(e){switch(e.label){case 0:return[4,this.ensureLibExists()];case 1:return e.sent(),this.overrideLibDefaults(),this.showMessages(this.options.messages),[2]}})})},e.prototype.showMessages=function(e){var t=this;e&&e.length&&e.forEach(function(e){t.showMessage(e)})},e.prototype.urlDecode=function(e){return decodeURIComponent(e.replace(/\+/g," "))},e}();t.NToastNotify=i},function(e,t){"function"!=typeof Object.assign&&Object.defineProperty(Object,"assign",{value:function(e){"use strict";if(null==e)throw new TypeError("Cannot convert undefined or null to object");for(var t=Object(e),n=1;n<arguments.length;n++){var o=arguments[n];if(null!=o)for(var r in o)Object.prototype.hasOwnProperty.call(o,r)&&(t[r]=o[r])}return t},writable:!0,configurable:!0})},,function(e,t,n){"use strict";var o,r=this&&this.__extends||(o=function(e,t){return(o=Object.setPrototypeOf||{__proto__:[]}instanceof Array&&function(e,t){e.__proto__=t}||function(e,t){for(var n in t)t.hasOwnProperty(n)&&(e[n]=t[n])})(e,t)},function(e,t){function n(){this.constructor=e}o(e,t),e.prototype=null===t?Object.create(t):(n.prototype=t.prototype,new n)});Object.defineProperty(t,"__esModule",{value:!0});var i=function(e){function t(){return null!==e&&e.apply(this,arguments)||this}return r(t,e),t.prototype.showMessage=function(e){var t=e.options;t.text=e.message,new Noty(t).show()},t.prototype.overrideLibDefaults=function(){this.options.libraryDetails.options&&Noty&&Noty.overrideDefaults(this.options.libraryDetails.options)},t}(n(0).NToastNotify);t.nToastNotify=new i}]));