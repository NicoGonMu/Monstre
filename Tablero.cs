

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
                case Common.eTipoCasilla.Monstruo:
                case Common.eTipoCasilla.Precipicio:
                case Common.eTipoCasilla.Tesoro:
                default: break;
            }                        
        }

        public void setCell(int x, int y, Common.eTipoCasilla type)
        {
            tablero[x, y].Set(type);
        }

        private void expandPerceptions(int x, int y, Common.eTipoCasilla type)
        {
            switch (type)
            {                
                case Common.eTipoCasilla.Monstruo:
                    if (x < length) tablero[x + 1, y].Set('h');
                    if (x > 0) tablero[x - 1, y].Set('h');
                    if (y < length) tablero[x, y + 1].Set('h');
                    if (y > 0) tablero[x, y - 1].Set('h');
                    break;
                case Common.eTipoCasilla.Precipicio:
                    if (x < length) tablero[x + 1, y].Set('b');
                    if (x > 0) tablero[x - 1, y].Set('b');
                    if (y < length) tablero[x, y + 1].Set('b');
                    if (y > 0) tablero[x, y - 1].Set('b');
                    break;
                default: break;
            }
        }
    }
}
