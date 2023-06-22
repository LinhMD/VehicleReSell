export class User {
    Id: number;
    UserName: string;
    PhoneNumber: string;
    Password: string;
    Address: string;
    Role: Role;
}

export class Seller extends Entity {
    Id: number;
    User: User;
    SaleOrders: SaleOrder[];
}

export class SaleOrder extends Model {
    Id: number
    Seller: Seller;

    Transaction: Transaction;

    Customer: Customer;

}

export class Staff extends Entity {
    Id: number;
    User: User;
    TransferOrders: TransferOrder[];

}

export class Assessor extends Entity {
    Id: number;
    User: User;
    ItemReceipts: ItemReceipt[]
}

export class TransferOrder extends Model {
    Transaction: Transaction

    FromLocation: WareHouse | null;
    FromLocationAddress: string;
    LeaveDate: Date;

    ToLocation: WareHouse | null;
    ToLocationAddress: string;
    ReceiveDate: Date;

    Staff: Staff;
}

export class ItemReceipt extends Model {
    Transaction: Transaction
    VehicleOwner: VehicleOwner
    Staff: Staff
    Assessor: Assessor
    ItemReceiptStatus: ItemReceiptStatus;
    Approver: User;
}

export enum ItemReceiptStatus {
    VehicleOwnerOpen,
    WaitingForAssessment,
    Submit,
    Approved,
    Reject
}


export class Entity extends Model {
    Id: number;
    Name: string;
    Phone: string;
    Address: string;
    EntityType: EntityType;
}

export enum EntityType {
    Customer,
    VehicleOwner,
    Staff,
    Assessor,
    Seller
}

export class Transaction extends Model {
    Id: number;
    TransactionName: string;
    TotalAmount: number;
    TransactionDate: Date;
    TransactionLines: TransactionLine[];
    TransactionType: TransactionType;
    ApprovalStatus: ApprovalStatus;
    Status: TransactionStatus;
}

export enum TransactionStatus {
    Open,
    Success,
    Failed
}

export class TransactionLine {
    Id: number;
    Vehicle: Vehicle;
    WareHouse: WareHouse;
    PIC: Entity;
    Amount: number;
    Note: string;
}

export class Vehicle {
    Id: number;
    Name: number;
    NewAt: Date;
    Color: string;
    Manufacture: string;
    Model: CarModel;
    AssessPrice: number;
    SoldPrice: number;
    Accessor: Assessor;
    WareHouse: WareHouse;
    VehicleOwner: VehicleOwner
    Usage: number;
    Description: string;
    Imgs: string[];
    Videos: Blob[];
    Capacity: number;
}

export enum CarModel {
    Sedan,
    SUV,
    Truck,
    Micro,
    Van
}

export class VehicleOwner extends Entity {

}

export class WareHouse {
    Id: number;
    Address: string;
    Phone: number;
    Vehicle: Vehicle[]

    MaxCapacity: number;
    CurrentCapacity: number;
}

export class SystemLog {
    Id: number;
    User: User;
    OldRecord: string;
    NewRecord: string;
    RecordType: string;
}

export class Customer extends Entity {
    Id: number;
}

export class CustomerEvent extends Model {
    Seller: Seller
    Customer: Customer
    Vehicle: Vehicle
    Note: string;
    Date: Date;
}


export enum Role {
    Admin,
    Assessor,
    Seller,
    Staff
}

export enum TransactionType {
    IR,
    TO,
    SO
}

export enum ApprovalStatus {
    Open,
    PendingApproval,
    Approved,
    Reject
}
export class Model {
    CreateAt: Date;
    UpdateAt: Date;
    DeleteAt: Date;
    IsActive: boolean;
    CreateBy: User;
    UpdateBy: User;

}