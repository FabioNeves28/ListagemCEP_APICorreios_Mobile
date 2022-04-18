using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using listabrasil.Modelo;
using Newtonsoft.Json;

namespace listabrasil.Servico
{
    public class Servico
    {
        private static string URLEstado =
          "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private static string URLMunicipio =
            "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<Estado> GetEstados()
        {
            WebClient WC = new WebClient();
            string conteudo = WC.DownloadString(URLEstado);
            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);
        }

        public static List<Municipio> GetMunicipio(int estado)
        {
            string NewURL = string.Format(URLMunicipio, estado);
            WebClient WC = new WebClient();
            string conteudo = WC.DownloadString(NewURL);
            return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);
        }


    }
}
