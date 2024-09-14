using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace T
{
    class Objeto
    {
        public Dictionary<string, Parte> Partes {  get; set; }
        public Punto CentroMasa { get; set; }
  
        public Objeto(Punto centroMasa) 
        {
            Partes = new Dictionary<string, Parte>();
            CentroMasa = centroMasa;
        }
        public Punto GetCentro()
        {
            return CentroMasa;
        }

        public void Agregar(string nombre, Parte parte)
        {
            Partes.Add(nombre, parte);
        }

        public void Quitar(string nombre)
        {
            if (Partes.ContainsKey(nombre))
            {
                Partes.Remove(nombre);
            }
        }

        public Parte Obtener(string nombre)
        {
            if (Partes.ContainsKey(nombre))
            {
                return Partes[nombre];
            }
            return null;
        }

        public Dictionary<String, Parte> GetListaDeParte()
        {
            return Partes;
        }

        public Parte GetParte(string key)
        {
            return Partes[key];
        }

        public void Rotar(double x, double y, double z)
        {
            foreach (var parte in Partes)
            {
                parte.Value.Rotar(x, y, z);
            }
        }

        public void Trasladar(double x, double y, double z)
        {
            foreach (var parte in Partes)
            {
                parte.Value.Trasladar(x, y, z);
            }
        }

        public void Escalar(double x, double y, double z)
        {
            foreach (var parte in Partes)
            {
                parte.Value.Escalar(x, y, z);
            }
        }
        public void Dibujar(Punto centroMasaO) 
        {
            Punto nCentroMasa = centroMasaO + CentroMasa;
            foreach (var parte in Partes.Values)
            {
                parte.Dibujar(nCentroMasa);
            }

        }

    }
}
