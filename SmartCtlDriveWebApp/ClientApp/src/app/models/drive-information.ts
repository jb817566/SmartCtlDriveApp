export class DriveInformation {
    id: number;
    serialNumber: string;
    modelName: string;
    modelFamily: string;
    formFactor: string;
    blockCount: number;
    bytesCount: number;
    firmwareVersion: string;
    rpm: number;
    ataVersionMinor: number;
    ataVersionMajor: number;
    ataVersionName: string;
    sataSpeed: string;
    smartOK: boolean;
    hasErrorRecovery: boolean;
    powerOnHours: number;
    powerCycleCount: number;
    temperature: number;
}
