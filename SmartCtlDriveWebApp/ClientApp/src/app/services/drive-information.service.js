"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.DriveInformationService = void 0;
var base_http_service_1 = require("./base.http.service");
var DriveInformationService = /** @class */ (function (_super) {
    __extends(DriveInformationService, _super);
    function DriveInformationService() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.apiURL = _this.apiBase + "/api/smartctl";
        return _this;
    }
    DriveInformationService.prototype.listAll = function () {
        return this.http.get(this.apiURL + "/listall");
    };
    return DriveInformationService;
}(base_http_service_1.BaseService));
exports.DriveInformationService = DriveInformationService;
//# sourceMappingURL=drive-information.service.js.map