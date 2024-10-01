var Uno;
(function (Uno) {
    var Utils;
    (function (Utils) {
        var Guid = /** @class */ (function () {
            function Guid() {
            }
            Guid.NewGuid = function () {
                if (!Guid.newGuidMethod) {
                    Guid.newGuidMethod = Module.mono_bind_static_method("[mscorlib] System.Guid:NewGuid");
                }
                return Guid.newGuidMethod();
            };
            return Guid;
        }());
        Utils.Guid = Guid;
    })(Utils = Uno.Utils || (Uno.Utils = {}));
})(Uno || (Uno = {}));
//# sourceMappingURL=Guid.js.map