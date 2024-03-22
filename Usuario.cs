namespace GSBANK
{
    public class Usuario
    {
        public Usuario()
        {
            // Inicializar las propiedades en el constructor
            Nombres = "";
            ApellidoPaterno = "";
            ApellidoMaterno = "";
            GrupoSanguineo = "";
            Rh = "";
            NumeroTelefonico = "";
            Direccion = "";
        }

        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Rh { get; set; }
        public string NumeroTelefonico { get; set; }
        public string Direccion { get; set; }
    }
}
