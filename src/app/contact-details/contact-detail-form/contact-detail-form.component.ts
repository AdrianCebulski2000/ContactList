import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ContactDetail } from 'src/app/shared/contact-detail.model';
import { ContactDetailService } from 'src/app/shared/contact-detail.service';

@Component({
  selector: 'app-contact-detail-form',
  templateUrl: './contact-detail-form.component.html',
  styles: [
  ]
})
export class ContactDetailFormComponent {
  
  constructor(public service: ContactDetailService, private toastr:ToastrService){

  }
onSubmit(form:NgForm){
  this.service.formSubmitted = true
  if(form.valid){
    if(this.service.formData.contactId==0)
    this.insertRecord(form)
  else
  this.updateRecord(form)
  }
}
insertRecord(form:NgForm){
  this.service.postContactDetail()
  .subscribe({
    next:res =>{
      this.service.list = res as ContactDetail[]
      this.service.resetForm(form)
      this.toastr.success('Inserted successfully','Contact details')
    },
    error: err=>{console.log(err)}
  })
}
updateRecord(form:NgForm){
  this.service.putContactDetail()
  .subscribe({
    next:res =>{
      this.service.list = res as ContactDetail[]
      this.service.resetForm(form)
      this.toastr.info('Updated successfully','Contact details')
    },
    error: err=>{console.log(err)}
  })
}
}
