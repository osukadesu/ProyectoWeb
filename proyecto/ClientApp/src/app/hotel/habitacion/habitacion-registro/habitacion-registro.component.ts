import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { Habitacion } from '../../models/habitacion';

@Component({
  selector: 'app-habitacion-registro',
  templateUrl: './habitacion-registro.component.html',
  styleUrls: ['./habitacion-registro.component.css']
})
export class HabitacionRegistroComponent implements OnInit {
  formregistro: FormGroup;
  habitacion: Habitacion;
  constructor(private habitacionService: HabitacionService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.habitacion = new Habitacion();
    this.buildForm();
  }

  private buildForm() {
    this.habitacion = new Habitacion();
    this.habitacion.idhabitacion;
    this.habitacion.tipo = 'seleccionar';
    this.habitacion.estado = 'seleccionar';
    this.habitacion.npersonas;
    this.habitacion.precio;

    this.formregistro = this.formBuilder.group({
      idhabitacion: [this.habitacion.idhabitacion, [Validators.required, Validators.maxLength(4)]],
      tipo: [this.habitacion.tipo, Validators.required],
      npersonas: [this.habitacion.npersonas, Validators.required],
      estado: [this.habitacion.estado, Validators.required],
      precio: [this.habitacion.precio, Validators.required],
    });
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
    this.habitacion = this.formregistro.value;
    this.habitacionService.post(this.habitacion).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: se ha registrado una habitacion';
        this.habitacion = p;
      }
    });
  }

}
