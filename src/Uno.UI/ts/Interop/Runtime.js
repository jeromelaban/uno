var Uno;
(function (Uno) {
    var UI;
    (function (UI) {
        var Interop;
        (function (Interop) {
            var Runtime = /** @class */ (function () {
                function Runtime() {
                }
                Runtime.init = function () {
                    return "";
                };
                Runtime.InvokeJS = function (command) {
                    // Preseve the original emscripten marshalling semantics
                    // to always return a valid string.
                    return String(eval(command) || "");
                };
                Runtime.engine = Runtime.init();
                return Runtime;
            }());
            Interop.Runtime = Runtime;
        })(Interop = UI.Interop || (UI.Interop = {}));
    })(UI = Uno.UI || (Uno.UI = {}));
})(Uno || (Uno = {}));
function assert(x, message) {
    if (!x)
        throw new Error(message);
}
function warnOnce(a, msg) {
    var _a;
    if (!msg) {
        msg = a;
        a = false;
    }
    if (!a) {
        (_a = warnOnce).msgs || (_a.msgs = {});
        if (msg in warnOnce.msgs)
            return;
        warnOnce.msgs[msg] = true;
        console.warn(msg);
    }
}
// Copy of the stringToUTF8 function from the emscripten library
function stringToUTF8Array(str, heap, outIdx, maxBytesToWrite) {
    if (!(maxBytesToWrite > 0))
        return 0;
    var startIdx = outIdx;
    var endIdx = outIdx + maxBytesToWrite - 1;
    for (var i = 0; i < str.length; ++i) {
        var u = str.charCodeAt(i);
        if (u >= 55296 && u <= 57343) {
            var u1 = str.charCodeAt(++i);
            u = 65536 + ((u & 1023) << 10) | u1 & 1023;
        }
        if (u <= 127) {
            if (outIdx >= endIdx)
                break;
            heap[outIdx++] = u;
        }
        else if (u <= 2047) {
            if (outIdx + 1 >= endIdx)
                break;
            heap[outIdx++] = 192 | u >> 6;
            heap[outIdx++] = 128 | u & 63;
        }
        else if (u <= 65535) {
            if (outIdx + 2 >= endIdx)
                break;
            heap[outIdx++] = 224 | u >> 12;
            heap[outIdx++] = 128 | u >> 6 & 63;
            heap[outIdx++] = 128 | u & 63;
        }
        else {
            if (outIdx + 3 >= endIdx)
                break;
            if (u > 1114111)
                globalThis.warnOnce("Invalid Unicode code point " + globalThis.Module.ptrToString(u) + " encountered when serializing a JS string to a UTF-8 string in wasm memory! (Valid unicode code points should be in range 0-0x10FFFF).");
            heap[outIdx++] = 240 | u >> 18;
            heap[outIdx++] = 128 | u >> 12 & 63;
            heap[outIdx++] = 128 | u >> 6 & 63;
            heap[outIdx++] = 128 | u & 63;
        }
    }
    heap[outIdx] = 0;
    return outIdx - startIdx;
}
function stringToUTF8(str, outPtr, maxBytesToWrite) {
    assert(typeof maxBytesToWrite == "number", "stringToUTF8(str, outPtr, maxBytesToWrite) is missing the third parameter that specifies the length of the output buffer!");
    return stringToUTF8Array(str, Module.HEAPU8, outPtr, maxBytesToWrite);
}
globalThis.stringToUTF8 = stringToUTF8;
//# sourceMappingURL=Runtime.js.map