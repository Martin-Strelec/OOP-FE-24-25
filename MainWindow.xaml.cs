using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

            Ticket tic3 = new Ticket("Early Bird", 100m, 100);
            Ticket tic4 = new Ticket("Platinum", 150m, 100);
            VIPTicket vtic3 = new VIPTicket("Ticket and Hotel Package", 150m, 100, "4* Hotel", 100m);
            VIPTicket vtic4 = new VIPTicket("Weekend Ticket", 200m, 100, "with camping", 100m);

            //Adding tickets to Events
            ev1.Tickets.Add(tic1);
            ev1.Tickets.Add(tic2);
            ev1.Tickets.Add(vtic1);
            ev1.Tickets.Add(vtic2);

            ev2.Tickets.Add(tic3);
            ev2.Tickets.Add(tic4);
            ev2.Tickets.Add(vtic3);
            ev2.Tickets.Add(vtic4);

            //Adding to lists
            events.Add(ev1);
            events.Add(ev2);

            //Sorting events based on their date
            events.Sort();

            //Applying defaults
            if (events.Count != 0)
            {
                Event selected = events[0];

                lbxEvents.ItemsSource = events;
                lbxEvents.SelectedItem = selected;
                lbxTickets.ItemsSource = selected.Tickets;
            }
            
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            //Variables
            int value;
            Event selectedEvent = lbxEvents.SelectedItem as Event;
            Ticket selectedTicket = lbxTickets.SelectedItem as Ticket;

            //Checking for empty entry
            if (tbxBook.Text != null || tbxBook.Text != "")
            {
                //Paring the int
                if (int.TryParse(tbxBook.Text, out value))
                {
                    //Checking if both event and tickets are selected 
                    if (selectedEvent != null && selectedTicket != null)
                    {
                        //Value has to bo lower or equal to available tickets
                        if (value <= selectedTicket.AvailableTickets)
                        {
                            selectedTicket.AvailableTickets -= value;
                            //Removes the ticket from the selection if available ticket count reaches zero
                            if (selectedTicket.AvailableTickets == 0)
                            {
                                selectedEvent.Tickets.Remove(selectedTicket);
                            }
                            if (selectedEvent.Tickets.Count == 0)
                            {
                                events.Remove(selectedEvent);
                            }
                            tbkMessage.Text = "Ticket(s) booked!";

                            //Resetting ListBoxes
                            lbxTickets.ItemsSource = null;
                            lbxEvents.ItemsSource = null;

                            //Updating ListBoxes
                            lbxEvents.ItemsSource = events;
                            lbxTickets.ItemsSource = selectedEvent.Tickets;
                        }
                        else
                        {
                            //Error Message
                            tbkMessage.Text = "Tickest Sold out!";
                        }
                    }
                    else
                    {
                        //Error Message
                        tbkMessage.Text = "Wrong selection!";
                    }
                }
                else
                {
                    //Error Message
                    tbkMessage.Text = "Wrong Input!";
                }
            }
            else
            {
                //Error Message
                tbkMessage.Text = "Field is empty!";
            }


        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Checks if event is selected 
            if (lbxEvents.SelectedItem != null)
            {
                Event selected = lbxEvents.SelectedItem as Event;

                lbxTickets.ItemsSource = selected.Tickets;
            }
        }

        //Tried to create the search unsuccsessfully

        //private void tbxSearch_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    //Resetting Events
        //    events.Clear();

        //    //Formatting field value
        //    string searchValue = tbxSearch.Text.Trim().ToLower();

        //    //Checking each event
        //    foreach (Event match in events)
        //    {
        //        string eventName = match.Name.Trim().ToLower();
        //        for (int i = 0; i < searchValue.Length; i++)
        //        {
        //            if (eventName == searchValue)
        //            {
        //                events.Add(match);
        //            }
        //            else
        //            {
        //                events.Clear();
        //            }
        //        }
        //    }
        //}
    }
}