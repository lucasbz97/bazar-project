import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  HasLoggedUser(): boolean {
    let user:string = this.getCookie('session-user');

    if(user !== ''){
      return true;
    }
    
    return false;
  }

  private getCookie(cookieName: string) {
    const cookies = Object.fromEntries(
      document.cookie.split(/; /).map(cookie => {
        const [key, v] = cookie.split('=', 2);
        return [key, decodeURIComponent(v)];
      }),
    );
    return cookies[cookieName] || '';
  }
}
