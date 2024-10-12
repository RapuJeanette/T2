using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace T
{
    class Punto
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //constructor
        public Punto(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void SetVector(Punto vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }

        //sobrecarga del operador de suma
        public static Punto operator +(Punto a, Punto b) =>
            new Punto(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        // Sobrecarga del operador de multiplicación por una matriz 3x3
        public static Punto operator *(Punto a, Matrix3 b) =>
            new Punto(
                a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31,
                a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32,
                a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33
            );

        // Sobrecarga del operador de división
        public static Punto operator /(Punto a, Punto b) =>
            new Punto(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

        // Sobrecarga del operador de multiplicación por una matriz 4x4
        public static Punto operator *(Punto p, Matrix4 m)
        {
            float x = (float)(p.X * m.M11 + p.Y * m.M21 + p.Z * m.M31 + m.M41);
            float y = (float)(p.X * m.M12 + p.Y * m.M22 + p.Z * m.M32 + m.M42);
            float z = (float)(p.X * m.M13 + p.Y * m.M23 + p.Z * m.M33 + m.M43);
            return new Punto(x, y, z); // Retorna un nuevo punto
        }


        public Punto Normalize()
        {
            float length = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            if (length == 0) return new Punto(0, 0, 0); // Evitar división por cero
            return new Punto(X / length, Y / length, Z / length);
        }

        // Método para calcular la distancia entre dos puntos
        public float Distancia(Punto otro)
        {
            return (float)Math.Sqrt(Math.Pow(X - otro.X, 2) + Math.Pow(Y - otro.Y, 2) + Math.Pow(Z - otro.Z, 2));
        }
    }
}
