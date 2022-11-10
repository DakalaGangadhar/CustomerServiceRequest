
import { NgForm,FormGroup,Validators,FormBuilder,FormControl } from "@angular/forms";

export class RegistrationModel{
    registrationId:number=0;
    CustomerName:string='';
    CustomerEmail:string='';
    CustomerPassword:string='';
    ConfirmCustomerPassword:string='';
    CustomerPhoneNumber:string='';
    CustomerPanCard:string='';
    CustomerDOB:any='';
    CustomerCountry:string='';
    CustomerState:any='';
    CustomerDistrict:any='';
    CustomerAddress:string='';

    public formCustomerGroup:FormGroup;
    constructor(){
    var _builder=new FormBuilder();
    this.formCustomerGroup=_builder.group({
        CustomerName:new FormControl('',Validators.compose([Validators.required,Validators.pattern("^[a-zA-Z ]+")])),
        CustomerEmail:new FormControl('',Validators.compose([Validators.required,Validators.email])),        
        CustomerPhoneNumber:new FormControl('',Validators.compose([Validators.required,Validators.pattern("[0-9]+")])),
        CustomerPanCard:new FormControl('',Validators.compose([Validators.required,Validators.pattern("[A-Z]{5}[0-9]{4}[A-Z]{1}")])),
        CustomerDOB:new FormControl('',Validators.compose([Validators.required])),
        CustomerCountry:new FormControl('',Validators.compose([Validators.required])),
        CustomerState:new FormControl('',Validators.compose([Validators.required])),
        CustomerDistrict:new FormControl('',Validators.compose([Validators.required])),
        CustomerAddress:new FormControl('',Validators.compose([Validators.required])),
        CustomerPassword:new FormControl('',Validators.compose([Validators.required,Validators.pattern("[0-9]+")])),
        ConfirmCustomerPassword:new FormControl('',Validators.compose([Validators.required,Validators.pattern("[0-9]+")])),
   
 
},{validator: this.checkIfMatchingPasswords('CustomerPassword', 'ConfirmCustomerPassword')});
    }
    checkIfMatchingPasswords(passwordKey: string, passwordConfirmationKey: string) {
        return (group: FormGroup) => {
          let passwordInput = group.controls[passwordKey],
              passwordConfirmationInput = group.controls[passwordConfirmationKey];
          if (passwordInput.value !== passwordConfirmationInput.value) {
            return passwordConfirmationInput.setErrors({notEquivalent: true})
          }
          else {
              return passwordConfirmationInput.setErrors(null);
          }
        }
      }
}