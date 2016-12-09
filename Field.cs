using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monstre
{
    class Field
    {
        public Common.eTipoCasilla entidades { get; set; }
        public Percepcion percepcion { get; set; }      
        
        public Field()
        {
            percepcion = new Percepcion();
            Set(Common.eTipoCasilla.Suelo);
        }

        public void Set(Common.eTipoCasilla type)
        {
            entidades = type;
        }

        public void Remove()
        {
            Set(Common.eTipoCasilla.Suelo);
        }

        public void Set(char c)
        {
            percepcion.Add(c);
        }

        public void Remove(char c)
        {
            percepcion.Remove(c);
        }

    }
}
