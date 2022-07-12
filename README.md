# BackgroundService_Demo

En esta demo vamos a crear un servicio windows utilizando la clase BackgroundService, tambien podríamos hacerlo implementando la interfaz IHostedservice. Utilizamos la plantilla "Worker Service" de visual Studio que nos permite ejecutar servicios en segundo plano mediante el uso de un servicio hospedado. La idea es imaginar un servicio que cada hora busca un fichero excel con datos a incorporar a una base de datos, aunque este servicio no está implementado y solamente se simula su llamada, ya que el objetivo es crear el proceso background y no el resto de operaciones.

En la clase worker, implementamos el método **ExecuteAsync** en el cual ejecutamos nuestra tarea en segundo plano, en nuestro caso al estar en un bucle se repetirá cada hora. Para poder hospedar este servicio como un servicio windows es necesario instalar el paquete **Microsoft.Extensions.Hosting.WindowsServices**.

En la clase *program* configuramos el nombre de nuestro servicio en windows, en nuestro caso *"WorkerService_Demo"*. Además, aquí configuramos la inyección de dependencia de la interfaz *"IFileToDatabaseFakeService"* que no es más que una simulación de lo que podría ser un servicio para conectar con algún medio y leer un fichero para cargarlo en una base de datos.

Si queremos, podemos ver en el registro de eventos de aplicación de windows la información mostrada por nuestro servicio. Para ello sólo debemos añadir en el archivo appsettings lo siguiente :

"EventLog": {
      "LogLevel": {     
        "Default": "Information"       
      }     
    }   

La interfaz IHostedService nos sirve para el mismo propósito, para ello nuestra clase debe implementar su dos métodos :

  1. public Task StartAsync(CancellationToken stoppingToken)
  3. public Task StopAsync(CancellationToken stoppingToken)
