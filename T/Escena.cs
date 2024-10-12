using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    class Escena
    {
        public Action<Escenario> Transformaciones { get; set; }

        public Escena(Action<Escenario> transformaciones)
        {
            Transformaciones = transformaciones;
        }

        public void Ejecutar(Escenario escenario)
        {
            Transformaciones(escenario);
        }
    }
}
