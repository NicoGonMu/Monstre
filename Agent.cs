using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monstre
{
    class Agent
    {
        //Posicion del agente
        int x;
        int y;
        
        //Id del agente
        int id;

        //Pos anterior
        int preX; int preY;

        //Registro de percepciones
        Percepcion[,] tablero;

        public Agent(int x, int y, int id, int n, ref Tablero t)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            tablero = new Percepcion[n, n];            
        }

        #region "GETTERS & SETTERS"
        public int X
        {
            get { return x; }
            set { }
        }
        public int Y
        {
            get { return y; }
            set { }
        }
        public Percepcion[,] Tablero
        {
            get { return tablero; }
            set { }
        }
        #endregion


        public void move(Tablero t)
        {
            //Actualitzacio de les percepcions
            getPercepcion(t);

            //Si detectamos hedor o brisa, volvemos a la casilla anterior
            if (tablero[x, y].Hedor || tablero[x, y].Brisa)
            {
                t.setCell(preX, preY, Common.eTipoCasilla.Agente);
                
            }


            //Actualitzacio dels sensors i la memoria
            update(t);
        }

        private void getPercepcion(Tablero t)
        {
            Percepcion p = new Percepcion();
            tablero[x, y] = t.getCell(x, y).percepcion;
        }

        private void update(Tablero t)
        {  

        }

        private void calculaAvance(ref int x, ref int y)
        {

        }


        public override string ToString()
        {                      
            return string.Format("Agent en posicio ({0}, {1}): \n", x, y);
        }

        public override bool Equals(object obj)
        {
            Agent r = (Agent)obj;
            return (x == r.x) && (y == r.y);
        }
    }
}
