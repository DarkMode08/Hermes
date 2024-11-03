using Hermes.Services;
using Microsoft.AspNetCore.Mvc;
using Hermes.ViewModels;
using System.Reflection;

namespace Hermes.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailServices _emailServices; // Campo privado para el servicio de envío de correos electrónicos.

        public EmailController(EmailServices emailServices) // Constructor que recibe una instancia de EmailServices mediante inyección de dependencias.
        {
            _emailServices = emailServices;
        }

        // Muestra la vista para que el usuario pueda ingresar los datos del correo.
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        // Este Post responde a solicitudes POST en la ruta /Email/SendEmail.
        [HttpPost]
        public async Task<IActionResult> SendEmail(string Email, string Subject, string Body)
        {
            // Metodo para el envio del Correo
            if (ModelState.IsValid)
            {
                try
                {
                    await _emailServices.SendEmail(Email, Subject, Body);

                    // Mostrar Mensaje de Envio Exitoso
                    ViewBag.Message = $"Correo Enviado Exitosamente.";
                }
                catch (Exception ex) {
                    // Mostrar error si algo no a salido bien enviando el correo
                    ViewBag.Message = $"Error Enviando el Correo {ex.Message}.";
                }
            }

            // Retorna la vista para que el usuario pueda ver el mensaje de confirmación o error.
            return RedirectToAction("Index", "Home");
        }
    }
}
