
namespace Monstre
{
    class Percepcion
    {
        public bool Hedor { get; set; }
        public bool Brisa { get; set; }
        public bool Resplandor { get; set; }        

        public Percepcion()
        {
            Hedor = Brisa = Resplandor = false;
        }

        public void Add(char c)
        {
            switch (c)
            {
                case 'h':
                    Hedor = true;
                    break;
                case 'b':
                    Brisa = true;
                    break;
                case 'r':
                    Resplandor = true;
                    break;                
            }
        }
        public void Remove(char c)
        {
            switch (c)
            {
                case 'h':
                    Hedor = false;
                    break;
                case 'b':
                    Brisa = false;
                    break;
                case 'r':
                    Resplandor = false;
                    break;
            }
        }
    }
}
