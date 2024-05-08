namespace TorneoTenis.API.Models.Request
{
    public class JugadorRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Habilidad { get; set; } 
        public int Fuerza { get; set; }
        public int Velocidad { get; set; }
        public int Reaccion { get; set; }
        public bool EsHombre { get; set; }
    }
}
