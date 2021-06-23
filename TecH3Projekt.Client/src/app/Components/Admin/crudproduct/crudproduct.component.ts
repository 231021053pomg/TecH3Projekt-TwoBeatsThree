import { Component, OnInit } from '@angular/core';
import { Category, Product } from '../../Domain';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductService } from 'src/app/Services/Pages/product.service';
import { throwError } from 'rxjs';
import { CategoryService } from 'src/app/Services/Pages/category.service';

@Component({
  selector: 'app-crudproduct',
  templateUrl: './crudproduct.component.html',
  styleUrls: ['./crudproduct.component.css']
})
export class CRUDProductComponent implements OnInit {

  products: Product[] = [];
  categories: Category[] = [];

  constructor(
    private productService:ProductService, //ADDED for service
    private categoryService:CategoryService
  ) { }

  ngOnInit(): void {

    this.getProducts();
    this.getCategories();

  }

  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => this.products = products);
  }

  getCategories(): void {
    this.categoryService.getCategories()
    .subscribe(categories => this.categories = categories);
  }


  add(productName: string, price: any, description: string, typeID: any):void{
    this.productService.addProduct({ productName, price, description, typeID} as Product)
    .subscribe(product => {this.products.push(product) });
  }


  delete(product:Product):void {

    if(confirm(`Confirm delete: ${product.productName} ?`)) {
      this.products = this.products.filter(a => a !== product);//remove deleted type from getlist.
      this.productService.deleteProduct(product.id).subscribe();
    }
  }
}
