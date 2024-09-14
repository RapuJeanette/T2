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
        public static Punto operator *(Punto a, Matrix4 b) =>
            new Punto(
                a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31 + 1.0 * b.M41,
                a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32 + 1.0 * b.M42,
                a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33 + 1.0 * b.M43
            );
    }
}
