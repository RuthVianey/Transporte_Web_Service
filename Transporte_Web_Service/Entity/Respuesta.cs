namespace Transporte_Web_Service.Entity
{
    public class Respuesta
    {
        private int estado = 31; /* 31 = CORRECTO(S VERDE) , 0 = wiarning advertencia (w amarillo) , -1 error (e rojo) */
        private string mensaje = "";
        private object datos = null;


        public void setEstatus(int estado) { this.estado = estado; }
        public void setMensaje(string mensaje) { this.mensaje = mensaje; }
        public void setDatos(object datos) { this.datos = datos; }


        public int getEstatus() { return this.estado; }
        public string getMensaje() { return this.mensaje; }
        public object getDatos() { return this.datos; }


        public object GetRespuestaJSON()
        {
            return new { status = this.estado, msg = this.mensaje, data = this.datos };
        }

        public class ResultadoSP
        {
            public int Resultado { get; set; }
        }
    }
}
