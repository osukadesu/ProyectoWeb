import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { Empleado } from '../../models/empleado';

@Component({
  selector: 'app-empleado-registro',
  templateUrl: './empleado-registro.component.html',
  styleUrls: ['./empleado-registro.component.css']
})
export class EmpleadoRegistroComponent implements OnInit {
  formregistro: FormGroup;
  empleado: Empleado;
  constructor(private empleadoService: EmpleadoService, private formBuilder: FormBuilder,
  private modalService:NgbModal) { }

  ngOnInit() {
    this.empleado= new Empleado();
    this.buildForm();
  }

  private buildForm() {
    this.empleado = new Empleado();
    this.empleado.cedula = '';
    this.empleado.primerNombre = '';
    this.empleado.segundoNombre = '';
    this.empleado.primerApellido = '';
    this.empleado.segundoApellido = '';
    this.empleado.edad = 0;
    this.empleado.sexo = '';
    this.empleado.departamento = '';
    this.empleado.ciudad = '';
    this.empleado.email = '';
    this.empleado.telefono = 0;
    this.empleado.Cargo = '';
    this.empleado.Jornada = '';
    this.empleado.Jefe = '';

      this.formregistro = this.formBuilder.group({
      cedula: [this.empleado.cedula, Validators.required, Validators.maxLength(12)],
      primerNombre: [this.empleado.primerNombre, Validators.required],
      segundoNombre: [this.empleado.segundoNombre, Validators.required],
      primerApellido: [this.empleado.primerApellido, Validators.required],
      segundoApellido: [this.empleado.segundoApellido, Validators.required],
      sexo: [this.empleado.sexo, [Validators.required, this.ValidaSexo]],
      edad: [this.empleado.edad, [Validators.required, Validators.min(1)]],
      departamento: [this.empleado.departamento, Validators.required],
      ciudad: [this.empleado.ciudad, Validators.required],
      email: [this.empleado.email, Validators.required],
      telefono: [this.empleado.telefono, Validators.required],
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
    this.empleado = this.formregistro.value;
    this.empleadoService.post(this.empleado).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Error: No ha agregado el empleado a la solicitud';
        this.empleado = p;
      }
    });
  }

}