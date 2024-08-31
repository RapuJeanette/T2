using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace T
{
    public class Parte
    {

        public Dictionary<string, Poligono> Poligonos { get; set; }
        public Vector3 centroMasa { get; set; }

        public Parte (Vector3 centroMasa)
        {
            Poligonos = new Dictionary<string, Poligono>();
            this.centroMasa = centroMasa;
        }

        public void Agregar(string nombre, Poligono poligono)
        {
            Poligonos[nombre] = poligono;
        }

        public void Quitar(string nombre)
        {
            if (Poligonos.ContainsKey(nombre))
            {
                Poligonos.Remove(nombre);
            }
        }

        public Poligono Obtener(string nombre)
        {
            if (Poligonos.ContainsKey(nombre))
            {
                return Poligonos[nombre];
            }
            return null;
        }

        public void Dibujar(Vector3 centroMasaP)
        {
            Vector3 nuevoCentroMasa = centroMasaP + centroMasa;
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Dibujar(nuevoCentroMasa);
            }
        }
    }
}
