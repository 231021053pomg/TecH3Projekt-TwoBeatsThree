import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Product } from '../Components/Domain';
import { ProductService } from '../Services/Pages/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  id:number = 0;
  productName = "";
  price = 0;
  description = "";
  type = "";
  
  product: Product = { productName: "", price: 0, description: "", type: "", id: 0 };
  message: string = "";

  constructor(
    private route:ActivatedRoute,
    private productService:ProductService,
    private location:Location
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    this.productName = (this.route.snapshot.paramMap.get('ProductName') || '') as string;



    //RETURN to CRUD-types if data incorrect.
    if(this.id == null || this.id == 0){
      this.location.go('/CRUD-products');//url of CRUD-products
    }
    else{
      this.getProduct();
    }
  }


  getProduct(){
    
    this.productService.getProduct(this.id).subscribe(
      product => (product != null ? this.product = product : this.location.go('/CRUD-Products'))
      )
  }

  //save
  save():void{
    this.productService.updateProduct(this.id, this.product)
    .subscribe(product => {
      this.product = product
      this.message ="Product BLANK updated"

      setTimeout(() => {
        this.message = "";
      }, 3000);//Message times out.
    });
  }
}