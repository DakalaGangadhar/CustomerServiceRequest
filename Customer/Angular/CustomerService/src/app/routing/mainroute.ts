
import { HomeComponent } from '../master/home/home.component';

export const Mainroutes = [
    { path: 'home', loadChildren: () => import('../customer/customer.module').then(m => m.CustomerModule) },
    { path: 'customer', loadChildren: () => import('../requestservice/requestservice.module').then(m => m.RequestserviceModule) },
    { path: 'admin', loadChildren: () => import('../admin/admin.module').then(m => m.AdminModule) },
    { path: '', component: HomeComponent },
    
   
];
