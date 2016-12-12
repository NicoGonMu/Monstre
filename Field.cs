using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monstre
{
    class Field
    {
        public Common.eTipoCasilla entidad { get; set; }
        public Percepcion percepcion { get; set; }      
        
        public Field()
        {
            percepcion = new Percepcion();
            entidad = Common.eTipoCasilla.Suelo;        }
    }
}
