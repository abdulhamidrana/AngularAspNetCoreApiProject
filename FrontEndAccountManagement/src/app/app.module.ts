import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServarComponent } from './error-pages/internal-servar/internal-servar.component';
//import { OtherErrorComponent } from './error-pages/other-error/other-error.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent,
    InternalServarComponent,
    //OtherErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,   // for sending HTTP requests to our server. It processes response (JSON response is set by default) and handles errors as well.
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },      
      { path: 'owner', loadChildren: () => import('./owner/owner.module').then(m=> m.OwnerModule) },
      { path: '404', component: NotFoundComponent },
      { path: '500', component:InternalServarComponent },
      //{ path: 'unknown', component: OtherErrorComponent },
      { path: '', redirectTo: '/home', pathMatch:'full' },      
      { path: '**', redirectTo: '/404', pathMatch: 'full' }
    ])
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }


//loadChildren property: here the owner module with its components won’t be loaded until we explicitly ask for them
