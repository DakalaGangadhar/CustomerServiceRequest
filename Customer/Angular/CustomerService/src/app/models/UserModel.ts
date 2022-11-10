
import { NgForm,FormGroup,Validators,FormBuilder,FormControl } from "@angular/forms";

export class UserModel{
    Username:string='';
    Password:string='';
    public formUserGroup:FormGroup;
    constructor(){
    var _builder=new FormBuilder();
    this.formUserGroup=_builder.group({
        UsernameControl:new FormControl('',Validators.compose([Validators.required,Validators.email])),
        UserPasswordControl:new FormControl('',Validators.compose([Validators.required,Validators.pattern("[0-9]+")]))
    }); 
    }
}