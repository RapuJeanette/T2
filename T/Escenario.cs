using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;

namespace T
{
    public class Escenario
    {
        public Dictionary<string, Objeto> Objeto { get; set; }
        public Vector3 CentroMasa { get; set; }

        public Escenario(Vector3 centroMasa)
        {
            Objeto = new Dictionary<string, Objeto>();
            CentroMasa = centroMasa;
            InicializarObjetos();
        }

        public void Agregar(string nombre, Objeto objeto)
        {
            Objeto[nombre] = objeto;
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

        public void Dibujar()
        {
            foreach (var objeto in Objeto.Values)
            {
                objeto.Dibujar(CentroMasa);
            }
        }

        private void InicializarObjetos()
        {
            Objeto t = new Objeto(new Vector3(0.3f, -0.9f, -0.05f));
            Parte parte = new Parte(new Vector3(0, 1, 0));
            Poligono adelante = new Poligono(new List<Vector3>
            {
                new Vector3(0.0f, 0.6f, 0.0f),
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.2f, 0.0f, 0.0f),
                new Vector3(0.2f, 0.6f, 0.0f),
                new Vector3(0.4f, 0.6f, 0.0f),
                new Vector3(0.4f, 0.8f, 0.0f),
                new Vector3(-0.2f, 0.8f, 0.0f),
                new Vector3(-0.2f, 0.6f, 0.0f)
            }, new Vector3(0.5f, 0.5f, 0));

            Parte parte2 = new Parte(new Vector3(0, 0, 0));
            Poligono atras = new Poligono(new List<Vector3>
            {
                new Vector3(0.0f, 0.6f, 0.2f),
                new Vector3(0.0f, 0.0f, 0.2f),
                new Vector3(0.2f, 0.0f, 0.2f),
                new Vector3(0.2f, 0.6f, 0.2f),
                new Vector3(0.4f, 0.6f, 0.2f),
                new Vector3(0.4f, 0.8f, 0.2f),
                new Vector3(-0.2f, 0.8f, 0.2f),
                new Vector3(-0.2f, 0.6f, 0.2f)
            }, new Vector3(0,0,0.2f));

            Parte parte3 = new Parte(new Vector3(0, 0, 0));
            Poligono ladoI = new Poligono(new List<Vector3>
            {
                new Vector3(0.0f, 0.0f, 0.2f),
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.0f, 0.6f, 0.0f),
                new Vector3(0.0f, 0.6f, 0.2f),
            }, new Vector3(0, 0, 0.2f));

            Poligono ladoIz = new Poligono(new List<Vector3>
            {
                new Vector3(-0.2f, 0.8f, 0.2f),
                new Vector3(-0.2f, 0.8f, 0.0f),
                new Vector3(-0.2f, 0.6f, 0.0f),
                new Vector3(-0.2f, 0.6f, 0.2f),
            }, new Vector3(0, 0, 0.2f));

            Parte parte4 = new Parte(new Vector3(0, 0, 0));
            Poligono ladoD = new Poligono(new List<Vector3>
            {
                new Vector3(0.2f, 0.0f, 0.2f),
                new Vector3(0.2f, 0.0f, 0.0f),
                new Vector3(0.2f, 0.6f, 0.0f),
                new Vector3(0.2f, 0.6f, 0.2f),
            }, new Vector3(0, 0, 0.2f));

            Poligono ladoDe = new Poligono(new List<Vector3>
            {
                new Vector3(0.4f, 0.8f, 0.2f),
                new Vector3(0.4f, 0.8f, 0.0f),
                new Vector3(0.4f, 0.6f, 0.0f),
                new Vector3(0.4f, 0.6f, 0.2f),
            }, new Vector3(0, 0, 0.2f));

            parte.Agregar("poligono1", adelante);
            parte2.Agregar("poligono2", atras);
            parte3.Agregar("poligono3", ladoD);
            parte3.Agregar("poligono4", ladoDe);
            parte4.Agregar("poligono5", ladoI);
            parte4.Agregar("poligono6", ladoIz);
            t.Agregar("parte1", parte);
            t.Agregar("parte2", parte2);
            t.Agregar("parte3", parte3);
            t.Agregar("parte4", parte4);
            Agregar("t", t);
        }
    }
}
