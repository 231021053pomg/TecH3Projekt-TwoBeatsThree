import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';

@Component({
  selector: 'app-crudproduct',
  templateUrl: './crudproduct.component.html',
  styleUrls: ['./crudproduct.component.css']
})
export class CRUDProductComponent implements OnInit {

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


  add(productName: string, price: any, description: any, type: any):void{
    this.productService.addProduct({productName, price, description, type} as Product)
    .subscribe(product => {this.products.push(product) });
  }


  delete(product:Product):void {

    if(confirm(`Confirm delete: ${product.productName} ?`)) {
      this.products = this.products.filter(a => a !== product);//remove deleted type from getlist.
      this.productService.deleteProduct(product.id).subscribe();
    }
  }
}
