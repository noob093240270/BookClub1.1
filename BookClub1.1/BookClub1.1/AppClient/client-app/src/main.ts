import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
enableProdMode();
const platform = platformBrowserDynamic();
bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(withFetch()), 
  ]
}).catch((err) => console.error(err));
