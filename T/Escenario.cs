using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;

namespace T
{
    class Escenario
    {
        public Dictionary<string, Objeto> Objeto { get; set; }
        public Punto CentroMasa { get; set; }

        public Escenario(Punto centroMasa)
        {
            Objeto = new Dictionary<string, Objeto>();
            CentroMasa = centroMasa;
        }

        public Escenario(Dictionary<string, Objeto> deObjetos, Punto centro)
        {
            this.Objeto = deObjetos;
            this.CentroMasa = centro;

            foreach (var objeto in deObjetos)
            {
                Punto nuevoCentrObjeto = objeto.Value.GetCentro() + CentroMasa;
                objeto.Value.CentroMasa = nuevoCentrObjeto;

                foreach (var parte in objeto.Value.Partes)
                {
                    Punto nuevoCentroParte = parte.Value.GetCentro() + nuevoCentrObjeto;
                    parte.Value.centroMasa = nuevoCentroParte;

                    foreach (var poligono in parte.Value.Poligonos)
                    {
                        Punto nuevoCentroPoligono = poligono.Value.GetCentro() + nuevoCentroParte;
                        poligono.Value.centroMasa = nuevoCentroPoligono;
                    } 
                }
            }
        }

        public void Agregar(string nombre, Objeto objeto)
        {
            Objeto.Add(nombre, objeto);
        }

        public void Quitar(string nombre)
        {
            if (Objeto.ContainsKey(nombre))
            {
                Objeto.Remove(nombre);
            }
        }

        public Objeto Obtener(string nombre)
        {
            if (Objeto.ContainsKey(nombre))
            {
                return Objeto[nombre];
            }
            return null;
        }

        public Objeto GetObjeto(String key)
        {
            return Objeto[key];
        }

        public void Rotar(double x, double y, double z)
        {
            foreach (var objeto in Objeto)
            {
                objeto.Value.Rotar(x, y, z);
            }
        }

        public void Trasladar(double x, double y, double z)
        {
            foreach (var objeto in Objeto)
            {
                objeto.Value.Trasladar(x, y, z);
            }
        }

        public void Escalar(double x, double y, double z)
        {
            foreach (var objeto in Objeto)
            {
                objeto.Value.Escalar(x, y, z);
            }
        }
        public void Dibujar()
        {
            foreach (var objeto in Objeto.Values)
            {
                objeto.Dibujar(CentroMasa);
            }
        }
    }
}
