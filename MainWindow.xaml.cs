using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// REPO LINK
// https://github.com/Martin-Strelec/OOP-FE-24-25

namespace OOP_FE_24_25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Event> events = new List<Event>();
        List<Ticket> tickets = new List<Ticket>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Event objects
            Event ev1 = new Event("Oasis Croke Park", new DateTime(2025,06,20), Event.TypeOfEvent.Music);
            Event ev2 = new Event("Electric Picnic", new DateTime(2025, 08, 20), Event.TypeOfEvent.Music);

            //Ticket objects
            Ticket tic1 = new Ticket("Early Bird", 100m, 100);
            Ticket tic2 = new Ticket("Platinum", 150m, 100);
            VIPTicket vtic1 = new VIPTicket("Ticket and Hotel Package", 150m, 100, "4* Hotel", 100m);
            VIPTicket vtic2 = new VIPTicket("Weekend Ticket", 200m, 100, "with camping", 100m);

            //Adding to lists
            events.Add(ev1);
            events.Add(ev2);

            tickets.Add(tic1);
            tickets.Add(tic2);
            tickets.Add(vtic1);
            tickets.Add(vtic2);

            lbxEvents.ItemsSource = events;
            lbxTickets.ItemsSource = tickets;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            //Variables
            int value;
            Ticket selected = lbxTickets.SelectedItem as Ticket;

            //Resetting ListBoxes
            lbxEvents.ItemsSource = null;
            lbxTickets.ItemsSource = null;

            if (tbxBook != null)
            {
                if (int.TryParse(tbxBook.Text, out value) && (selected != null))
                {
                    if (value <= selected.AvailableTickets)
                    {
                        selected.AvailableTickets -= value;
                        tbkMessage.Text = "Ticket(s) booked!";
                    }
                    else
                    {
                        tbkMessage.Text = "Tickest Sold out!";
                    }
                }
                else
                {
                    tbkMessage.Text = "Wrong selection!";
                }
            }
            else
            {
                tbkMessage.Text = "Field is empty!";
            }

            //Updating ListBoxes
            lbxEvents.ItemsSource = events;
            lbxTickets.ItemsSource = tickets;
        }
    }
}