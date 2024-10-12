using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
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
            Matrix4 trasladarOrigen = Matrix4.CreateTranslation(-(float)centroMasa.X, -(float)centroMasa.Y, -(float)centroMasa.Z);

            Matrix4 rotacionX = Matrix4.CreateRotationX((float)aX);
            Matrix4 rotacionY = Matrix4.CreateRotationY((float)aY);
            Matrix4 rotacionZ = Matrix4.CreateRotationZ((float)aZ);

            Matrix4 rotacionTotal = rotacionX * rotacionY * rotacionZ;

            Matrix4 trasladarOriginal = Matrix4.CreateTranslation((float)centroMasa.X, (float)centroMasa.Y, (float)centroMasa.Z);

            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = puntos[i] * trasladarOrigen * rotacionTotal * trasladarOriginal;
            }
        }


        public void Trasladar(double x, double y, double z)
        {
            Matrix4 traslacion = Matrix4.CreateTranslation((float)x, (float)y, (float)z);

            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = puntos[i] * traslacion;
            }
        }

        public void Escalar(double x, double y, double z)
        {
            Matrix4 trasladarOrigen = Matrix4.CreateTranslation(-(float)centroMasa.X, -(float)centroMasa.Y, -(float)centroMasa.Z);

            Matrix4 escalado = Matrix4.CreateScale((float)x, (float)y, (float)z);

            Matrix4 trasladarOriginal = Matrix4.CreateTranslation((float)centroMasa.X, (float)centroMasa.Y, (float)centroMasa.Z);

            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i] = puntos[i] * trasladarOrigen * escalado * trasladarOriginal;
            }
        }

        public float DistanciaAPunto(Punto otro)
        {
            return centroMasa.Distancia(otro);
        }

        public void Dibujar (Punto centroMasaP)
        {
            Punto centroMasaN = centroMasaP + centroMasa;
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color.Brown);

            var puntosCopia = new List<Punto>(puntos);
            foreach (var punto in puntosCopia)
            {
                GL.Vertex3(punto.X + centroMasaN.X, punto.Y + centroMasaN.Y, punto.Z + centroMasaN.Z);
            }
            GL.End();
        }
    }
}
