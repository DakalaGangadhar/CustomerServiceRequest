import { NgForm,FormGroup,Validators,FormBuilder,FormControl } from "@angular/forms";

export class CreatRequest{
    srId:string='';
    Categoty:string='';
    Description:string='';
    public formUserGroup:FormGroup;
    constructor(){
    var _builder=new FormBuilder();
    this.formUserGroup=_builder.group({
        Categoty: new FormControl('',Validators.compose([Validators.required])),
        Description: new FormControl('',Validators.compose([Validators.required]))
    });
}
}