import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ReservaService } from 'src/app/services/reserva.service';
import { Reserva } from '../../models/reserva';

@Component({
  selector: 'app-reserva-registro',
  templateUrl: './reserva-registro.component.html',
  styleUrls: ['./reserva-registro.component.css']
})
export class ReservaRegistroComponent implements OnInit {
  formregistro: FormGroup;
  reserva: Reserva;
  constructor(private reservaService: ReservaService, private rutaActiva: ActivatedRoute, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {

    this.reserva = new Reserva();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.reservaService.getId(id).subscribe(p => {
      this.reserva = p;
      this.reserva != null ? alert('Se Consulta la reserva') : alert('Error al Consultar');
    });

    this.buildForm();
  }

  private buildForm() {
    this.reserva = new Reserva();
    this.reserva.IdReserva;
    this.reserva.Cedula = '';
    this.reserva.idHabitacion;
    this.reserva.FechaReserva;
    this.reserva.FechaEntrada;
    this.reserva.FechaSalida;
    this.reserva.Total;

    this.formregistro = this.formBuilder.group({
      IdReserva: [this.reserva.IdReserva, [Validators.required, Validators.maxLength(4)]],
      Cedula: [this.reserva.Cedula, [Validators.required, Validators.maxLength(4)]],
      CodigoHabitacion: [this.reserva.idHabitacion,[Validators.required, Validators.maxLength(4)]],
      FechaReserva: [this.reserva.FechaReserva, Validators.required],
      FechaEntrada: [this.reserva.FechaEntrada, Validators.required],
      FechaSalida: [this.reserva.FechaSalida, Validators.required],
      Total: [this.reserva.Total, Validators.required],
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
    this.reserva = this.formregistro.value;
    this.reservaService.post(this.reserva).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: se ha registrado una reserva';
        this.reserva = p;
      }
    });
  }
}
