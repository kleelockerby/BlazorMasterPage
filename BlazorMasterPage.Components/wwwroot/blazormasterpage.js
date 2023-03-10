if (!window.blazormasterpage) {
    window.blazormasterpage = {};
}

window.blazormasterpage = {
    utils: {
        getRequiredElement: (element, elementId) => {
            if (element)
                return element;

            return document.getElementById(elementId);
        }
    },

    // adds a classname to the specified element
    addClass: (element, classname) => {
        element.classList.add(classname);
        return true;
    },

    // removes a classname from the specified element
    removeClass: (element, classname) => {
        if (element.classList.contains(classname)) {
            element.classList.remove(classname);
        }
        return true;
    },

    // toggles a classname on the given element id
    toggleClass: (element, classname) => {
        if (element) {
            if (element.classList.contains(classname)) {
                element.classList.remove(classname);
            } else {
                element.classList.add(classname);
            }
        }
        return true;
    },

    // adds a classname to the body element
    addClassToBody: (classname) => {
        return blazormasterpage.addClass(document.body, classname);
    },

    // removes a classname from the body element
    removeClassFromBody: (classname) => {
        return blazormasterpage.removeClass(document.body, classname);
    },

    // indicates if parent node has a specified classname
    parentHasClass: (element, classname) => {
        if (element && element.parentElement) {
            return element.parentElement.classList.contains(classname);
        }
        return false;
    },

    // sets the value to the element property
    setProperty: (element, property, value) => {
        if (element && property) {
            element[property] = value;
        }
    },

    getElementInfo: (element, elementId) => {
        if (!element) {
            element = document.getElementById(elementId);
        }

        if (element) {
            const position = element.getBoundingClientRect();

            return {
                boundingClientRect: {
                    x: position.x,
                    y: position.y,
                    top: position.top,
                    bottom: position.bottom,
                    left: position.left,
                    right: position.right,
                    width: position.width,
                    height: position.height
                },
                offsetTop: element.offsetTop,
                offsetLeft: element.offsetLeft,
                offsetWidth: element.offsetWidth,
                offsetHeight: element.offsetHeight,
                scrollTop: element.scrollTop,
                scrollLeft: element.scrollLeft,
                scrollWidth: element.scrollWidth,
                scrollHeight: element.scrollHeight,
                clientTop: element.clientTop,
                clientLeft: element.clientLeft,
                clientWidth: element.clientWidth,
                clientHeight: element.clientHeight
            };
        }

        return {};
    },

    setTextValue(element, value) {
        element.value = value;
        return true;
    },

    hasSelectionCapabilities: (element) => {
        const nodeName = element && element.nodeName && element.nodeName.toLowerCase();

        return (
            nodeName &&
            ((nodeName === 'input' &&
                (element.type === 'text' ||
                    element.type === 'search' ||
                    element.type === 'tel' ||
                    element.type === 'url' ||
                    element.type === 'password')) ||
                nodeName === 'textarea' ||
                element.contentEditable === 'true')
        );
    },

    setCaret: (element, caret) => {
        if (window.blazormasterpage.hasSelectionCapabilities(element)) {
            window.requestAnimationFrame(() => {
                element.selectionStart = caret;
                element.selectionEnd = caret;
            });
        }
    },

    getCaret: (element) => {
        return window.blazormasterpage.hasSelectionCapabilities(element)
            ? element.selectionStart :
            -1;
    },

    getSelectedOptions: (elementId) => {
        const element = document.getElementById(elementId);
        const len = element.options.length;
        var opts = [], opt;

        for (var i = 0; i < len; i++) {
            opt = element.options[i];

            if (opt.selected) {
                opts.push(opt.value);
            }
        }

        return opts;
    },

    setSelectedOptions: (elementId, values) => {
        const element = document.getElementById(elementId);
        const len = element.options.length;

        for (var i = 0; i < len; i++) {
            const opt = element.options[i];

            if (values && values.find(x => x?.toString() === opt.value)) {
                opt.selected = true;
            } else {
                opt.selected = false;
            }
        }
    },

    // holds the list of components that are triggers to close other components
    closableComponents: [],

    addClosableComponent: (elementId, dotnetAdapter) => {
        window.blazormasterpage.closableComponents.push({ elementId: elementId, dotnetAdapter: dotnetAdapter });
    },

    findClosableComponent: (elementId) => {
        for (index = 0; index < window.blazormasterpage.closableComponents.length; ++index) {
            if (window.blazormasterpage.closableComponents[index].elementId === elementId)
                return window.blazormasterpage.closableComponents[index];
        }
        return null;
    },

    findClosableComponentIndex: (elementId) => {
        for (index = 0; index < window.blazormasterpage.closableComponents.length; ++index) {
            if (window.blazormasterpage.closableComponents[index].elementId === elementId)
                return index;
        }
        return -1;
    },

    isClosableComponent: (elementId) => {
        for (index = 0; index < window.blazormasterpage.closableComponents.length; ++index) {
            if (window.blazormasterpage.closableComponents[index].elementId === elementId)
                return true;
        }
        return false;
    },

    registerClosableComponent: (element, dotnetAdapter) => {
        if (element) {
            if (window.blazormasterpage.isClosableComponent(element.id) !== true) {
                window.blazormasterpage.addClosableComponent(element.id, dotnetAdapter);
            }
        }
    },

    unregisterClosableComponent: (element) => {
        if (element) {
            const index = window.blazormasterpage.findClosableComponentIndex(element.id);
            if (index !== -1) {
                window.blazormasterpage.closableComponents.splice(index, 1);
            }
        }
    },

    tryClose: (closable, targetElementId, isEscapeKey, isChildClicked) => {
        let request = new Promise((resolve, reject) => {
            closable.dotnetAdapter.invokeMethodAsync('SafeToClose', targetElementId, isEscapeKey ? 'escape' : 'leave', isChildClicked)
                .then((result) => resolve({ elementId: closable.elementId, dotnetAdapter: closable.dotnetAdapter, status: result === true ? 'ok' : 'cancelled' }))
                .catch(() => resolve({ elementId: closable.elementId, status: 'error' }));
        });

        if (request) {
            request
                .then((response) => {
                    if (response.status === 'ok') {
                        response.dotnetAdapter.invokeMethodAsync('Close', isEscapeKey ? 'escape' : 'leave')
                            // If the user navigates to another page then it will raise exception because the reference to the component cannot be found.
                            // In that case just remove the elementId from the list.
                            .catch(() => window.blazormasterpage.unregisterClosableComponent(response.elementId));
                    }
                });
        }
    },
    focus: (element, elementId, scrollToElement) => {
        element = window.blazormasterpage.utils.getRequiredElement(element, elementId);

        if (element) {
            element.focus({
                preventScroll: !scrollToElement
            });
        }

        return true;
    },
    tooltip: {
        initialize: (element, elementId) => {
            // implementation is in the providers
            return true;
        }
    },
    textEdit: {
        _instances: [],

        initialize: (element, elementId, maskType, editMask) => {
            var instances = window.blazormasterpage.textEdit._instances = window.blazormasterpage.textEdit._instances || {};

            if (maskType === "numeric") {
                instances[elementId] = new window.blazormasterpage.NumericMaskValidator(element, elementId);
            }
            else if (maskType === "datetime") {
                instances[elementId] = new window.blazormasterpage.DateTimeMaskValidator(element, elementId);
            }
            else if (maskType === "regex") {
                instances[elementId] = new window.blazormasterpage.RegExMaskValidator(element, elementId, editMask);
            }
            else {
                instances[elementId] = new window.blazormasterpage.NoValidator();
            }

            element.addEventListener("keypress", (e) => {
                window.blazormasterpage.textEdit.keyPress(instances[elementId], e);
            });

            element.addEventListener("paste", (e) => {
                window.blazormasterpage.textEdit.paste(instances[elementId], e);
            });

            return true;
        },
        destroy: (element, elementId) => {
            var instances = window.blazormasterpage.textEdit._instances || {};
            delete instances[elementId];
            return true;
        },
        keyPress: (validator, e) => {
            var currentValue = String.fromCharCode(e.which);

            return validator.isValid(currentValue) || e.preventDefault();
        },
        paste: (validator, e) => {
            return validator.isValid(e.clipboardData.getData("text/plain")) || e.preventDefault();
        }
    },
    numericEdit: {
        _instances: [],

        initialize: (dotnetAdapter, element, elementId, decimals, separator, step, min, max) => {
            window.blazormasterpage.numericEdit._instances[elementId] = new window.blazormasterpage.NumericMaskValidator(dotnetAdapter, element, elementId, decimals, separator, step, min, max);

            element.addEventListener("keypress", (e) => {
                window.blazormasterpage.numericEdit.keyPress(window.blazormasterpage.numericEdit._instances[elementId], e);
            });

            element.addEventListener("keydown", (e) => {
                window.blazormasterpage.numericEdit.keyDown(window.blazormasterpage.numericEdit._instances[elementId], e);
            });

            element.addEventListener("paste", (e) => {
                window.blazormasterpage.numericEdit.paste(window.blazormasterpage.numericEdit._instances[elementId], e);
            });
            return true;
        },
        destroy: (element, elementId) => {
            var instances = window.blazormasterpage.numericEdit._instances || {};
            delete instances[elementId];
            return true;
        },
        keyDown: (validator, e) => {
            if (e.which === 38) {
                validator.stepApply(1);
            } else if (e.which === 40) {
                validator.stepApply(-1);
            }
            return true;
        },
        keyPress: (validator, e) => {
            var currentValue = String.fromCharCode(e.which);

            return e.which === 13 // still need to allow ENTER key so that we don't preventDefault on form submit
                || validator.isValid(currentValue)
                || e.preventDefault();
        },
        paste: (validator, e) => {
            return validator.isValid(e.clipboardData.getData("text/plain")) || e.preventDefault();
        }
    },
    NoValidator: function () {
        this.isValid = function (currentValue) {
            return true;
        };
    },
    NumericMaskValidator: function (dotnetAdapter, element, elementId, decimals, separator, step, min, max) {
        this.dotnetAdapter = dotnetAdapter;
        this.elementId = elementId;
        this.element = element;
        this.decimals = decimals === null || decimals === undefined ? 2 : decimals;
        this.separator = separator || ".";
        this.step = step || 1;
        this.min = min;
        this.max = max;
        this.regex = function () {
            var sep = "\\" + this.separator,
                dec = this.decimals,
                reg = "{0," + dec + "}";

            return dec ? new RegExp("^(-)?(((\\d+(" + sep + "\\d" + reg + ")?)|(" + sep + "\\d" + reg + ")))?$") : /^(-)?(\d*)$/;
        };
        this.carret = function () {
            return [this.element.selectionStart, this.element.selectionEnd];
        };
        this.isValid = function (currentValue) {
            var value = this.element.value,
                selection = this.carret();

            if (value = value.substring(0, selection[0]) + currentValue + value.substring(selection[1]), !!this.regex().test(value)) {
                return value = (value || "").replace(this.separator, ".");
            }

            return false;
        };
        this.stepApply = function (sign) {
            var value = (this.element.value || "").replace(this.separator, ".");
            var number = Number(value) + this.step * sign;

            if (number >= this.min && number <= this.max) {
                var newValue = number.toString().replace(".", this.separator);
                this.element.value = newValue;
                this.dotnetAdapter.invokeMethodAsync('SetValue', newValue);
            }
        };
    },
    DateTimeMaskValidator: function (element, elementId) {
        this.elementId = elementId;
        this.element = element;
        this.regex = function () {
            return /^\d{0,4}$|^\d{4}-0?$|^\d{4}-(?:0?[1-9]|1[012])(?:-(?:0?[1-9]?|[12]\d|3[01])?)?$/;
        };
        this.carret = function () {
            return [this.element.selectionStart, this.element.selectionEnd];
        };
        this.isValid = function (currentValue) {
            var value = this.element.value,
                selection = this.carret();

            return value = value.substring(0, selection[0]) + currentValue + value.substring(selection[1]), !!this.regex().test(value);
        };
    },
    RegExMaskValidator: function (element, elementId, editMask) {
        this.elementId = elementId;
        this.element = element;
        this.editMask = editMask;
        this.regex = function () {
            return new RegExp(this.editMask);
        };
        this.carret = function () {
            return [this.element.selectionStart, this.element.selectionEnd];
        };
        this.isValid = function (currentValue) {
            var value = this.element.value,
                selection = this.carret();

            return value = value.substring(0, selection[0]) + currentValue + value.substring(selection[1]), !!this.regex().test(value);
        };
    },
    button: {
        _instances: [],

        initialize: (element, elementId, preventDefaultOnSubmit) => {
            window.blazormasterpage.button._instances[elementId] = new window.blazormasterpage.ButtonInfo(element, elementId, preventDefaultOnSubmit);

            if (element.type === "submit") {
                element.addEventListener("click", (e) => {
                    window.blazormasterpage.button.click(window.blazormasterpage.button._instances[elementId], e);
                });
            }

            return true;
        },
        destroy: (elementId) => {
            var instances = window.blazormasterpage.button._instances || {};
            delete instances[elementId];
            return true;
        },
        click: (buttonInfo, e) => {
            if (buttonInfo.preventDefaultOnSubmit) {
                return e.preventDefault();
            }
        }
    },
    ButtonInfo: function (element, elementId, preventDefaultOnSubmit) {
        this.elementId = elementId;
        this.element = element;
        this.preventDefaultOnSubmit = preventDefaultOnSubmit;
    },
    link: {
        scrollIntoView: (elementId) => {
            var element = document.getElementById(elementId);

            if (element) {
                element.scrollIntoView();
                window.location.hash = elementId;
            }

            return true;
        }
    },
    fileEdit: {
        _instances: [],

        initialize: (adapter, element, elementId) => {
            var nextFileId = 0;

            // save an instance of adapter
            window.blazormasterpage.fileEdit._instances[elementId] = new window.blazormasterpage.FileEditInfo(adapter, element, elementId);

            element.addEventListener('change', function handleInputFileChange(event) {
                // Reduce to purely serializable data, plus build an index by ID
                element._blazorFilesById = {};
                var fileList = Array.prototype.map.call(element.files, function (file) {
                    var result = {
                        id: ++nextFileId,
                        lastModified: new Date(file.lastModified).toISOString(),
                        name: file.name,
                        size: file.size,
                        type: file.type
                    };
                    element._blazorFilesById[result.id] = result;

                    // Attach the blob data itself as a non-enumerable property so it doesn't appear in the JSON
                    Object.defineProperty(result, 'blob', { value: file });

                    return result;
                });

                adapter.invokeMethodAsync('NotifyChange', fileList).then(null, function (err) {
                    throw new Error(err);
                });
            });

            return true;
        },
        destroy: (element, elementId) => {
            var instances = window.blazormasterpage.fileEdit._instances || {};
            delete instances[elementId];
            return true;
        },

        reset: (element, elementId) => {
            if (element) {
                element.value = '';

                var fileEditInfo = window.blazormasterpage.fileEdit._instances[elementId];

                if (fileEditInfo) {
                    fileEditInfo.adapter.invokeMethodAsync('NotifyChange', []).then(null, function (err) {
                        throw new Error(err);
                    });
                }
            }

            return true;
        },

        readFileData: function readFileData(element, fileEntryId, position, length) {
            var readPromise = getArrayBufferFromFileAsync(element, fileEntryId);

            return readPromise.then(function (arrayBuffer) {
                var uint8Array = new Uint8Array(arrayBuffer, position, length);
                var base64 = uint8ToBase64(uint8Array);
                return base64;
            });
        },

        ensureArrayBufferReadyForSharedMemoryInterop: function ensureArrayBufferReadyForSharedMemoryInterop(elem, fileId) {
            return getArrayBufferFromFileAsync(elem, fileId).then(function (arrayBuffer) {
                getFileById(elem, fileId).arrayBuffer = arrayBuffer;
            });
        },

        readFileDataSharedMemory: function readFileDataSharedMemory(readRequest) {
            // This uses various unsupported internal APIs. Beware that if you also use them,
            // your code could become broken by any update.
            var inputFileElementReferenceId = Blazor.platform.readStringField(readRequest, 0);
            var inputFileElement = document.querySelector('[_bl_' + inputFileElementReferenceId + ']');
            var fileId = Blazor.platform.readInt32Field(readRequest, 4);
            var sourceOffset = Blazor.platform.readUint64Field(readRequest, 8);
            var destination = Blazor.platform.readInt32Field(readRequest, 16);
            var destinationOffset = Blazor.platform.readInt32Field(readRequest, 20);
            var maxBytes = Blazor.platform.readInt32Field(readRequest, 24);

            var sourceArrayBuffer = getFileById(inputFileElement, fileId).arrayBuffer;
            var bytesToRead = Math.min(maxBytes, sourceArrayBuffer.byteLength - sourceOffset);
            var sourceUint8Array = new Uint8Array(sourceArrayBuffer, sourceOffset, bytesToRead);

            var destinationUint8Array = Blazor.platform.toUint8Array(destination);
            destinationUint8Array.set(sourceUint8Array, destinationOffset);

            return bytesToRead;
        },
        open: (element, elementId) => {
            if (!element && elementId) {
                element = document.getElementById(elementId);
            }

            if (element) {
                element.click();
            }
        }
    },

    FileEditInfo: function (adapter, element, elementId) {
        this.adapter = adapter;
        this.element = element;
        this.elementId = elementId;
    },

    breakpoint: {
        // Get the current breakpoint
        getBreakpoint: function () {
            return window.getComputedStyle(document.body, ':before').content.replace(/\"/g, '');
        },

        // holds the list of components that are triggers to breakpoint
        breakpointComponents: [],

        lastBreakpoint: null,

        addBreakpointComponent: (elementId, dotnetAdapter) => {
            window.blazormasterpage.breakpoint.breakpointComponents.push({ elementId: elementId, dotnetAdapter: dotnetAdapter });
        },

        findBreakpointComponentIndex: (elementId) => {
            for (index = 0; index < window.blazormasterpage.breakpoint.breakpointComponents.length; ++index) {
                if (window.blazormasterpage.breakpoint.breakpointComponents[index].elementId === elementId)
                    return index;
            }
            return -1;
        },

        isBreakpointComponent: (elementId) => {
            for (index = 0; index < window.blazormasterpage.breakpoint.breakpointComponents.length; ++index) {
                if (window.blazormasterpage.breakpoint.breakpointComponents[index].elementId === elementId)
                    return true;
            }
            return false;
        },

        registerBreakpointComponent: (elementId, dotnetAdapter) => {
            if (window.blazormasterpage.breakpoint.isBreakpointComponent(elementId) !== true) {
                window.blazormasterpage.breakpoint.addBreakpointComponent(elementId, dotnetAdapter);
            }
        },

        unregisterBreakpointComponent: (elementId) => {
            const index = window.blazormasterpage.breakpoint.findBreakpointComponentIndex(elementId);
            if (index !== -1) {
                window.blazormasterpage.breakpoint.breakpointComponents.splice(index, 1);
            }
        },

        onBreakpoint: (dotnetAdapter, currentBreakpoint) => {
            dotnetAdapter.invokeMethodAsync('OnBreakpoint', currentBreakpoint);
        }
    }
};

document.addEventListener('click', function handler(evt) {
    if (window.blazormasterpage.closableComponents && window.blazormasterpage.closableComponents.length > 0) {
        const lastClosable = window.blazormasterpage.closableComponents[window.blazormasterpage.closableComponents.length - 1];

        if (lastClosable) {
            window.blazormasterpage.tryClose(lastClosable, evt.target.id, false, hasParentInTree(evt.target, lastClosable.elementId));
        }
    }
});

document.addEventListener('keyup', function handler(evt) {
    if (evt.keyCode === 27 && window.blazormasterpage.closableComponents && window.blazormasterpage.closableComponents.length > 0) {
        const lastClosable = window.blazormasterpage.closableComponents[window.blazormasterpage.closableComponents.length - 1];

        if (lastClosable) {
            window.blazormasterpage.tryClose(lastClosable, lastClosable.elementId, true, false);
        }
    }
});

// Recalculate breakpoint on resize
window.addEventListener('resize', function () {
    if (window.blazormasterpage.breakpoint.breakpointComponents && window.blazormasterpage.breakpoint.breakpointComponents.length > 0) {
        var currentBreakpoint = window.blazormasterpage.breakpoint.getBreakpoint();

        if (window.blazormasterpage.breakpoint.lastBreakpoint !== currentBreakpoint) {
            window.blazormasterpage.breakpoint.lastBreakpoint = currentBreakpoint;

            for (index = 0; index < window.blazormasterpage.breakpoint.breakpointComponents.length; ++index) {
                window.blazormasterpage.breakpoint.onBreakpoint(window.blazormasterpage.breakpoint.breakpointComponents[index].dotnetAdapter, currentBreakpoint);
            }
        }
    }
});

// Set initial breakpoint
window.blazormasterpage.breakpoint.lastBreakpoint = window.blazormasterpage.breakpoint.getBreakpoint();

function showPopper(element, tooltip, arrow, placement) {
    var thePopper = new Popper(element, tooltip,
        {
            placement,
            modifiers: {
                offset: {
                    offset: 0
                },
                flip: {
                    behavior: "flip"
                },
                arrow: {
                    element: arrow,
                    enabled: true
                },
                preventOverflow: {
                    boundary: "scrollParent"
                }

            }
        }
    );
    return thePopper;
}

function getFileById(elem, fileId) {
    var file = elem._blazorFilesById[fileId];
    if (!file) {
        throw new Error('There is no file with ID ' + fileId + '. The file list may have changed');
    }

    return file;
}

function getArrayBufferFromFileAsync(elem, fileId) {
    var file = getFileById(elem, fileId);

    // On the first read, convert the FileReader into a Promise<ArrayBuffer>
    if (!file.readPromise) {
        file.readPromise = new Promise(function (resolve, reject) {
            var reader = new FileReader();
            reader.onload = function () { resolve(reader.result); };
            reader.onerror = function (err) { reject(err); };
            reader.readAsArrayBuffer(file.blob);
        });
    }

    return file.readPromise;
}

function hasParentInTree(element, parentElementId) {
    if (!element.parentElement) return false;
    if (element.parentElement.id === parentElementId) return true;
    return hasParentInTree(element.parentElement, parentElementId);
}

var uint8ToBase64 = (function () {
    // Code from https://github.com/beatgammit/base64-js/
    // License: MIT
    var lookup = [];

    var code = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
    for (var i = 0, len = code.length; i < len; ++i) {
        lookup[i] = code[i];
    }

    function tripletToBase64(num) {
        return lookup[num >> 18 & 0x3F] +
            lookup[num >> 12 & 0x3F] +
            lookup[num >> 6 & 0x3F] +
            lookup[num & 0x3F];
    }

    function encodeChunk(uint8, start, end) {
        var tmp;
        var output = [];
        for (var i = start; i < end; i += 3) {
            tmp =
                ((uint8[i] << 16) & 0xFF0000) +
                ((uint8[i + 1] << 8) & 0xFF00) +
                (uint8[i + 2] & 0xFF);
            output.push(tripletToBase64(tmp));
        }
        return output.join('');
    }

    return function fromByteArray(uint8) {
        var tmp;
        var len = uint8.length;
        var extraBytes = len % 3; // if we have 1 byte left, pad 2 bytes
        var parts = [];
        var maxChunkLength = 16383; // must be multiple of 3

        // go through the array every three bytes, we'll deal with trailing stuff later
        for (var i = 0, len2 = len - extraBytes; i < len2; i += maxChunkLength) {
            parts.push(encodeChunk(
                uint8, i, (i + maxChunkLength) > len2 ? len2 : (i + maxChunkLength)
            ));
        }

        // pad the end with zeros, but make sure to not forget the extra bytes
        if (extraBytes === 1) {
            tmp = uint8[len - 1];
            parts.push(
                lookup[tmp >> 2] +
                lookup[(tmp << 4) & 0x3F] +
                '=='
            );
        } else if (extraBytes === 2) {
            tmp = (uint8[len - 2] << 8) + uint8[len - 1];
            parts.push(
                lookup[tmp >> 10] +
                lookup[(tmp >> 4) & 0x3F] +
                lookup[(tmp << 2) & 0x3F] +
                '='
            );
        }

        return parts.join('');
    };
})();