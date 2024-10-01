var Uno;
(function (Uno) {
    var Foundation;
    (function (Foundation) {
        var Interop;
        (function (Interop) {
            var ManagedObject = /** @class */ (function () {
                function ManagedObject() {
                }
                ManagedObject.init = function () {
                    var _a, _b, _c, _d, _e;
                    var exports = (_e = (_d = (_c = (_b = (_a = globalThis.DotnetExports) === null || _a === void 0 ? void 0 : _a.UnoFoundationRuntimeWebAssembly) === null || _b === void 0 ? void 0 : _b.Uno) === null || _c === void 0 ? void 0 : _c.Foundation) === null || _d === void 0 ? void 0 : _d.Interop) === null || _e === void 0 ? void 0 : _e.JSObject;
                    if (exports !== undefined) {
                        ManagedObject.dispatchMethod = exports.Dispatch;
                    }
                    else {
                        throw "Unable to find dotnet exports";
                    }
                };
                ManagedObject.dispatch = function (handle, method, parameters) {
                    if (!ManagedObject.dispatchMethod) {
                        ManagedObject.init();
                    }
                    ManagedObject.dispatchMethod(handle, method, parameters || "");
                };
                return ManagedObject;
            }());
            Interop.ManagedObject = ManagedObject;
        })(Interop = Foundation.Interop || (Foundation.Interop = {}));
    })(Foundation = Uno.Foundation || (Uno.Foundation = {}));
})(Uno || (Uno = {}));
//# sourceMappingURL=ManagedObject.js.map