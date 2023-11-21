import { Component, OnInit} from '@angular/core';
import { ContactDetailService } from '../shared/contact-detail.service';
import { ContactDetail } from '../shared/contact-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styles: [
  ]
})
export class ContactDetailsComponent implements OnInit{
[x: string]: any;

  constructor(public service: ContactDetailService, private toastr: ToastrService){

  }
  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(selectedRecord:ContactDetail){
    this.service.formData=Object.assign({},selectedRecord);
  }
  onDelete(id:number){
    if(confirm('Are you sure to delete this record?'))
    this.service.deleteContactDetail(id)
    .subscribe({
      next:res =>{
        this.service.list = res as ContactDetail[]
        this.toastr.error('Deleted successfully','Contact details')
      },
      error: err=>{console.log(err)}
    })
  }
}
