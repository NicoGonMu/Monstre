using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monstre
{
    class Field
    {
        public List<Common.eTipoCasilla> entidades { get; set; }
        public Percepcion percepcion { get; set; }      
        
        public Field()
        {
            percepcion = new Percepcion();
        }

        public void Set(Common.eTipoCasilla type)
        {
            entidades.Add(type);
        }

        public void Remove(Common.eTipoCasilla type)
        {
            entidades.Remove(type);
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
