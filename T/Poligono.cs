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
    public class Poligono
    {
        public List<Vector3> Puntos { get; set; }
        public Vector3 centroMasa { get; set; }

        public Poligono (List<Vector3> puntos, Vector3 centroMasa)
        {
            Puntos = puntos;
            this.centroMasa = centroMasa;
        }

        public void Dibujar (Vector3 centroMasaP)
        {
            Vector3 centroMasaN = centroMasaP + centroMasa;
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color.Black);
            foreach(var punto in Puntos)
            {
                GL.Vertex3(punto);
            }
            GL.End();
        }
    }
}
