import { Component, ElementRef, ViewChildren } from '@angular/core';
import { AbstractControl, FormBuilder, FormControlName, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { fromEvent, merge, Observable } from 'rxjs';
import { DisplayMessage, GenericValidator, ValidationMessages } from '../../shared/generic-forms';
import { Register } from '../models/Register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @ViewChildren(FormControlName, {read: ElementRef}) formInputElements: ElementRef [] = [];

  validationMessages: ValidationMessages = {};
  displayMessages: DisplayMessage = {};
  genericValidator: GenericValidator;

  mudancasNaoSalvas: boolean = false;
  isNewUser: boolean = false;

  registerFormRender: boolean = false;
  registerForm: FormGroup;
  user: Register = {} as Register;

  constructor(private fb: FormBuilder, private router : Router) {
    this.registerForm = this.fb.group({
      Name: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', Validators.required],
      ConfirmPassword: ['', [Validators.required, this.matchValidator("Password", "ConfirmPassword")]]
    });

    this.validationMessages = {
      Name: {
        required: 'Informe seu nome',
        minLenght: 'O Nome deve ter pelo menos 2 caracteres'
      },
      Email:{
        required: 'O email é requerido',
        email: 'Precisa ser um email valido'
      },
      Password: {
        required: 'Informe a senha',
        minLenght: 'A senha deve ter pelo menos 6 caracteres'
      },
      ConfirmPassword: {
        require: 'Informe a confirmação de senha',
        minLenght: 'A senha deve ter pelo menos 6 caracteres',
        equalTo: "As senhas não conferem"
      }
  };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  private generate(formGroup: any): void{
    let controlBlurs: Observable<any>[] = this.formInputElements.map((formControl: ElementRef) => 
    fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
        this.displayMessages = this.genericValidator.processarMensagens(formGroup);
        this.mudancasNaoSalvas = true;
    });
  }

  ngAfterViewInit(): void {
    this.generate(this.registerForm);
}

matchValidator(password: string, confirmPassword: string): ValidatorFn {
  return () => {
    if(this.registerForm && this.registerForm.get(password)?.value !== this.registerForm.get(confirmPassword)?.value)
      return { equalTo: 'As senhas não conferem' };
    return null;
  };
}

  register() {
    if(this.registerForm.valid){
      Object.assign(this.user, this.registerForm.value);
      this.router.navigate(['home']);
    }
  }
}
