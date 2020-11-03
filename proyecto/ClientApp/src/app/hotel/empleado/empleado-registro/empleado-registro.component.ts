import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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

      this.formregistro = this.formBuilder.group({
      cedula: [this.cliente.cedula, Validators.required, Validators.maxLength(12)],
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

}
