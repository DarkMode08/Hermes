### Proyecto de Mensajería con [ASP.NET](https://asp.net/) Core Web MVC

Este proyecto implementa un sistema de mensajería utilizando [ASP.NET](https://asp.net/) Core MVC y los servicios de
Gmail para el envío de correos electrónicos.

### Características

- **Mensajería Mail:** Los usuarios pueden enviar correos electrónicos utilizando los servicios de Gmail.
- **Formulario de Envío:** Interfaz amigable creada con Bootstrap para que los usuarios completen y envíen correos.
- **Configuración de Credenciales:** Integración segura con las credenciales de Gmail configuradas como user
  secrets en el proyecto.
- **Autenticación de Aplicación:** El Gmail utilizado debe tener una contraseña específica para aplicaciones.

### Tecnologías Utilizadas

- **[ASP.NET](https://asp.net/) Core MVC:** Framework para construir aplicaciones web robustas.
- **Gmail API:** Servicio utilizado para la mensajería y envío de correos electrónicos.
- **Bootstrap:** Utilizado para crear una vista moderna y responsiva.

### Despliegue

Para ejecutar este proyecto, asegúrate de configurar correctamente las credenciales de Gmail en user secrets
(`appsettings.json`). Utiliza una contraseña de aplicación para el correo de Gmail. Luego, despliega la aplicación
en tu servidor o entorno de pruebas.
