import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { CartService } from 'src/app/Services/Pages/cart.service';

@Component({
  selector: 'app-shopping-basket',
  templateUrl: './shopping-basket.component.html',
  styleUrls: ['./shopping-basket.component.css']
})
export class ShoppingBasketComponent implements OnInit {

  
  cartItem = [
    //{id:1, productId: 1, productName:"Test1", qty: 4, price: 100}
  ];

  cartTotal = 0; //Total price.

  constructor(
    private cartService: CartService
  ) { }

  ngOnInit(): void {

    this.cartService.getToCart()
    .subscribe(product => {
      console.log(product)

      // this.cartItems.forEach(item => {
    //   this.cartTotal += (item.qty * item.price)
    // }) //Used to calculate total price

    })

    
  }

}
