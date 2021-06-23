import { Component, OnInit } from '@angular/core';
import { Product } from '../../Domain';
import { ProductService } from 'src/app/Services/Pages/product.service';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {


  id: number = 0;
  products: Product[] = [];

  constructor(
    private route:ActivatedRoute,
    private location:Location,
    private productService:ProductService
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    this.getProducts();
    this.getProductsByType();

  }

  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => this.products = products);

  }

  getProductsByType(): void{
    this.productService.getProductsByType(this.id)
    .subscribe(products => this.products = products)

  }

}
