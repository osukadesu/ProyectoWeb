import { Component, OnInit } from '@angular/core';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { Habitacion } from '../../models/habitacion';

@Component({
  selector: 'app-reserva-gestion',
  templateUrl: './reserva-gestion.component.html',
  styleUrls: ['./reserva-gestion.component.css']
})
export class ReservaGestionComponent implements OnInit {
  habitaciones: Habitacion[];
  constructor(private habitacionService: HabitacionService) { }

  ngOnInit(){
    this.habitacionService.get().subscribe(result => {
      this.habitaciones = result;
      });
  }

}
