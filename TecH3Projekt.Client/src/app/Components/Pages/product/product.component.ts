import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';//
import { MessengerService } from 'src/app/Services/Pages/messenger.service';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  id: number = 0;
  product: Product = {id: 0, productName: "", price: 0, description: "", typeID: 0 };

  constructor(
    private route:ActivatedRoute,
    private productService:ProductService, //DI //ADDED for service
    private location:Location,

    private messengerService: MessengerService
  ) { }


  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    
    //RETURN to CRUD-types if data incorrect.
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


  handleAddtoCart() {
    this.messengerService.sendMsg(this.product)
  }

}
