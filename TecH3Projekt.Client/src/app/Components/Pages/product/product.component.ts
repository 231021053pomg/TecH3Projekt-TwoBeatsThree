import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';//


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  id: number = 0;

  //bruges bagefter i html delen
  product: Product = {id: 0, productName: "", price: 0, description: "", typeID: 0 };


  constructor(
    private route:ActivatedRoute,
    private productService:ProductService, //DI //ADDED for service
    private location:Location 
  ) { }


  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    
    //RETURN to home if data incorrect.
    if(this.id == null || this.id == 0){
      this.location.go('/home');//url of home page.
    }
    else{
      this.getProduct();
    }
  }


  getProduct(): void {
    this.productService.getProduct(this.id)
    .subscribe(product => (product != null ? this.product = product : this.location.go('/home')) 
    )
  }
}
