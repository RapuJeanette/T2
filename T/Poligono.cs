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
    class Poligono
    {
        public List<Punto> puntos;
        public Punto centroMasa;
        public Color Color;

        public Poligono (List<Punto> punto, Punto centroMasa)
        {
            this.puntos = punto;
            this.centroMasa = centroMasa;
        }

        public Punto GetCentro()
        {
            return centroMasa;
        }

        public void Dibujar (Punto centroMasaP)
        {
            Punto centroMasaN = centroMasaP + centroMasa;
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color.Brown);
            foreach(var punto in puntos)
            {
                GL.Vertex3(punto.X + centroMasaN.X, punto.Y + centroMasaN.Y, punto.Z + centroMasaN.Z);
            }
            GL.End();
        }
    }
}
