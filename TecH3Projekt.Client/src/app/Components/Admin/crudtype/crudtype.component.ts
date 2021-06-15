import { Component, OnInit } from '@angular/core';
import { Category } from '../../Domain';
import {CategoryService} from 'src/app/Services/Pages/category.service';//

@Component({
  selector: 'app-crudtype',
  templateUrl: './crudtype.component.html',
  styleUrls: ['./crudtype.component.css']
})
export class CRUDTypeComponent implements OnInit {

  categories: Category[] = [];

  constructor(
    private categoryService:CategoryService//ADDED for service
  ) { }

  ngOnInit(): void {

    this.getCategories();

  }

  getCategories(): void {
    this.categoryService.getCategories()
    .subscribe(categories => this.categories = categories);
  }

  add(typeName: string):void{

    this.categoryService.addCategory({typeName} as Category)
    .subscribe(category => {this.categories.push(category) });

  }

  delete(category:Category):void {

    if(confirm(`Confirm delete: ${category.typeName} ?`)) {
      
      this.categories = this.categories.filter(a => a !== category);//remove deleted type from getlist.
      this.categoryService.deleteCategory(category.id).subscribe();

    }

    

  }

}
