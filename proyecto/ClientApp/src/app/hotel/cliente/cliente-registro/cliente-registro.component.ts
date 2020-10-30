import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {
  formregistro: FormGroup;
  cliente: Cliente;
  constructor(private clienteService: ClienteService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.cliente= new Cliente();
    this.buildForm();
  }

  private buildForm() {
    this.cliente = new Cliente();
    this.cliente.cedula = '';
    this.cliente.primerNombre = '';
    this.cliente.segundoNombre = '';
    this.cliente.primerApellido = '';
    this.cliente.segundoApellido = '';
    this.cliente.edad = 0;
    this.cliente.sexo = '';
    this.cliente.departamento = '';
    this.cliente.ciudad = '';
    this.cliente.email = '';
    this.cliente.telefono = 0;

      this.formregistro = this.formBuilder.group({
      cedula: [this.cliente.cedula, Validators.required],
      primerNombre: [this.cliente.primerNombre, Validators.required],
      segundoNombre: [this.cliente.segundoNombre, Validators.required],
      primerApellido: [this.cliente.primerApellido, Validators.required],
      segundoApellido: [this.cliente.segundoApellido, Validators.required],
      sexo: [this.cliente.sexo, [Validators.required, this.ValidaSexo]],
      edad: [this.cliente.edad, [Validators.required, Validators.min(1)]],
      departamento: [this.cliente.departamento, Validators.required],
      ciudad: [this.cliente.ciudad, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefono: [this.cliente.telefono, Validators.required],
    });
  }

  private ValidaSexo(control: AbstractControl) {
    const sexo = control.value;
    if (sexo.toLocaleUpperCase() !== 'MASCULINO' && sexo.toLocaleUpperCase() !== 'FEMENINO') {
      return { validSexo: true, messageSexo: 'Sexo No Valido' };
    }
    return null;
  }

  get control() {
    return this.formregistro.controls;
  }

  onSubmit() {
    if (this.formregistro.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.cliente = this.formregistro.value;
    this.clienteService.post(this.cliente).subscribe(p => {
      if (p != null) {
        alert('Cliente guardado!');
        this.cliente = p;
      }
    });
  }
}
