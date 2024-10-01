var Windows;
(function (Windows) {
    var Phone;
    (function (Phone) {
        var Devices;
        (function (Devices) {
            var Notification;
            (function (Notification) {
                var VibrationDevice = /** @class */ (function () {
                    function VibrationDevice() {
                    }
                    VibrationDevice.initialize = function () {
                        navigator.vibrate = navigator.vibrate || navigator.webkitVibrate || navigator.mozVibrate || navigator.msVibrate;
                        if (navigator.vibrate) {
                            return true;
                        }
                        return false;
                    };
                    VibrationDevice.vibrate = function (duration) {
                        return window.navigator.vibrate(duration);
                    };
                    return VibrationDevice;
                }());
                Notification.VibrationDevice = VibrationDevice;
            })(Notification = Devices.Notification || (Devices.Notification = {}));
        })(Devices = Phone.Devices || (Phone.Devices = {}));
    })(Phone = Windows.Phone || (Windows.Phone = {}));
})(Windows || (Windows = {}));
//# sourceMappingURL=VibrationDevice.js.map