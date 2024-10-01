var Windows;
(function (Windows) {
    var Devices;
    (function (Devices) {
        var Sensors;
        (function (Sensors) {
            var Magnetometer = /** @class */ (function () {
                function Magnetometer() {
                }
                Magnetometer.initialize = function () {
                    try {
                        if (typeof window.Magnetometer === "function") {
                            if (globalThis.DotnetExports !== undefined) {
                                this.dispatchReading = globalThis.DotnetExports.Uno.Windows.Devices.Sensors.Magnetometer.DispatchReading;
                            }
                            else {
                                throw "Unable to find dotnet exports";
                            }
                            var MagnetometerClass = window.Magnetometer;
                            this.magnetometer = new MagnetometerClass({ referenceFrame: 'device' });
                            return true;
                        }
                    }
                    catch (error) {
                        //sensor not available
                        console.log("Magnetometer could not be initialized.");
                    }
                    return false;
                };
                Magnetometer.startReading = function () {
                    this.magnetometer.addEventListener("reading", Magnetometer.readingChangedHandler);
                    this.magnetometer.start();
                };
                Magnetometer.stopReading = function () {
                    this.magnetometer.removeEventListener("reading", Magnetometer.readingChangedHandler);
                    this.magnetometer.stop();
                };
                Magnetometer.readingChangedHandler = function (event) {
                    Magnetometer.dispatchReading(Magnetometer.magnetometer.x, Magnetometer.magnetometer.y, Magnetometer.magnetometer.z);
                };
                return Magnetometer;
            }());
            Sensors.Magnetometer = Magnetometer;
        })(Sensors = Devices.Sensors || (Devices.Sensors = {}));
    })(Devices = Windows.Devices || (Windows.Devices = {}));
})(Windows || (Windows = {}));
//# sourceMappingURL=Magnetometer.js.map