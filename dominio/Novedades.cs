using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Novedades
    {

        public Novedades() { }  

        public int idNovedad {  get; set; }
        public string TituloChicoIzq1 { get; set; } = "";
        public string TituloGrandeIzq2 { get; set; } = "";
        public string DescripcionIzq3 { get; set; } = "";
        public string BotonInfIzq4 { get; set; } = "";
        public string Card1Titulo {  get; set; } = "";
        public string Card1Precio { get; set; } = "";
        public string card1Subtitulo { get; set; } = "";
        public string Card2Titulo { get; set; } = "";
        public string Card2Precio { get; set; } = "";
        public string Card2Subtitulo { get; set; } = "";
        public string Card3Titulo { get; set; } = "";
        public string Card3Precio { get;set; } = "";
        public string Card3Subtitulo { get; set; } = "";
        public string DestacadoCard { get; set; } = "";
        public bool estadoNov { get; set; } = true;




    }
}
