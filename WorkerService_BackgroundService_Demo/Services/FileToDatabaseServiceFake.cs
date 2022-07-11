namespace WorkerService_BackgroundService_Demo.Services
{
    public class FileToDatabaseFakeService : IFileToDatabaseFakeService
    {
        private readonly ILogger logger;

        // Simulación de un servicio que busque un fichero excell y vuelque sus datos a una base de datos 
        // una vez temrinado el proceso elimina el fichero para no repetirlo.
        // Tambien se podría llevar algún tipo de registro en la propia bbdd sobre ficheros ya procesados y de esta forma si falla el borrado no repetirá ficheros anteriores

        public FileToDatabaseFakeService(ILogger<FileToDatabaseFakeService> logger)
        {
            this.logger = logger;
        }

        public async Task<bool> Volcarfichero()
        {
            string fileName = string.Empty;
            try
            {
                fileName = "Nombre de fichero si se encuentra";

                //Buscaría un fichero en un disco o en un servidor FTP o cualquier otro lugar
                //lo leería y volcaría sus datos a una tabla de una base de datos.
                //Incluso se podría hacer que según el nombre del fichero se volcará en una tabla con el mismo nombre
                //así serviría para diferentes datos de diferentes tablas

                File.Delete(fileName);
                
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error volcando el fichero {fileName} a las {DateTime.Now}. Mensaje de error : {ex.Message}");
                return await Task.FromResult(false);
            }                        
        }
    }
}
