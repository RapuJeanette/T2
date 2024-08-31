using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace T
{
    public class Objeto
    {
        public Dictionary<string, Parte> Partes {  get; set; }
        public Vector3 CentroMasa { get; set; }
  
        public Objeto(Vector3 centroMasa) 
        {
            Partes = new Dictionary<string, Parte>();
            CentroMasa = centroMasa;
        }

        public void Agregar(string nombre, Parte parte)
        {
            Partes[nombre] = parte;
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
        public void Dibujar(Vector3 centroMasaO) 
        {
            Vector3 nCentroMasa = centroMasaO + CentroMasa;
            foreach (var parte in Partes.Values)
            {
                parte.Dibujar(nCentroMasa);
            }


        }

    }
}
