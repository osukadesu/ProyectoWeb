import { Habitacion } from "./habitacion";

export class Reserva extends Habitacion {
    IdReserva: string;
    FechaReserva: Date;
    Cedula: string;
    Subtotal: number;
    Iva: number;
    Total: number;
    FechaEntrada: Date;
    FechaSalida: Date;
    idHabitacion: string;
    tipo: string;
    nPersonas: number;
    estado: string;
    precio: number;
}