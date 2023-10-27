using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LeyDeHount.Domain;

namespace LeyDeHount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int populationT; 
        int abstentionsT; 
        int nullvotesT;
        Party parties;
        public MainWindow()
        {
            InitializeComponent();
            parties = new Party();
            dgParties.ItemsSource = parties.getListParties();
        }

        public void InsertData(object sender, RoutedEventArgs e)
        {
            if (txtPopulation.Text != "" && txtAbstentionsVotes.Text != "" && txtNullVotes.Text != "")
            {
                if (Regex.IsMatch(txtPopulation.Text, @"[0-9]") && Regex.IsMatch(txtAbstentionsVotes.Text, @"[0-9]") 
                    && int.Parse(txtPopulation.Text)> int.Parse(txtAbstentionsVotes.Text))
                {
                    populationT = int.Parse(txtPopulation.Text);
                    abstentionsT = int.Parse(txtAbstentionsVotes.Text);
                    if (populationT > abstentionsT)
                    {
                        nullvotesT = int.Parse(txtNullVotes.Text);
                        tab2.IsEnabled = true;
                    }
                    
                }
            }
        }

        public void NullVotes(object sender, TextChangedEventArgs e)
        {
            int population;
            int abstentions;
            int nullvotes;

            if (txtPopulation.Text != "" & txtAbstentionsVotes.Text != "")
            {
                if (Regex.IsMatch(txtPopulation.Text, @"[0-9]") && Regex.IsMatch(txtAbstentionsVotes.Text, @"[0-9]"))
                {
                    population = int.Parse(txtPopulation.Text);
                    abstentions = int.Parse(txtAbstentionsVotes.Text);
                    if (population > abstentions) {
                        nullvotes = (population - abstentions) / 20;

                        txtNullVotes.Text = nullvotes.ToString();
                    }
                }
            }
        }

        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("seleccionado");
        }

        private void DeleteParties(object sender, RoutedEventArgs e)
        {
            var partiesSelect = dgParties.SelectedItems.Cast<Party>().ToList();

            foreach (var party in partiesSelect)
            {
                parties.deleteParty(party);
            }
            dgParties.Items.Refresh();
            if (parties.getListParties().Count == 0)
            {
                btnDelete.IsEnabled = false;
            }

            tab3.IsEnabled = false;
        }

        private void SaveParty(object sender, RoutedEventArgs e)
        {
            var existe = false;
            if (txtAcronym.Text != "" & txtNameOfParty.Text != "" & txtPresident.Text != "" & parties.getListParties().Count <= 10)
            {
                foreach (var party in parties.getListParties())
                {
                    if (party.namep.Equals(txtNameOfParty.Text))
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    parties.addParty(txtAcronym.Text, txtNameOfParty.Text, txtPresident.Text);
                    dgParties.Items.Refresh();
                    txtAcronym.Text = "";
                    txtNameOfParty.Text = "";
                    txtPresident.Text = "";
                    btnDelete.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("El nombre del partido ya existe");
                }

                if (parties.getListParties().Count == 10) {
                    tab3.IsEnabled = true;
                }
            }
        }

        private void ExecuteSimulation(object sender, RoutedEventArgs e)
        {
            double[] porcent = {0.3525, 0.2475,0.1575,0.1425,0.0375, 0.0325, 0.015, 0.005,0.0025, 0.0025 };
            int[] votesparties = new int[10];
            int totalvotes = populationT - nullvotesT;

            for (int i = 0; i < votesparties.Length; i++)
            {
                votesparties[i] = (int)(totalvotes * porcent[i]);
            }
        }
    }
}
