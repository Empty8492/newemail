import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as $ from 'jquery';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  constructor(public route: ActivatedRoute) { }
  public list: any[] = [];
  ngOnInit() {
    this.route.params.subscribe((data) => {
      console.log(data.id)
      let _this = this;
      $.ajax({
        url: "api/E/?id=" + data.id,
        type: "get",
        success: function (data) {
          var jsondata = JSON.parse(data);
          _this.list = jsondata;
          console.log(_this.list)
        }
      })
    })
  }
  alter(id: any) {
    console.log(id);
    var ID = id;
    var name: number = <number>$("#name").val();
    var param: any = { "EID": ID, "EmailName": name };
    $.ajax({
      url: " api/E/Updatepost",
      type: "post",
      data: param,
      success: function (data) {
        alert("成功修改数据");
        history.go(-1);
      }
    })
  }

}
