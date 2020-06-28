import { Component } from '@angular/core';
import { DriveInformation } from "../models/drive-information";
import { DriveInformationService } from "../services/drive-information.service";

@Component({
  selector: 'drive-info-list',
  templateUrl: './drive-info-list.component.html',
  providers: [DriveInformationService]
})
export class DriveInfoListComponent {
  public currentCount = 0;
  infoList: Array<DriveInformation> = undefined;
  sortField: string = undefined;
  isDesc: boolean;
  sortAlphaNum = (a, b) => a.localeCompare(b, 'en', { numeric: true });
  sortAlphaNumByProperty(propName, isDesc) {
    return function (a, b) {
      if (isDesc) {
        return -1 * String(a[propName]).localeCompare(String(b[propName]), 'en', { numeric: true });
      }
      else {
        return String(a[propName]).localeCompare(String(b[propName]), 'en', { numeric: true });
      }

    }
  }
  selectSortBy(field: string) {
    this.isDesc = !this.isDesc;
    this.sortField = field;
  }

  getOrderedList(arr: Array<any>) {
    if (!this.sortField) {
      return arr;
    }
    return arr.sort(this.sortAlphaNumByProperty(this.sortField, this.isDesc));
  }

  columns: Array<string> = ['id',
    'serialNumber',
    'modelName',
    'modelFamily',
    'formFactor',
    'blockCount',
    'bytesCount',
    'firmwareVersion',
    'rpm',
    'ataVersionMinor',
    'ataVersionMajor',
    'ataVersionName',
    'sataSpeed',
    'smartOK',
    'hasErrorRecovery',
    'powerOnHours',
    'powerCycleCount',
    'temperature']

  constructor(private driveInfoService: DriveInformationService) {
    this.driveInfoService.listAll().subscribe(data => {
      this.infoList = data;
    })
  }
}
