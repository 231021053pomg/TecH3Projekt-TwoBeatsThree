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

  id: number = 0; //--------------------
  category: Category = { typeName: "", id: 0 }; //--------------------
  message: string =""; //--------------------

  constructor(
    private route:ActivatedRoute, //--------------------
    private categoryService:CategoryService, //--------------------
    private location:Location //--------------------
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number; //--------------------

    //RETURN to CRUD-types if data incorrect.
    if(this.id == null || this.id == 0){ //--------------------
      this.location.go('/CRUD-types'); //url of CRUD-types //--------------------
    }
    else{
      this.getCategory(); //--------------------
    }
    
  }

  getCategory(){
    this.categoryService.getCategory(this.id).subscribe( //--------------------
      category => (category != null ? this.category = category : this.location.go('/CRUD-types')) //--------------------
      )
  }

  //save
  save():void{ //--------------------
    this.categoryService.updateCategory(this.id, this.category) //--------------------
    .subscribe(category => { //--------------------
      this.category = category //--------------------
      this.message ="Category updated" //--------------------

      setTimeout(() => { //--------------------
        this.message = ""; //--------------------
      }, 3000);//Message times out.
    });
  }

}
