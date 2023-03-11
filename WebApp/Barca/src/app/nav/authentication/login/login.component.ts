import { Component, ElementRef, ViewChildren } from '@angular/core';
import { FormControlName, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { fromEvent, merge, Observable } from 'rxjs';
import { ValidationMessages, DisplayMessage, GenericValidator } from '../../shared/generic-forms';
import { AuthenticationService } from '../authentication.service';
import { User } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChildren(FormControlName, {read: ElementRef}) formInputElements: ElementRef[] = [];

  validationMessages :ValidationMessages = {};
  displayMessage: DisplayMessage = {};
  genericValidator: GenericValidator;

  mudancasNaoSalvas: boolean = false;
  isNewUser: boolean = false;

  registerFormRender: boolean = false;

  user: User = {} as User;
  loginObserver = {
    next: (result: any) => {
      let data : User = result.data;
      this.setCookie('session-token', data.ClientToken, 1);
    },
    error: (error: any) => { console.log(error) },
  }

  constructor(private fb: FormBuilder, private router : Router, private authenticationService : AuthenticationService){
      this.validationMessages = {
          Email:{
              required: 'O email é requerido',
              email: 'Precisa ser um email valido'
          },
          Password: {
              required: 'Informe o a senha',
          },
      };

      this.genericValidator = new GenericValidator(this.validationMessages);

  }

  loginForm = this.fb.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', Validators.required]
  });

  private generate(formGroup: any): void{
    let controlBlurs: Observable<any>[] = this.formInputElements.map((formControl: ElementRef) => 
    fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
        this.displayMessage = this.genericValidator.processarMensagens(formGroup);
        this.mudancasNaoSalvas = true;
    });
  }

  ngAfterViewInit(): void {
      this.generate(this.loginForm);
  }

  login(){
    if(this.loginForm.valid){
        Object.assign(this.user, this.loginForm.value);
        this.authenticationService.DoLogin(this.user).subscribe(this.loginObserver);
        //this.router.navigate(['home']);
    }
  }

  private setCookie(name: string, value: string, expireDays: number, path: string = '') {
    let d:Date = new Date();
    d.setTime(d.getTime() + expireDays * 24 * 60 * 60 * 1000);
    let expires:string = `expires=${d.toUTCString()}`;
    let cpath:string = path ? `; path=${path}` : '';
    document.cookie = `${name}=${value}; ${expires}${cpath}`;
  }
}
