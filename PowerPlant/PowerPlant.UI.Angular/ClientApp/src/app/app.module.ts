import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DataTablesModule } from 'angular-datatables';
import { AddPowerPlantComponent } from './crud/add/add-powerplant.component';
import { EditPowerPlantComponent } from './crud/edit/edit-powerplant.component';
import { DeletePowerPlantComponent } from './crud/delete/delete-powerplant.component';
import { DetailPowerPlantComponent } from './crud/detail/detail-powerplant.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddPowerPlantComponent,
    EditPowerPlantComponent,
    DeletePowerPlantComponent,
    DetailPowerPlantComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DataTablesModule,
    CommonModule,
    MatIconModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'add', component: AddPowerPlantComponent},
      { path: 'edit/:id', component: EditPowerPlantComponent },
      { path: 'delete/:id', component: DeletePowerPlantComponent },
      { path: 'detail/:id', component: DetailPowerPlantComponent }
    ], { useHash: true }),
    BrowserAnimationsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
