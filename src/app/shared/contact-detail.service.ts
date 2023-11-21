import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { ContactDetail } from './contact-detail.model';
import { NgForm } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class ContactDetailService {
  url:string = environment.apiBaseUrl + '/ContactDetail';
  list: ContactDetail[] = [];
  formData : ContactDetail = new ContactDetail();
  formSubmitted:boolean=false;
  constructor(private http: HttpClient) { }
  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res =>{
        this.list = res as ContactDetail[]
      },
      error: err => {console.log(err)}
    })
  }
  postContactDetail(){
    return this.http.post(this.url,this.formData)
  }
  putContactDetail(){
    return this.http.put(this.url +'/'+ this.formData.contactId, this.formData)
  }
  deleteContactDetail(id:number){
    return this.http.delete(this.url +'/'+ id)
  }
  resetForm(form:NgForm){
    form.form.reset()
    this.formData = new ContactDetail()
    this.formSubmitted = false;
  }
}
