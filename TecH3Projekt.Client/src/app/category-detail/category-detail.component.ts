import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Category } from '../Components/Domain';
import { CategoryService } from '../Services/Pages/category.service';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit {

  id: number = 0;
  category: Category = { typeName: "", id: 0 };

  constructor(
    private route:ActivatedRoute,
    private categoryService:CategoryService,
    private location:Location
  ) { }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory(){
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    this.categoryService.getCategory(this.id).subscribe(
      category => this.category = category)
  }


}
