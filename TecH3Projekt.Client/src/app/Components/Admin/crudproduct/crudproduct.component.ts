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


  add(productName: string):void{
    this.productService.addProduct({productName} as Product)
    .subscribe(product => {this.products.push(product) });
  }


  delete(product:Product):void {

    if(confirm(`Confirm delete: ${product.productName} ?`)) {
      this.products = this.products.filter(a => a !== product);//remove deleted type from getlist.
      this.productService.deleteProduct(product.id).subscribe();
    }
  }
}
