import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbAlertModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
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
  constructor(private clienteService: ClienteService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.cliente = new Cliente();
    this.buildForm();
  }
  private buildForm() {
    this.cliente = new Cliente();
    this.cliente.cedula = '';
    this.cliente.nombre = '';
    this.cliente.apellido = '';
    this.cliente.sexo = 'seleccionar';
    this.cliente.email = '';
    this.cliente.edad;
    this.cliente.telefono;

    this.formregistro = this.formBuilder.group({
      cedula: [this.cliente.cedula, [Validators.required, Validators.maxLength(12), this.ValidaCedula]],
      nombre: [this.cliente.nombre, Validators.required],
      apellido: [this.cliente.apellido, Validators.required],
      sexo: [this.cliente.sexo, [Validators.required, this.ValidaSexo]],
      edad: [this.cliente.edad, [Validators.required, Validators.min(1)]],
      email: [this.cliente.email, Validators.required],
      telefono: [this.cliente.telefono, Validators.required],
    });
  }

  private ValidaCedula(control: AbstractControl) {
    const cantidad = control.value;
    if (cantidad <= 0 || cantidad >= 999999999999) {
      return { validCantidad: true, messageCantidad: 'Cantidad menor o igual a 0' };
    }
    return null;
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
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha agregado un cliente';
        this.cliente = p;
      }
    });
  }
}