import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';
import { CategoryService } from 'src/app/Services/Pages/category.service';
import { CartService } from 'src/app/Services/Pages/cart.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  products: Product[] = [];
  

  constructor(
    private productService:ProductService, //ADDED for service
    private cartService: CartService
  ) { }

  ngOnInit(): void {

    this.getProducts();

  }

  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => this.products = products);
  }

  addToCart(){
    this.cartService.sendToCart(this.products)
  }

}
