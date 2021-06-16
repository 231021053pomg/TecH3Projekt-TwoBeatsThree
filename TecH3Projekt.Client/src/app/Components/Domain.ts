export interface User{
    firstName:string;
    lastName: string;
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