"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DriveInformationService = void 0;
var DriveInformationService = /** @class */ (function () {
    function DriveInformationService() {
        this._apiBase = 'http://localhost:59801';
        this.apiURL = this._apiBase + "/api/smartctl";
    }
    DriveInformationService.prototype.listAll = function () {
        return;
    };
    return DriveInformationService;
}());
exports.DriveInformationService = DriveInformationService;
//# sourceMappingURL=drive-information.service.js.map