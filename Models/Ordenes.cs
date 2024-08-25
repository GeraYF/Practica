using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica.Models
{
    public class Ordenes
    {
    

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }
       
        public string Email { get; set; }
        public DateTime FechaOperacion { get; set; }
        public List<string> InstrumentosSeleccionados { get; set; }
        public double MontoAbonar { get; set; }

        public double IGV { get; private set; }
        public double Comision { get; private set; }
        public double TotalAPagar { get; private set; }
   
        public Ordenes(string nombreCompleto, string email, DateTime fechaOperacion, List<string> instrumentosSeleccionados, double montoAbonar)
        {
            NombreCompleto = nombreCompleto;
            Email = email;
            FechaOperacion = fechaOperacion;
            InstrumentosSeleccionados = instrumentosSeleccionados;
            MontoAbonar = montoAbonar;

            IGV = montoAbonar * 0.18;
            Comision = montoAbonar > 300 ? 1 : 3;
            TotalAPagar = montoAbonar + IGV + Comision;
        }
   }
}
