import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/Pages/category.service';
import { Category } from '../../Domain';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  categories: Category[] = [];

  constructor(
    private categoryService:CategoryService
  ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.categoryService.getCategories()
    .subscribe(categories => this.categories = categories);
  }

}
