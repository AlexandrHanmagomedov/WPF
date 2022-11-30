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

namespace Wpf_DZ_15_2_Calculator
{
    public partial class MainWindow : Window
    {

        double Number = 0;
        double inputNumber = 0;

        int input;

        string currentStroka = "";

        bool boolInput = false;
        bool boolDot = false;
        bool boolNoDoubleEquall = false;
        bool boolNoDoubleAction = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e){
            Button btn = e.OriginalSource as Button;
            currentStroka += btn.Content;
            txtBox_Value.Text = currentStroka;
            Number = Convert.ToDouble(currentStroka);
            boolNoDoubleAction = false;
        }

        private void Dot_Click(object sender, RoutedEventArgs e){
            if (!boolDot)            {
                currentStroka += ",";
                txtBox_Value.Text += ",";
                boolDot = true;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e){
            if (boolNoDoubleEquall){
                txtBox_Top.Text = "";
                switch (input){
                    case 1: Number = inputNumber / Number; break;
                    case 2: Number = inputNumber * Number; break;
                    case 3: Number = inputNumber - Number; break;
                    case 4: Number = inputNumber + Number; break;
                }
                txtBox_Value.Text = Number.ToString();
                currentStroka = Number.ToString();
                boolInput = false;
                boolNoDoubleEquall = false;
                boolNoDoubleAction = false;
                input = 0;
                inputNumber = 0;
            }
        }

        private void Do_Action(object sender, RoutedEventArgs e){
            if (!boolNoDoubleAction){
                Button btn = e.OriginalSource as Button;
                txtBox_Top.Text += Number.ToString() + " " + btn.Content;
                if (!boolInput){                 
                    inputNumber = Convert.ToDouble(currentStroka);
                }
                else{
                    switch (input){
                        case 1: Number = inputNumber / Number; break;
                        case 2: Number = inputNumber * Number; break;
                        case 3: Number = inputNumber - Number; break;
                        case 4: Number = inputNumber + Number; break;
                    }
                    inputNumber = Number;
                }

                switch (btn.Content){
                    case "/": input = 1; break;
                    case "*": input = 2; break;
                    case "-": input = 3; break;
                    case "+": input = 4; break;
                }

                currentStroka = "";
                boolDot = false;
                boolInput = true;
                boolNoDoubleEquall = true;
                boolNoDoubleAction = true;
                txtBox_Value.Text = inputNumber.ToString();
            }
        }

        private void Clear_СE(object sender, RoutedEventArgs e){
            currentStroka = "";
            Number = 0;
            txtBox_Value.Text = "";
            boolNoDoubleAction = true;
        }

        private void Clear_С(object sender, RoutedEventArgs e){
            currentStroka = "";
            Number = 0;
            txtBox_Top.Text = "";
            txtBox_Value.Text = "";
            boolInput = false;
            boolDot = false;
        }

        private void DelLast_Click(object sender, RoutedEventArgs e){
            string str = txtBox_Value.Text;
            if (str.Length <= 1){
                Number = 0;
                txtBox_Value.Text = "";
            }
            else{
                str = str.Remove(str.Length - 1);
                Number = Convert.ToDouble(str);
                txtBox_Value.Text = str.ToString();
            }
        }
    }
}


