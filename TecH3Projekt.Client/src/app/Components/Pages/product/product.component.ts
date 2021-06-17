import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';//


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: Product[] = [];

  constructor(
    private productService:ProductService //ADDED for service
  ) { }


  ngOnInit(): void {
    this.getProducts();
  }


  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => this.products = products);
  }
}
