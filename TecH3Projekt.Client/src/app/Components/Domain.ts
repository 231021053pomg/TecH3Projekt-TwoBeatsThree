export interface LogIn{
    id: number;
    email: string;
    password: string;
    //isAdmin: boolean;
    user?: Array<User>;
}

export interface User{
    id: number;
    firstName:string;
    lastName: string;
    address: string;
    postNr: number;
    city: string;

    loginId: number;
}

export interface Category{
    id: number;
    typeName: string;
}