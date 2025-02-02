import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';

if (window.innerWidth < 768) {
  document.documentElement.style.fontSize = '14px';
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
