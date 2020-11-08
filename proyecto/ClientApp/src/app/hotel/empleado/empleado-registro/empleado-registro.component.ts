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
    this.empleado.nombre = '';
    this.empleado.apellido = '';
    this.empleado.sexo = 'seleccionar';
    this.empleado.cargo = 'seleccionar';
    this.empleado.jornada = 'seleccionar';
    this.empleado.jefe='seleccionar';

      this.formregistro = this.formBuilder.group({
      cedula: [this.empleado.cedula, [Validators.required, Validators.maxLength(12), this.ValidaCedula]],
      nombre: [this.empleado.nombre, Validators.required],
      apellido: [this.empleado.apellido, Validators.required],
      sexo: [this.empleado.sexo, [Validators.required, this.ValidaSexo]],
      edad: [this.empleado.edad, [Validators.required, Validators.min(18), this.ValidaEdad]],
      cargo: [this.empleado.cargo, Validators.required],
      jornada: [this.empleado.jornada, Validators.required],
      telefono: [this.empleado.telefono, Validators.required],
      jefe: [this.empleado.jefe, Validators.required],
    });
  }

  private ValidaCedula(control: AbstractControl) {
    const cantidad = control.value;
    if (cantidad <= 0 || cantidad >= 999999999999) {
      return { validCantidad: true, messageCantidad: 'Cantidad menor o igual a 0' };
    }
    return null;
  }

  private ValidaEdad(control: AbstractControl) {
    const edad = control.value;
    if (edad > 65 || edad < 18) {
      return { validSexo: true, messageSexo: 'Edad No Valida' };
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
    this.empleado = this.formregistro.value;
    this.empleadoService.post(this.empleado).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: se ha agregado un empleado';
        this.empleado = p;
      }
    });
  }

}