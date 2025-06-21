namespace SistemaBancoAPI.Core.Entidades
{
    public class ResultadoOperacion
    {
        public bool Exito { get; private set; } = false;
        public string Mensaje { get; private set; } = string.Empty;

        private ResultadoOperacion(bool exito, string mensaje)
        {
            Exito = exito;
            Mensaje = mensaje;
        }

        public static ResultadoOperacion ExitoOperacion(string mensaje) => new ResultadoOperacion(true, mensaje);
        public static ResultadoOperacion Fallar(string mensaje) => new ResultadoOperacion(true, mensaje);
    }
}