using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class OrdenesController: Controller

     private readonly ILogger<OrdenesController> _logger;
     
    public OrdenesController(ILongger<OrdenesController>longger)
    {
         _logger = logger;
    }

    public IActionResult Index()
    {
            return View();
    }

   
    [HttpPost]
    public IActionResult CrearOrden(OrdenesViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.InstrumentosSeleccionados.Count == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un instrumento.");
                return View("Index", model);
            }

        // Crear una instancia de la clase Ordenes
            var orden = new Ordenes(
                model.NombreCompleto,
                model.Email,
                model.FechaOperacion,
                model.InstrumentosSeleccionados,
                model.MontoAbonar
            );

            // Pasar la orden a la vista para mostrar los resultados
            return View("Resultado", orden);
            }

            // Si el modelo no es válido, mostrar el formulario con errores
            return View("Index", model);
        }
}