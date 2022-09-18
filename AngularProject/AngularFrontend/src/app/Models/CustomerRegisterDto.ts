export interface CustomerRegisterDto{
   
    UserId: string;
    firstName: string;
    lastName: string; 
    deliveryAddress?: string;
    phone?: string;
    email: string; 
    previousOrders?: string;
    isAdmin?: string;
    password: string;
     
}