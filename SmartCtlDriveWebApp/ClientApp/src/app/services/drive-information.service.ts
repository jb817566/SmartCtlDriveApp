import { BaseService } from "./base.http.service";
import { DriveInformation } from "../models/drive-information";

export class DriveInformationService extends BaseService {
  
  private apiURL = `${this.apiBase}/api/smartctl`;

  public listAll() {
    return this.http.get<Array<DriveInformation>>(`${this.apiURL}/listall`);
  }


}
