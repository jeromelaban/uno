var Microsoft;
(function (Microsoft) {
    var UI;
    (function (UI) {
        var Xaml;
        (function (Xaml) {
            var Application = /** @class */ (function () {
                function Application() {
                }
                Application.observeVisibility = function () {
                    if (!Application.dispatchVisibilityChangeAsync) {
                        if (globalThis.DotnetExports !== undefined) {
                            Application.dispatchVisibilityChangeAsync = globalThis.DotnetExports.UnoUI.Microsoft.UI.Xaml.Application.DispatchVisibilityChangeAsync;
                        }
                        else {
                            throw "Unable to find dotnet exports";
                        }
                    }
                    if (document.onvisibilitychange !== undefined) {
                        document.addEventListener("visibilitychange", function () {
                            Application.dispatchVisibilityChangeAsync(document.visibilityState == "visible");
                        });
                    }
                    if (window.onpagehide !== undefined) {
                        window.addEventListener("pagehide", function () {
                            Application.dispatchVisibilityChangeAsync(false);
                        });
                    }
                    if (window.onpageshow !== undefined) {
                        window.addEventListener("pageshow", function () {
                            Application.dispatchVisibilityChangeAsync(true);
                        });
                    }
                };
                return Application;
            }());
            Xaml.Application = Application;
        })(Xaml = UI.Xaml || (UI.Xaml = {}));
    })(UI = Microsoft.UI || (Microsoft.UI = {}));
})(Microsoft || (Microsoft = {}));
//# sourceMappingURL=Application.js.map