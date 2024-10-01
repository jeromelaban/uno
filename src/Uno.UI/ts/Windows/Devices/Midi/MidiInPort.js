var Windows;
(function (Windows) {
    var Devices;
    (function (Devices) {
        var Midi;
        (function (Midi) {
            var MidiInPort = /** @class */ (function () {
                function MidiInPort(managedId, inputPort) {
                    var _this = this;
                    this.messageReceived = function (event) {
                        var serializedMessage = event.data[0].toString();
                        for (var i = 1; i < event.data.length; i++) {
                            serializedMessage += ':' + event.data[i];
                        }
                        MidiInPort.dispatchMessage(_this.managedId, serializedMessage, event.timeStamp);
                    };
                    this.managedId = managedId;
                    this.inputPort = inputPort;
                }
                MidiInPort.createPort = function (managedId, encodedDeviceId) {
                    var midi = Uno.Devices.Midi.Internal.WasmMidiAccess.getMidi();
                    var deviceId = decodeURIComponent(encodedDeviceId);
                    var input = midi.inputs.get(deviceId);
                    MidiInPort.instanceMap[managedId] = new MidiInPort(managedId, input);
                };
                MidiInPort.removePort = function (managedId) {
                    MidiInPort.stopMessageListener(managedId);
                    delete MidiInPort.instanceMap[managedId];
                };
                MidiInPort.startMessageListener = function (managedId) {
                    if (!MidiInPort.dispatchMessage) {
                        if (globalThis.DotnetExports !== undefined) {
                            MidiInPort.dispatchMessage = globalThis.DotnetExports.Uno.Windows.Devices.Midi.MidiInPort.DispatchMessage;
                        }
                        else {
                            throw "Unable to find dotnet exports";
                        }
                    }
                    var instance = MidiInPort.instanceMap[managedId];
                    instance.inputPort.addEventListener("midimessage", instance.messageReceived);
                };
                MidiInPort.stopMessageListener = function (managedId) {
                    var instance = MidiInPort.instanceMap[managedId];
                    instance.inputPort.removeEventListener("midimessage", instance.messageReceived);
                };
                MidiInPort.instanceMap = {};
                return MidiInPort;
            }());
            Midi.MidiInPort = MidiInPort;
        })(Midi = Devices.Midi || (Devices.Midi = {}));
    })(Devices = Windows.Devices || (Windows.Devices = {}));
})(Windows || (Windows = {}));
//# sourceMappingURL=MidiInPort.js.map