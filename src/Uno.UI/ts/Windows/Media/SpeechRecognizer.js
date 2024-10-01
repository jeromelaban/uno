var Windows;
(function (Windows) {
    var Media;
    (function (Media) {
        var SpeechRecognizer = /** @class */ (function () {
            function SpeechRecognizer(managedId, culture) {
                var _this = this;
                this.onResult = function (event) {
                    if (event.results[0].isFinal) {
                        if (!SpeechRecognizer.dispatchResult) {
                            if (globalThis.DotnetExports !== undefined) {
                                SpeechRecognizer.dispatchResult = globalThis.DotnetExports.Uno.Windows.Media.SpeechRecognition.SpeechRecognizer.DispatchResult;
                            }
                            else {
                                throw "Unable to find dotnet exports";
                            }
                        }
                        SpeechRecognizer.dispatchResult(_this.managedId, event.results[0][0].transcript, event.results[0][0].confidence);
                    }
                    else {
                        if (!SpeechRecognizer.dispatchHypothesis) {
                            if (globalThis.DotnetExports !== undefined) {
                                SpeechRecognizer.dispatchHypothesis = globalThis.DotnetExports.Uno.Windows.Media.SpeechRecognition.SpeechRecognizer.DispatchHypothesis;
                            }
                            else {
                                throw "Unable to find dotnet exports";
                            }
                        }
                        SpeechRecognizer.dispatchHypothesis(_this.managedId, event.results[0][0].transcript);
                    }
                };
                this.onSpeechStart = function () {
                    if (!SpeechRecognizer.dispatchStatus) {
                        if (globalThis.DotnetExports !== undefined) {
                            SpeechRecognizer.dispatchStatus = globalThis.DotnetExports.Uno.Windows.Media.SpeechRecognition.SpeechRecognizer.DispatchStatus;
                        }
                        else {
                            throw "Unable to find dotnet exports";
                        }
                    }
                    SpeechRecognizer.dispatchStatus(_this.managedId, "SpeechDetected");
                };
                this.onError = function (event) {
                    if (!SpeechRecognizer.dispatchError) {
                        if (globalThis.DotnetExports !== undefined) {
                            SpeechRecognizer.dispatchError = globalThis.DotnetExports.Uno.Windows.Media.SpeechRecognition.SpeechRecognizer.DispatchError;
                        }
                        else {
                            throw "Unable to find dotnet exports";
                        }
                    }
                    SpeechRecognizer.dispatchError(_this.managedId, event.error);
                };
                this.managedId = managedId;
                if (window.SpeechRecognition) {
                    this.recognition = new window.SpeechRecognition(culture);
                }
                else if (window.webkitSpeechRecognition) {
                    this.recognition = new window.webkitSpeechRecognition(culture);
                }
                if (this.recognition) {
                    this.recognition.addEventListener("result", this.onResult);
                    this.recognition.addEventListener("speechstart", this.onSpeechStart);
                    this.recognition.addEventListener("error", this.onError);
                }
            }
            SpeechRecognizer.initialize = function (managedId, culture) {
                var recognizer = new SpeechRecognizer(managedId, culture);
                SpeechRecognizer.instanceMap[managedId] = recognizer;
            };
            SpeechRecognizer.recognize = function (managedId) {
                var recognizer = SpeechRecognizer.instanceMap[managedId];
                if (recognizer.recognition) {
                    recognizer.recognition.continuous = false;
                    recognizer.recognition.interimResults = true;
                    recognizer.recognition.start();
                    return true;
                }
                else {
                    return false;
                }
            };
            SpeechRecognizer.removeInstance = function (managedId) {
                var recognizer = SpeechRecognizer.instanceMap[managedId];
                recognizer.recognition.removeEventListener("result", recognizer.onResult);
                recognizer.recognition.removeEventListener("speechstart", recognizer.onSpeechStart);
                recognizer.recognition.removeEventListener("error", recognizer.onError);
                delete SpeechRecognizer.instanceMap[managedId];
            };
            SpeechRecognizer.instanceMap = {};
            return SpeechRecognizer;
        }());
        Media.SpeechRecognizer = SpeechRecognizer;
    })(Media = Windows.Media || (Windows.Media = {}));
})(Windows || (Windows = {}));
//# sourceMappingURL=SpeechRecognizer.js.map