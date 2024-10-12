using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace T
{
    class Libreto
    {
        public List<Escena> Escenas { get; set; }

        public Libreto()
        {
            Escenas = new List<Escena>();
        }

        public void AgregarEscena(Escena escena)
        {
            Escenas.Add(escena);
        }

        public void EjecutarLibreto(Escenario escenario)
        {
            foreach (Escena escena in Escenas)
            {
                escena.Ejecutar(escenario);
                Thread.Sleep(100);
            }
        }
    }
}
