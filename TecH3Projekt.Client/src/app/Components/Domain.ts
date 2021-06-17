export interface User{
    //id: number;
    firstName:string;
    lastName: string;
    address: string;
    postNr: number;
    city: string;

    //loginId: number;
}

export interface LogIn{

}

export interface Category{
    id: number;
    typeName: string;
}

export interface Product{
    id: number;
    ProductName: string;
    Price: number;
    Description: string;
    //Pictures: string;
    //TypeId: number;
    //Type: string;
}