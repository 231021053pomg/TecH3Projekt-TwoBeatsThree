import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {


  type: number = 0;
  products: Product[] = [];

  constructor(
    private route:ActivatedRoute,
    private location:Location,
    private productService:ProductService
  ) { }

  ngOnInit(): void {
    this.type = (this.route.snapshot.paramMap.get('type') || 0) as number;
    this.getProducts();
    this.getProductsByType();

  }

  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => this.products = products);

  }

  getProductsByType(): void{
    this.productService.getProductsByType(this.type)
    .subscribe(products => this.products = products)

  }

}
