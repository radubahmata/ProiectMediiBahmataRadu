using System;
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
using System.Data.Entity;
using AgentieModel;
using System.Data;


namespace ProiectMediiBahmataRadu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }

    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        AgentieEntitiesModel ctx = new AgentieEntitiesModel();
        CollectionViewSource proprietatiVSource;
        CollectionViewSource contacteVSource;
        CollectionViewSource activitatiVSource;
        CollectionViewSource cereriVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            proprietatiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("proprietatiViewSource")));
            proprietatiVSource.Source = ctx.Proprietatis.Local;
            ctx.Proprietatis.Load();
            // Load data by setting the CollectionViewSource.Source property:
            // proprietatiViewSource.Source = [generic data source]
            contacteVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contacteViewSource")));
            contacteVSource.Source = ctx.Contactes.Local;
            ctx.Contactes.Load();
            // Load data by setting the CollectionViewSource.Source property:
            // contacteViewSource.Source = [generic data source]
            activitatiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("activitatiViewSource")));
            activitatiVSource.Source = ctx.Activitatis.Local;
            ctx.Activitatis.Load();
            // Load data by setting the CollectionViewSource.Source property:
            // activitatiViewSource.Source = [generic data source]
            //cereriVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cereriViewSource")));
            //cereriVSource.Source = ctx.Cereris.Local;
            //ctx.Cereris.Load();
            // Load data by setting the CollectionViewSource.Source property:
            // cereriViewSource.Source = [generic data source]
        }

        private void proprietatiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            proprietatiVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            proprietatiVSource.View.MoveCurrentToNext();
        }

        private void SaveProprietati()
        {
            Proprietati proprietate = null;
            if (action == ActionState.New)
            {
                try
                {
                    proprietate = new Proprietati()
                    {
                        adresa = adresaTextBox.Text.Trim(),
                        amplasament = amplasamentTextBox.Text.Trim(),
                        comision = Convert.ToInt32(comisionTextBox.Text),
                        id_contact = Convert.ToInt32(id_contactTextBox.Text),
                        nr_camere = Convert.ToInt32(nr_camereTextBox.Text),
                        pret = Convert.ToInt32(pretTextBox.Text),
                        suprafata = Convert.ToInt32(suprafataTextBox.Text),
                        tip_oferta = tip_ofertaTextBox.Text.Trim(),
                        zona = zonaTextBox.Text.Trim()
                    };

                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Edit)
            {
                try
                {
                    proprietate = (Proprietati)proprietatiDataGrid.SelectedItem;
                    proprietate.adresa = adresaTextBox.Text.Trim();
                    proprietate.amplasament = amplasamentTextBox.Text.Trim();
                    proprietate.comision = Convert.ToInt32(comisionTextBox.Text);
                    proprietate.id_contact = Convert.ToInt32(id_contactTextBox.Text);
                    proprietate.nr_camere = Convert.ToInt32(nr_camereTextBox.Text);
                    proprietate.pret = Convert.ToInt32(pretTextBox.Text);
                    proprietate.suprafata = Convert.ToInt32(suprafataTextBox.Text);
                    proprietate.tip_oferta = tip_ofertaTextBox.Text.Trim();
                    proprietate.zona = zonaTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    proprietate = (Proprietati)proprietatiDataGrid.SelectedItem;
                    ctx.Proprietatis.Remove(proprietate);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                proprietatiVSource.View.Refresh();
            }
        }
        private void SaveContacte()
        {
            Contacte contact = null;
            if (action == ActionState.New)
            {
                try
                {
                    contact = new Contacte()
                    {
                        mail = mailTextBox.Text.Trim(),
                        nr_tel = nr_telTextBox.Text.Trim(),
                        nume = numeTextBox.Text.Trim()                        
                    };

                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Edit)
            {
                try
                {
                    contact = (Contacte)contacteDataGrid.SelectedItem;
                    contact.mail = mailTextBox.Text.Trim();
                    contact.nr_tel = nr_telTextBox.Text.Trim();
                    contact.nume = numeTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    contact = (Contacte)contacteDataGrid.SelectedItem;
                    ctx.Contactes.Remove(contact);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                contacteVSource.View.Refresh();
            }
        }

        private void SaveActivitati()
        {
            Activitati activitate = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    activitate = new Activitati()
                    {
                      
                        data= dataDatePicker.SelectedDate.Value,
                        descriere = descriereTextBox.Text.Trim(),
                        id_contact = Convert.ToInt32(id_contactTextBox1.Text),
                        id_proprietate = Convert.ToInt32(id_proprietateTextBox.Text)
                        //LastName = lastNameTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Activitatis.Add(activitate);
                    activitatiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit) 
            {
                try
                {
                    activitate = (Activitati)activitatiDataGrid.SelectedItem;
                    activitate.data = dataDatePicker.SelectedDate.Value;
                    activitate.descriere = descriereTextBox.Text.Trim();
                    activitate.id_contact = Convert.ToInt32(id_contactTextBox1.Text);
                    activitate.id_proprietate = Convert.ToInt32(id_proprietateTextBox.Text);

                    //customer.LastName = lastNameTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    activitate = (Activitati)activitatiDataGrid.SelectedItem;
                    ctx.Activitatis.Remove(activitate);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                activitatiVSource.View.Refresh();
            }

        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {

            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbctrlAgentie.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Manager Proprietati":
                    SaveProprietati();
                    break;
                case "Activitati":
                    SaveActivitati();
                    break;
                //case "Orders":
                  //  break;
            }
            ReInitialize();
        }

        private void btnPrevContacte_Click(object sender, RoutedEventArgs e)
        {
            contacteVSource.View.MoveCurrentToPrevious();
        }

        private void btnNextContacte_Click(object sender, RoutedEventArgs e)
        {
            contacteVSource.View.MoveCurrentToNext();
        }

        private void btnPrevActivitati_Click(object sender, RoutedEventArgs e)
        {
            activitatiVSource.View.MoveCurrentToPrevious();
        }

        private void btnNextActivitati_Click(object sender, RoutedEventArgs e)
        {
            activitatiVSource.View.MoveCurrentToNext();
        }
    }
}
