using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monstre
{
    class Agent
    {
        static int idCount = 0;

        //Posicion del agente
        int x;
        int y;

        //Id del agente
        int id;

        //Pos anterior
        int preX; int preY;

        //Registro de percepciones
        Percepcion[,] tablero;
        int n;

        //Tesoro encontrado
        bool found = false;

        public Agent(int x, int y, int n, ref Tablero t)
        {
            this.x = x;
            this.y = y;
            this.id = idCount++;
            tablero = new Percepcion[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tablero[i, j] = new Percepcion();
                }
            }
            this.n = n;
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

        public int PreX
        {
            get { return preX; }
            set { }
        }
        public int PreY
        {
            get { return preY; }
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
            tablero[x, y].Seguro = true;

            //Si detectamos tesoro iniciar vuelta (P.E marcar la salida como tesoro)
            if (found)
            {
                returningMovement(t);
            }
            else
            {
                seekingMovement();
            }
        }

        private void getPercepcion(Tablero t)
        {
            Percepcion p = new Percepcion();
            tablero[x, y] = t.getCell(x, y).percepcion;
        }

        private void returningMovement(Tablero t)
        {

        }

        private void seekingMovement()
        {
            //Si hay tesoro lo damos por encontrado y salioms
            if (tablero[x, y].Resplandor)
            {
                found = true;
                return;
            }

            int auxX = 0, auxY = 0;
            //Si detectamos hedor o brisa comprobamos las casillas colindantes
            if (tablero[x, y].Hedor || tablero[x, y].Brisa)
            {
                //Comprobar casilla anterior y colindantes a ella
                //Si hay posibilidad de explorar seguro por ahi, ir
                //Sino jugarsela
                if ((x != preX && y != preY) && safePath(preX, preY))
                {
                    auxX = preX; auxY = preY;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (!inBounds(auxX, auxY))
                        {
                            int dir = x - preX;
                            if (dir != 0) auxY += dir;

                            dir = y - preY;
                            if (dir != 0) auxX += dir;
                        }
                        else break;
                    }
                }
            }
            else
            {
                auxX = x + (x - preX);
                auxY = y + (y - preY);

                if (x == preX && y == preY)
                {
                    // Cambio de direccion (buscar una casilla colindante que no tenga percepciones negativas o,
                    // si todas tienen, ir a una de ellas).
                    directionChange(ref auxX, ref auxY);
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!inBounds(auxX, auxY))
                    {
                        directionChange(ref auxX, ref auxY);
                    } else if(tablero[auxX, auxY].Hedor || tablero[auxX, auxY].Brisa)
                    {
                        int dir = x - preX;
                        if (dir != 0) auxY += dir;

                        dir = y - preY;
                        if (dir != 0) auxX += dir;
                    }
                    else break;
                }
            }

            preX = x; x = auxX;
            preY = y; y = auxY;
        }

        private bool safePath(int x, int y)
        {
            if (tablero[x, y].Hedor || tablero[x, y].Brisa) return false;
            if (!tablero[x + 1, y].Hedor && !tablero[x + 1, y].Brisa) return true;
            if (!tablero[x, y + 1].Hedor && !tablero[x, y + 1].Brisa) return true;
            if (!tablero[x - 1, y].Hedor && !tablero[x - 1, y].Brisa) return true;
            if (!tablero[x, y - 1].Hedor && !tablero[x, y - 1].Brisa) return true;
            return false;
        }

        private bool inBounds(int x, int y)
        {
            return x >= 0 && x < n && y >= 0 && y < n;
        }

        private void directionChange(ref int auxX, ref int auxY)
        {
            if (auxX <= 0)
            {
                auxX++;
            }
            else if (auxX >= n)
            {
                auxX--;
            }
            else if (auxY <= 0)
            {
                auxY++;
            }
            else if (auxY >= n)
            {
                auxY--;
            }
        }

        public override string ToString()
        {
            return string.Format("Agent en posicio ({0}, {1}): \n", x, y);
        }

        public override bool Equals(object obj)
        {
            Agent a = (Agent)obj;
            return (id == a.id);
        }
    }
}
