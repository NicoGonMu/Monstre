using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monstre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Worker for async painting
        BackgroundWorker bg = new BackgroundWorker();

        Tablero tablero;
        List<Agent> agentList = new List<Agent>();
        Common.eTipoCasilla selection = Common.eTipoCasilla.Suelo;
        int lastAgent = 2;
        int velocitat = 200;
        bool paused = true;


        public MainWindow()
        {
            InitializeComponent();
            Show();

            tablero = new Tablero(18);
            paint();
            vel.Text = 7 - velocitat / 100 + "";
            bg.DoWork += runAllRobots;
            bg.ProgressChanged += asyncPaint;
            bg.WorkerReportsProgress = true;
        }

        void paint() {
            TableroUI.Children.Clear();
            double size = (TableroUI.ActualHeight < TableroUI.ActualWidth - 100) ? TableroUI.ActualHeight / tablero.Length : (TableroUI.ActualWidth - 100) / tablero.Length;
            for (int i = 0; i < tablero.Length; i++) {
                for (int j = 0; j < tablero.Length; j++) {
                    Image image = new Image();
                    Field cell = tablero.getCell(i, j);
                    paintFloor(i, j, size);
                    switch (cell.entidades) {
                        case Common.eTipoCasilla.Agente:
                            var uriR = new Uri("pack://application:,,,/Textures/Nrobot.png");
                            image.Source = new BitmapImage(uriR);
                            break;
                        case Common.eTipoCasilla.Monstruo:
                            var uriM = new Uri("pack://application:,,,/Textures/devil.png");
                            image.Source = new BitmapImage(uriM);
                            break;
                        case Common.eTipoCasilla.Precipicio:
                            var uriRi = new Uri("pack://application:,,,/Textures/rift.png");
                            image.Source = new BitmapImage(uriRi);
                            break;
                        case Common.eTipoCasilla.Tesoro:
                            var uriT = new Uri("pack://application:,,,/Textures/treasure2.png");
                            image.Source = new BitmapImage(uriT);
                            break;
                        default: break;
                    }
                    image.Width = size;
                    image.Height = image.Width;
                    image.Margin = new Thickness(image.Width * i, image.Height * j, image.Width * (i + 1), image.Height * (j + 1));
                    TableroUI.Children.Add(image);
                }
            }

            //paintInternState();
        }

        void paintFloor(int i, int j, double size) {
            Image image = new Image();
            var uriF = new Uri("pack://application:,,,/Textures/floor.png");
            image.Source = new BitmapImage(uriF);
            image.Width = size;
            image.Height = image.Width;
            image.Margin = new Thickness(image.Width * i, image.Height * j, image.Width * (i + 1), image.Height * (j + 1));
            TableroUI.Children.Add(image);
        }

        void paintInternState() {
            
        }

        void Click(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);
            double size = ((TableroUI.ActualHeight < TableroUI.ActualWidth - 100) ? TableroUI.ActualHeight / tablero.Length : (TableroUI.ActualWidth - 100) / tablero.Length);

            int x = (int)(point.X / size);
            int y = (int)(point.Y / size);
            tablero.clickInTablero(x, y, selection);
            if (selection == Common.eTipoCasilla.Agente) {
                agentList.Add(new Agent(x, y, lastAgent, tablero.Length, ref tablero));
            }
            paint();
        }

        void clickOnAgent(object sender, RoutedEventArgs e) {
            selection = Common.eTipoCasilla.Agente;
            Agent.Background = Brushes.Gray;
            Treasure.Background = Brushes.LightGray;
            Monster.Background = Brushes.LightGray;
            Cliff.Background = Brushes.LightGray;
        }

        void clickOnTreasure(object sender, RoutedEventArgs e) {
            selection = Common.eTipoCasilla.Tesoro;
            Agent.Background = Brushes.LightGray;
            Treasure.Background = Brushes.Gray;
            Monster.Background = Brushes.LightGray;
            Cliff.Background = Brushes.LightGray;
        }

        void clickOnMonster(object sender, RoutedEventArgs e) {
            selection = Common.eTipoCasilla.Monstruo;
            Agent.Background = Brushes.LightGray;
            Treasure.Background = Brushes.LightGray;
            Monster.Background = Brushes.Gray;
            Cliff.Background = Brushes.LightGray;
        }

        void clickOnCliff(object sender, RoutedEventArgs e) {
            selection = Common.eTipoCasilla.Precipicio;
            Agent.Background = Brushes.LightGray;
            Treasure.Background = Brushes.LightGray;
            Monster.Background = Brushes.LightGray;
            Cliff.Background = Brushes.Gray;
        }

        void removeSelection(object sender, RoutedEventArgs e) {
            selection = Common.eTipoCasilla.Suelo;
            Agent.Background = Brushes.LightGray;
            Treasure.Background = Brushes.LightGray;
            Monster.Background = Brushes.LightGray;
            Cliff.Background = Brushes.LightGray;
        }

        void decVel(object sender, RoutedEventArgs e)
        {
           
        }


        void incVel(object sender, RoutedEventArgs e)
        {
            
        }


        void startProcess(object sender, RoutedEventArgs e)
        {
            
        }

        void stepProcess(object sender, RoutedEventArgs e)
        {
            agentList.First().move(tablero);
        }

        
        void changeSize(object sender, RoutedEventArgs e) {
            try {
                tablero = new Tablero(int.Parse(changeSizeBox.Text));
            } catch (Exception) {
                MessageBox.Show("Please, only numbers here. Thanks");
            }
            
            paint();
        }

        private void runAllRobots(object sender, DoWorkEventArgs e)
        {
            
        }

        private void asyncPaint(object sender, ProgressChangedEventArgs e)
        {
          
        }

        private void handleRobotList(int x, int y, bool occupied)
        {
            
        }
    }
}
