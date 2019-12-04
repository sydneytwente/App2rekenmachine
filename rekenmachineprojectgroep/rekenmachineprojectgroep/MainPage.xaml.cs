using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace rekenmachineprojectgroep
{

    public sealed partial class MainPage : Page
    {
        private string text = "";
        private bool komma = false;
        private double getal1, getal2;
        private bool euro = true;
        private bool dollar = false;
        private bool erbij = false, eraf = false, maal = false, delen = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnNul_Click(object sender, RoutedEventArgs e)
        {
            text += "0";
            resultbox.Text = text;
            history.Text = resultbox.Text;
        }

        private void btnEen_Click(object sender, RoutedEventArgs e)
        {
            text += "1";
            resultbox.Text = text;
        }

        private void btnTwee_Click(object sender, RoutedEventArgs e)
        {
            text += "2";
            resultbox.Text = text;
        }

        private void btnDrie_Click(object sender, RoutedEventArgs e)
        {
            text += "3";
            resultbox.Text = text;
        }

        private void btnVier_Click(object sender, RoutedEventArgs e)
        {
            text += "4";
            resultbox.Text = text;
        }

        private void btnVijf_Click(object sender, RoutedEventArgs e)
        {
            text += "5";
            resultbox.Text = text;
        }

        private void btnZes_Click(object sender, RoutedEventArgs e)
        {
            text += "6";
            resultbox.Text = text;
        }

        private void btnZeven_Click(object sender, RoutedEventArgs e)
        {
            text += "7";
            resultbox.Text = text;
        }

        private void btnAcht_Click(object sender, RoutedEventArgs e)
        {
            text += "8";
            resultbox.Text = text;
        }

        private void btnNegen_Click(object sender, RoutedEventArgs e)
        {
            text += "9";
            resultbox.Text = text;
        }

        private void komma_Click(object sender, RoutedEventArgs e)
        {
            if (komma != true)
            {
                komma = true;
                if (text == "")
                    text = "0,";
                else
                    text += ",";

                resultbox.Text = text;
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                history.Text = resultbox.Text;
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                erbij = true;
                text = "";
                resultbox.Text = "";
                komma = false;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                eraf = true;
                text = "";
                resultbox.Text = "";
                komma = false;
            }
        }

        private void btnKeer_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                maal = true;
                text = "";
                resultbox.Text = "";
                komma = false;
            }
        }

        private void btnDeel_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                delen = true;
                text = "";
                resultbox.Text = "";
                komma = false;
            }
        }

        private void btnPrencentage_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                if (komma != true)
                {
                    komma = true;
                    if (text == "")
                        text = "0,";
                    else
                        text += "%";

                    resultbox.Text = text;
                }
            }
        }

        private void btnEuro_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                if (!euro)
                {
                    string newText = resultbox.Text.Replace(',', '.');
                    getal1 = Convert.ToDouble(newText);
                    newText = EuroConverter(getal1).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    euro = true;
                    dollar = false;
                }
            }
        }

        private void btnDollar_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                if (!dollar)
                {
                    string newText = resultbox.Text.Replace(',', '.');
                    getal1 = Convert.ToDouble(newText);
                    newText = DollarConverter(getal1).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    euro = false;
                    dollar = true;
                }
            }
        }

        private void btnWis_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            resultbox.Text = text;
            komma = false;
            erbij = false;
            eraf = false;
            maal = false;
            delen = false;
            getal1 = 0;
            getal2 = 0;
            //dit reset de getallen
        }

        private void btnWis1_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            resultbox.Text = text;
            komma = false;
            erbij = false;
            eraf = false;
            maal = false;
            delen = false;
            getal1 = 0;
            getal2 = 0;
            //dit reset de getal
        }

        private void btnBinear_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToInt32(newText);

                int i;

                int[] binaryArray = new int[10];

                for (i = 0; getal1 > 0; i++)
                {
                    binaryArray[i] = (int)getal1 % 2;
                    getal1 = (int)getal1 / 2;
                }
                newText = "";
                for (i = i - 1; i >= 0; i--)
                {
                    newText += (binaryArray[i]);
                    resultbox.Text = newText.Replace('.', ',');
                }
            }

        }

        private void btnHex_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');


                resultbox.Text = newText.Replace('.', ',');

            }

        }

        private void btnPlusmin_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal1 = Convert.ToDouble(newText);
                getal1 = getal1 * -1;
                newText = (getal1).ToString();
                resultbox.Text = newText.Replace('.', ',');
            }
        }


        private double add(double a, double b)
        {
            return a + b;
        }

        private double minus(double a, double b)
        {
            return a - b;
        }

        private void tbDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private double multply(double a, double b)
        {
            return a * b;
        }

        private void historytextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private double divide(double a, double b)
        {
            return a / b;
        }
        private double EuroConverter(double a)
        {
            return a * 1.3;
        }

        private double DollarConverter(double a)
        {
            return a / 1.3;
        }
        private void btnBereken_Click(object sender, RoutedEventArgs e)
        {
            if (resultbox.Text != "")
            {
                string newText = resultbox.Text.Replace(',', '.');
                getal2 = Convert.ToDouble(newText);
                text = "";
                resultbox.Text = "";
                komma = false;

                if (eraf == true)
                {
                    newText = minus(getal1, getal2).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    eraf = false;
                }
                else if (erbij == true)
                {
                    newText = add(getal1, getal2).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    erbij = false;
                }
                else if (maal == true)
                {
                    newText = multply(getal1, getal2).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    maal = false;
                }
                else if (delen == true)
                {
                    newText = divide(getal1, getal2).ToString();
                    resultbox.Text = newText.Replace('.', ',');
                    delen = false;
                }
            }
        }
    }
}
