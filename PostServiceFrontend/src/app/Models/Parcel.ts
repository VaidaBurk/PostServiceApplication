export interface Parcel {
    id?: number,
    weight: number,
    receiver: string,
    phone: string,
    info: string,
    parcelMachineId: number,
    parcelMachineCode?: string
}