import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/Services/Pages/messenger.service';
import { Product } from '../../Domain';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(
    private messengerService: MessengerService
  ) { }

  ngOnInit(): void {

    this.messengerService.getMsg().subscribe((product: Product) => {

      this.cartItems.push({
        productName: product.productName,
        quantity: 1,
        price: product.price
      })

      this.cartItem.forEach(item => {
        this.cartTotal += (item.quantity * item.price)
      })
    })
  }
}
