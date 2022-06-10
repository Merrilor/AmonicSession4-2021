using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Session4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Surveys> SurveyList;

        SurveySummary Summary { get; set; }

        

        public MainWindow()
        {
            InitializeComponent();

            Session4Entities entities = new Session4Entities();

            SurveyList = entities.Surveys.ToList();            

            Summary = new SurveySummary
            {
                RecordAmount = SurveyList.Count(),
                MaleAmount = SurveyList.Where(s => s.Gender == "M").Count(),
                FemaleAmount = SurveyList.Where(s => s.Gender == "F").Count(),
                AgeGroup1Amount = SurveyList.Where(s => s.Age >= 18 && s.Age <= 24).Count(),
                AgeGroup2Amount = SurveyList.Where(s => s.Age >= 25 && s.Age <= 39).Count(),
                AgeGroup3Amount = SurveyList.Where(s => s.Age >= 40 && s.Age <= 59).Count(),
                AgeGroup4Amount = SurveyList.Where(s => s.Age >= 60).Count(),
                EconomyCabinAmount = SurveyList.Where(s => s.CabinType == "Economy").Count(),
                BusinessCabinAmount = SurveyList.Where(s => s.CabinType == "Business").Count(),
                FirstCabinAmount = SurveyList.Where(s => s.CabinType == "First").Count(),
                AuhAmount = SurveyList.Where(s => s.Arrival == "AUH").Count(),
                BahAmount = SurveyList.Where(s => s.Arrival == "BAH").Count(),
                DohAmount = SurveyList.Where(s => s.Arrival == "DOH").Count(),
                RuhAmount = SurveyList.Where(s => s.Arrival == "RUH").Count(),
                CaiAmount = SurveyList.Where(s => s.Arrival == "CAI").Count(),


            };

            DataContext = Summary;


            MainFrame.Content = new SummaryPage(Summary,SurveyList);

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DetailedResultsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DetailedResultsPage(SurveyList);
            this.Width = 1300;
            this.Height = 900;

            

        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new SummaryPage(Summary, SurveyList));
            this.Width = 1000;
            this.Height = 430;
        }
    }


    public class SurveySummary
    {

        public int RecordAmount { get; set; }

        public int MaleAmount { get; set; }

        public int FemaleAmount { get; set; }

        public int AgeGroup1Amount { get; set; }
        public int AgeGroup2Amount { get; set; }
        public int AgeGroup3Amount { get; set; }
        public int AgeGroup4Amount { get; set; }

        public int EconomyCabinAmount { get; set; }
        public int BusinessCabinAmount { get; set; }
        public int FirstCabinAmount { get; set; }

        public int AuhAmount { get; set; }
        public int BahAmount { get; set; }
        public int DohAmount { get; set; }
        public int RuhAmount { get; set; }
        public int CaiAmount { get; set; }


    }

}
