var Windows;
(function (Windows) {
    var Devices;
    (function (Devices) {
        var Geolocation;
        (function (Geolocation) {
            var GeolocationAccessStatus;
            (function (GeolocationAccessStatus) {
                GeolocationAccessStatus["Allowed"] = "Allowed";
                GeolocationAccessStatus["Denied"] = "Denied";
                GeolocationAccessStatus["Unspecified"] = "Unspecified";
            })(GeolocationAccessStatus || (GeolocationAccessStatus = {}));
            var PositionStatus;
            (function (PositionStatus) {
                PositionStatus["Ready"] = "Ready";
                PositionStatus["Initializing"] = "Initializing";
                PositionStatus["NoData"] = "NoData";
                PositionStatus["Disabled"] = "Disabled";
                PositionStatus["NotInitialized"] = "NotInitialized";
                PositionStatus["NotAvailable"] = "NotAvailable";
            })(PositionStatus || (PositionStatus = {}));
            var Geolocator = /** @class */ (function () {
                function Geolocator() {
                }
                Geolocator.initialize = function () {
                    var _a, _b, _c, _d, _e;
                    this.positionWatches = {};
                    if (!Geolocator.interopInitialized) {
                        var exports = (_e = (_d = (_c = (_b = (_a = globalThis.DotnetExports) === null || _a === void 0 ? void 0 : _a.Uno) === null || _b === void 0 ? void 0 : _b.Uno) === null || _c === void 0 ? void 0 : _c.Devices) === null || _d === void 0 ? void 0 : _d.Geolocation) === null || _e === void 0 ? void 0 : _e.Geolocator;
                        if (exports !== undefined) {
                            Geolocator.dispatchAccessRequest = exports.DispatchAccessRequest;
                            Geolocator.dispatchError = exports.DispatchError;
                            Geolocator.dispatchGeoposition = exports.DispatchGeoposition;
                        }
                        else {
                            throw "Unable to find dotnet exports";
                        }
                        Geolocator.interopInitialized = true;
                    }
                };
                //checks for permission to the geolocation services
                Geolocator.requestAccess = function () {
                    Geolocator.initialize();
                    if (navigator.geolocation) {
                        navigator.geolocation.getCurrentPosition(function (_) {
                            Geolocator.dispatchAccessRequest(GeolocationAccessStatus.Allowed);
                        }, function (error) {
                            if (error.code == error.PERMISSION_DENIED) {
                                Geolocator.dispatchAccessRequest(GeolocationAccessStatus.Denied);
                            }
                            else if (error.code == error.POSITION_UNAVAILABLE ||
                                error.code == error.TIMEOUT) {
                                //position unavailable but we still have permission
                                Geolocator.dispatchAccessRequest(GeolocationAccessStatus.Allowed);
                            }
                            else {
                                Geolocator.dispatchAccessRequest(GeolocationAccessStatus.Unspecified);
                            }
                        }, { enableHighAccuracy: false, maximumAge: 86400000, timeout: 100 });
                    }
                    else {
                        Geolocator.dispatchAccessRequest(GeolocationAccessStatus.Denied);
                    }
                };
                //retrieves a single geoposition
                Geolocator.getGeoposition = function (desiredAccuracyInMeters, maximumAge, timeout, requestId) {
                    Geolocator.initialize();
                    if (navigator.geolocation) {
                        this.getAccurateCurrentPosition(function (position) { return Geolocator.handleGeoposition(position, requestId); }, function (error) { return Geolocator.handleError(error, requestId); }, desiredAccuracyInMeters, {
                            enableHighAccuracy: desiredAccuracyInMeters < 50,
                            maximumAge: maximumAge,
                            timeout: timeout
                        });
                    }
                    else {
                        Geolocator.dispatchError(PositionStatus.NotAvailable, requestId);
                    }
                };
                Geolocator.startPositionWatch = function (desiredAccuracyInMeters, requestId) {
                    Geolocator.initialize();
                    if (navigator.geolocation) {
                        Geolocator.positionWatches[requestId] = navigator.geolocation.watchPosition(function (position) { return Geolocator.handleGeoposition(position, requestId); }, function (error) { return Geolocator.handleError(error, requestId); });
                        return true;
                    }
                    else {
                        return false;
                    }
                };
                Geolocator.stopPositionWatch = function (desiredAccuracyInMeters, requestId) {
                    navigator.geolocation.clearWatch(Geolocator.positionWatches[requestId]);
                    delete Geolocator.positionWatches[requestId];
                };
                Geolocator.handleGeoposition = function (position, requestId) {
                    var serializedGeoposition = position.coords.latitude + ":" +
                        position.coords.longitude + ":" +
                        position.coords.altitude + ":" +
                        position.coords.altitudeAccuracy + ":" +
                        position.coords.accuracy + ":" +
                        position.coords.heading + ":" +
                        position.coords.speed + ":" +
                        position.timestamp;
                    Geolocator.dispatchGeoposition(serializedGeoposition, requestId);
                };
                Geolocator.handleError = function (error, requestId) {
                    if (error.code == error.TIMEOUT) {
                        Geolocator.dispatchError(PositionStatus.NoData, requestId);
                    }
                    else if (error.code == error.PERMISSION_DENIED) {
                        Geolocator.dispatchError(PositionStatus.Disabled, requestId);
                    }
                    else if (error.code == error.POSITION_UNAVAILABLE) {
                        Geolocator.dispatchError(PositionStatus.NotAvailable, requestId);
                    }
                };
                //this attempts to squeeze out the requested accuracy from the GPS by utilizing the set timeout
                //adapted from https://github.com/gregsramblings/getAccurateCurrentPosition/blob/master/geo.js		
                Geolocator.getAccurateCurrentPosition = function (geolocationSuccess, geolocationError, desiredAccuracy, options) {
                    var lastCheckedPosition;
                    var locationEventCount = 0;
                    var watchId;
                    var timerId;
                    var checkLocation = function (position) {
                        lastCheckedPosition = position;
                        locationEventCount = locationEventCount + 1;
                        //is the accuracy enough?
                        if (position.coords.accuracy <= desiredAccuracy) {
                            clearTimeout(timerId);
                            navigator.geolocation.clearWatch(watchId);
                            foundPosition(position);
                        }
                    };
                    var stopTrying = function () {
                        navigator.geolocation.clearWatch(watchId);
                        foundPosition(lastCheckedPosition);
                    };
                    var onError = function (error) {
                        clearTimeout(timerId);
                        navigator.geolocation.clearWatch(watchId);
                        geolocationError(error);
                    };
                    var foundPosition = function (position) {
                        geolocationSuccess(position);
                    };
                    watchId = navigator.geolocation.watchPosition(checkLocation, onError, options);
                    timerId = setTimeout(stopTrying, options.timeout);
                };
                ;
                Geolocator.interopInitialized = false;
                return Geolocator;
            }());
            Geolocation.Geolocator = Geolocator;
        })(Geolocation = Devices.Geolocation || (Devices.Geolocation = {}));
    })(Devices = Windows.Devices || (Windows.Devices = {}));
})(Windows || (Windows = {}));
//# sourceMappingURL=Geolocator.js.map