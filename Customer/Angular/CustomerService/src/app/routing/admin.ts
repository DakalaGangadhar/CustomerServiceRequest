import { GridComponent } from "../admin/grid/grid.component";
import { LoginComponent } from "../customer/login/login.component";

export const adminroute = [
    { path: 'login', component: LoginComponent },
    { path: 'grid', component: GridComponent }
];