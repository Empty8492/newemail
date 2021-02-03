import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})

export class EmailComponent implements OnInit {

  constructor() { }
 
  public list: any[] = [];
  public search: any;
  public checkedid: any[] = [];
  ngOnInit() {
    let _this = this;
    $.ajax({
      url: "api/E",
      type: "get",
      success: function (data) {
        var jsondata = JSON.parse(data);
        _this.list = jsondata;
        console.log(_this.list)
      }
    })
  }
  searchdata() {
    let _this = this;
    console.log(_this.search)
    $.ajax({
      url: " api/E/?name=" + this.search,
      type: "get",
      success: function (data) {
        var jsondata = JSON.parse(data);
        _this.list = jsondata;
        console.log(jsondata)
      }
    })
  }
  checked(id: any) {
    this.checkedid += id;
    console.log(this.checkedid)
  }
  Add() {
    var param = { "EmailName": this.search };
    $.ajax({
      url: "api/E/Insertpost",
      type: "post",
      data: param,
      success: function (data) {
        alert("成功添加数据");
        window.location.reload();
      }
    })
  }
  Del(id: any) {
    var param = { "EID": id };
    $.ajax({
      url: "api/E/Deletepost",
      type: "post",
      data: param,
      success: function (data) {
        alert("成功删除数据");
        window.location.reload();
      }
    })
  }
  Alldelete() {
    console.log(1)
  }
}
