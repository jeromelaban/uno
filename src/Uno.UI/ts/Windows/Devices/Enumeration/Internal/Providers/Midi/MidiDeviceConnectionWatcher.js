var Uno;
(function (Uno) {
    var Devices;
    (function (Devices) {
        var Enumeration;
        (function (Enumeration) {
            var Internal;
            (function (Internal) {
                var Providers;
                (function (Providers) {
                    var Midi;
                    (function (Midi) {
                        var MidiDeviceConnectionWatcher = /** @class */ (function () {
                            function MidiDeviceConnectionWatcher() {
                            }
                            MidiDeviceConnectionWatcher.startStateChanged = function () {
                                var midi = Uno.Devices.Midi.Internal.WasmMidiAccess.getMidi();
                                midi.addEventListener("statechange", MidiDeviceConnectionWatcher.onStateChanged);
                            };
                            MidiDeviceConnectionWatcher.stopStateChanged = function () {
                                var midi = Uno.Devices.Midi.Internal.WasmMidiAccess.getMidi();
                                midi.removeEventListener("statechange", MidiDeviceConnectionWatcher.onStateChanged);
                            };
                            MidiDeviceConnectionWatcher.onStateChanged = function (event) {
                                if (!MidiDeviceConnectionWatcher.dispatchStateChanged) {
                                    if (globalThis.DotnetExports !== undefined) {
                                        MidiDeviceConnectionWatcher.dispatchStateChanged = globalThis.DotnetExports.Uno.Uno.Devices.Enumeration.Internal.Providers.Midi.MidiDeviceConnectionWatcher.DispatchStateChanged;
                                    }
                                    else {
                                        throw "Unable to find dotnet exports";
                                    }
                                }
                                var port = event.port;
                                var isInput = port.type == "input";
                                var isConnected = port.state == "connected";
                                MidiDeviceConnectionWatcher.dispatchStateChanged(port.id, port.name, isInput, isConnected);
                            };
                            return MidiDeviceConnectionWatcher;
                        }());
                        Midi.MidiDeviceConnectionWatcher = MidiDeviceConnectionWatcher;
                    })(Midi = Providers.Midi || (Providers.Midi = {}));
                })(Providers = Internal.Providers || (Internal.Providers = {}));
            })(Internal = Enumeration.Internal || (Enumeration.Internal = {}));
        })(Enumeration = Devices.Enumeration || (Devices.Enumeration = {}));
    })(Devices = Uno.Devices || (Uno.Devices = {}));
})(Uno || (Uno = {}));
//# sourceMappingURL=MidiDeviceConnectionWatcher.js.map