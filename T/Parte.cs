using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace T
{
    class Parte
    {

        public Dictionary<string, Poligono> Poligonos;
        public Punto centroMasa { get; set; }

        public Parte (Punto centroMasa)
        {
            Poligonos = new Dictionary<string, Poligono>();
            this.centroMasa = centroMasa;
        }

        public Punto GetCentro()
        {
            return centroMasa;
        }
        public void Agregar(string nombre, Poligono poligono)
        {
            Poligonos.Add(nombre, poligono);
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

        public void Rotar(double x, double y, double z)
        {
            foreach (var p in Poligonos)
            {
                p.Value.Rotar(x, y, z);
            }
        }

        public void Trasladar(double x, double y, double z)
        {
            foreach (var p in Poligonos)
            {
                p.Value.Trasladar(x, y, z);
            }
        }

        public void Escalar(double x, double y, double z)
        {
            foreach (var p in Poligonos)
            {
                p.Value.Escalar(x, y, z);
            }
        }

        public void Dibujar(Punto centroMasaP)
        {
            Punto nuevoCentroMasa = centroMasaP + centroMasa;
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Dibujar(nuevoCentroMasa);
            }
        }
    }
}
