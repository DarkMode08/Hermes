using System.Net;
using System.Net.Mail;

namespace Hermes.Services
{
    public class EmailServices
    {
        private readonly IConfiguration configuration;

        // Clase para recibir dependencia de IConfiguration para tomar datos desde el proveedor Gmail.
        public EmailServices(IConfiguration configuration)
        {
            // Se asigna como campo.
            this.configuration = configuration;
        }

        // Creacion de Metodo para Enviar Email.
        public async Task SendEmail(string DestinationEmail, string Subject, string Body) // Este metodo recibe Email De Destino, El Asunto y el Cuerpo del correo a enviar.
        {
            // Se obtiene el conjunto de Configuraciones Del Iconfiguration ( Objetos que recibe el metodo + Host + Puerto ).
            var OriginEmail = configuration.GetValue<string>("CONFIGURATION_EMAIL:EMAIL");
            var Password = configuration.GetValue<string>("CONFIGURATION_EMAIL:PASSWORD");
            var Host = configuration.GetValue<string>("CONFIGURATION_EMAIL:HOST");
            var Port = configuration.GetValue<int>("CONFIGURATION_EMAIL:PORT");

            /*
            SmtpClient es una clase que se utiliza para enviar correos electrónicos mediante el protocolo SMTP (Simple Mail Transfer Protocol).
            Esta clase permite especificar detalles como el servidor SMTP, las credenciales de autenticación y el puerto de conexión.
            */

            // 
            var smtpClient = new SmtpClient(Host, Port);
            smtpClient.EnableSsl = true; // Mecanismo de seguridad de Smtp.
            smtpClient.UseDefaultCredentials = false; // False para poder utilizar mi credenciales personalizadas.

            // Definir las Credenciales Personalizadas.
            smtpClient.Credentials = new NetworkCredential(OriginEmail, Password); // NetworkCredential Recibe las credenciales que yo defina (Aqui va la personalizacion).

            // Construccion Del Mensaje.
            var Message = new MailMessage(OriginEmail!, DestinationEmail, Subject, Body); // Origen y Destino junto a sus parametros iniciales.
            // El Origen no puede ser Nulo ( ! ), Ya que no se enviaria el Correo

            // Envio de Correo
            await smtpClient.SendMailAsync(Message);
        }
    }
}
