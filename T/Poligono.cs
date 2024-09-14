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

        public void Rotar(double aX, double aY, double aZ)
        {
            foreach (var p in puntos)
            {
                double X = p.X;
                double Y = p.Y;
                double Z = p.Z;

                double nuevoY = Y * Math.Cos(aX) - Z * Math.Sin(aX);
                double nuevoZ = Y * Math.Sin(aX) - Z * Math.Cos(aX);
                Y = nuevoY;
                Z = nuevoZ;

                double nuevoX = X * Math.Cos(aY) + Z * Math.Sin(aY);
                nuevoZ = X * Math.Sin(aY) + Z * Math.Cos(aY);

                X = nuevoX;
                Z = nuevoZ;

                nuevoX = X * Math.Cos(aZ) - Y * Math.Sin(aZ);
                nuevoY = X * Math.Sin(aZ) + Y * Math.Cos(aZ);
                X = nuevoX;
                Y = nuevoY;

                p.X = X; 
                p.Y = Y;
                p.Z = Z;
            }
        }

        public void Trasladar(double x, double y, double z)
        {
            foreach (var p in puntos)
            {
                p.X += x;
                p.Y += y;
                p.Z += z;
            }
        }

        public void Escalar(double x, double y, double z)
        {
            foreach (var p in puntos)
            {
                p.X *= x;
                p.Y *= y;
                p.Z *= z;
            }
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
