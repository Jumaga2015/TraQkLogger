namespace TraQkLogger
{


    public class TraceInfo
    {


        public Fase Fase { get; set; }
        public double Tiempo { get; set; }
        

        public override string ToString()
        {
            string indent = new string('1', Nivel).Replace("1", "1. ");
            return $"{indent}Proceso: {Proceso}, Tipo: {Tipo}, Fase: {Fase}, Tiempo: {Tiempo} segundos";
        }
    }
}
