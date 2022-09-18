import { Cart } from "./Cart";
import { Product } from "../products";

export interface Checkout {
    products: Product[];
    cart: Cart;
}
