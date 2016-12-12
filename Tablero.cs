

namespace Monstre
{
    class Tablero
    {
        private int length;
        private Field[,] tablero;

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public Field getCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= length || y >= length)
            {
                return null;
            }
            return tablero[x, y];
        }

        public Tablero(int max = 18)
        {
            Length = max;
            tablero = new Field[max, max];
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    tablero[i, j] = new Field();
                }
            }
        }

        public void clickInTablero(int x, int y, Common.eTipoCasilla type)
        {
            switch (type)
            {
                case Common.eTipoCasilla.Agente:
                    setCell(x, y, type);
                    break;
                case Common.eTipoCasilla.Monstruo:
                    setCell(x, y, type);
                    break;
                case Common.eTipoCasilla.Precipicio:
                    setCell(x, y, type);
                    break;
                case Common.eTipoCasilla.Tesoro:
                    setCell(x, y, type);
                    break;
                case Common.eTipoCasilla.Suelo:
                    removeCell(x, y);
                    break;
                default: break;
            }                        
        }

        public void removeCell(int x, int y) {
            setCell(x, y, Common.eTipoCasilla.Suelo);
        }

        public void setCell(int x, int y, Common.eTipoCasilla type)
        {
            tablero[x, y].entidad = type;
            expandPerceptions(x, y, type);
        }

        private void expandPerceptions(int x, int y, Common.eTipoCasilla type)
        {
            switch (type)
            {                
                case Common.eTipoCasilla.Monstruo:
                    if (x < length) tablero[x + 1, y].percepcion.Add('h');
                    if (x > 0) tablero[x - 1, y].percepcion.Add('h');
                    if (y < length) tablero[x, y + 1].percepcion.Add('h');
                    if (y > 0) tablero[x, y - 1].percepcion.Add('h');
                    break;
                case Common.eTipoCasilla.Precipicio:
                    if (x < length) tablero[x + 1, y].percepcion.Add('b');
                    if (x > 0) tablero[x - 1, y].percepcion.Add('b');
                    if (y < length) tablero[x, y + 1].percepcion.Add('b');
                    if (y > 0) tablero[x, y - 1].percepcion.Add('b');
                    break;
                default: break;
            }
        }
    }
}
