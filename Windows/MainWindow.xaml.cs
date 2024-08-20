using System.Diagnostics;
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

namespace TillSaleScreenTest
{

    public partial class MainWindow : Window
    {
        public string newPrice = "40";

        //added for stackpanel
        private int total = 0;
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {

            //added new button to stackpanel
            //int count = 0;//stackThem2.Children.Count;
            //var btnName = "btn" + count;
            var btnName = "btn";
            //var btnString;
            var txtAmount = "txtAmount";// + count;
            var txtPrice = "txtPrice";// + count;

            TextBlock block1 = new TextBlock();
            block1.Text = "1";
            block1.Name = txtAmount;
            block1.TextAlignment = TextAlignment.Center;
            block1.IsHitTestVisible = false;
            block1.Height = 20;
            block1.Padding = new Thickness(0, 2, 0, 0);

            Button btnClicked = (Button)sender;
            string btnString = Convert.ToString(btnClicked.Content);

            ToggleButton btnAdd1 = new ToggleButton();
            btnAdd1.Content = btnString;
            btnAdd1.Name = btnName;
            btnAdd1.Checked += btnRemove_Checked;
            btnAdd1.BorderThickness = new Thickness(0);
            btnAdd1.Height = 20;

            TextBlock block2 = new TextBlock();
            block2.Text = newPrice;
            block2.Name = txtPrice;
            block2.TextAlignment = TextAlignment.Center;
            block2.IsHitTestVisible = false;
            block2.Height = 20;
            block2.Padding = new Thickness(0, 2, 0, 0);



            //ToggleButton toggleBut = (ToggleButton)sender;
            bool notFound = false;
            int position = 0;
            string getAmountLabel;
            string getPriceLabel;
            int setItem = 0;

            if (count > 0)
            {
                for (int i = 0; i <= count; i++)
                {
                    Debug.WriteLine(count);
                    foreach (UIElement item in stackThem2.Children)
                    {
                        if (item.GetType() == typeof(ToggleButton))
                        {
                            ToggleButton tglBut = (ToggleButton)item;
                            if (tglBut.Content == btnString)
                            {
                                position = stackThem2.Children.IndexOf(tglBut);
                                //runs through the loop and keeps running adding extra
                                //something to do with naming
                                getPriceLabel = "txtPrice" + position;
                                getAmountLabel = "txtAmount" + position;
                                Debug.WriteLine(getAmountLabel);
                                foreach (UIElement label in stackThem3.Children)
                                {
                                    if (label.GetType() == typeof(TextBlock))
                                    {
                                        TextBlock txtPriceLbl = (TextBlock)label;
                                        if (txtPriceLbl.Name == getPriceLabel)
                                        {
                                            Debug.WriteLine("were in " + getAmountLabel);
                                            string strLinePrice = txtPriceLbl.Text;
                                            int intLinePrice = Convert.ToInt32(strLinePrice);
                                            intLinePrice = intLinePrice + Convert.ToInt32(newPrice);
                                            strLinePrice = Convert.ToString(intLinePrice);
                                            txtPriceLbl.Text = strLinePrice;
                                            break;
                                        }
                                    }
                                }
                                foreach (UIElement label in stackThem1.Children)
                                {
                                    if (label.GetType() == typeof(TextBlock))
                                    {
                                        TextBlock txtAmountLbl = (TextBlock)label;
                                        if (txtAmountLbl.Name == getAmountLabel)
                                        {
                                            string strLineAmount = txtAmountLbl.Text;
                                            int intLineAmount = Convert.ToInt32(strLineAmount);
                                            intLineAmount = intLineAmount + 1;
                                            strLineAmount = Convert.ToString(intLineAmount);
                                            txtAmountLbl.Text = strLineAmount;
                                            break;
                                        }
                                    }
                                }
                                notFound = false;
                                break;
                            }
                            else
                            {
                                setItem = i;
                                notFound = true;
                            }
                        }
                    }
                }
                if (notFound)
                {
                    btnAdd1.Name = btnName + setItem;
                    block1.Name = txtAmount + setItem;
                    block2.Name = txtPrice + setItem;
                    stackThem1.Children.Add(block1);
                    stackThem2.Children.Add(btnAdd1);
                    stackThem3.Children.Add(block2);
                    count = count + 1;
                    notFound = false;
                    //return;
                }
            }
            else
            {
                block1.Name = txtAmount + 0;
                btnAdd1.Name = btnName + 0;
                block2.Name = txtPrice + 0;
                stackThem1.Children.Add(block1);
                stackThem2.Children.Add(btnAdd1);
                stackThem3.Children.Add(block2);
                count = count + 1;
            }
            /*
            //set location of new window
            PopWindow popWindow = new PopWindow();
            popWindow.WindowStyle = WindowStyle.None;
            popWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            popWindow.Left = 900;
            popWindow.Top = 600;
            popWindow.Show();
            */
        }
        private void btnRemove_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleBut = (ToggleButton)sender;
            string name = toggleBut.Name;
            bool deleted = false;
            for (int i = 0; i <= count; i++)
            {
                //string name = "btn" + i;
                foreach (UIElement item in stackThem2.Children)
                {
                    if (!deleted)
                    {

                        if (item.GetType() == typeof(ToggleButton))
                        {
                            //ToggleButton tglBut = (ToggleButton)item;
                            if (toggleBut.Name == name)
                            {
                                stackThem2.Children.RemoveAt(i);
                                stackThem1.Children.RemoveAt(i);
                                stackThem3.Children.RemoveAt(i);
                                toggleBut.IsChecked = false;
                                count = count - 1;
                                deleted = true;
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= count; i++)
            {
                var btnName = "btn";
                var blockName1 = "txtAmount";
                var blockName2 = "txtPrice";
                //ToggleButton tglBut = new ToggleButton();
                foreach (UIElement item in stackThem2.Children)
                {
                    if (item.GetType() == typeof(ToggleButton))
                    {
                        ToggleButton tglBut = (ToggleButton)item;
                        if (stackThem2.Children.IndexOf(tglBut) == i)
                        {
                            tglBut.Name = btnName + i;

                        }
                        //if ()
                    }
                }
                foreach (UIElement item in stackThem1.Children)
                {
                    if (item.GetType() == typeof(TextBlock))
                    {
                        TextBlock txtblock = (TextBlock)item;
                        if (stackThem1.Children.IndexOf(txtblock) == i)
                        {
                            txtblock.Name = blockName1 + i;

                        }
                        //if ()
                    }
                }
                foreach (UIElement item in stackThem3.Children)
                {
                    if (item.GetType() == typeof(TextBlock))
                    {
                        TextBlock txtblock = (TextBlock)item;
                        if (stackThem3.Children.IndexOf(txtblock) == i)
                        {
                            txtblock.Name = blockName2 + i;
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string strAmount;
            int amount;


            for (int i = 0; i <= count; i++)
            {
                string name = "txtPrice" + i;
                foreach (UIElement item in stackThem3.Children)
                {
                    if (item.GetType() == typeof(TextBlock))
                    {
                        TextBlock txtBlock = (TextBlock)item;
                        if (txtBlock.Name == name)
                        {
                            strAmount = txtBlock.Text;
                            amount = Convert.ToInt32(strAmount);
                            total = total + amount;
                        }
                    }
                }
            }
            Debug.WriteLine(total);
        }
    }
}