using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_DZ_3_Анкета_
{
        public partial class MainWindow : Window
    {
        ProgrammerProfile profile;
        Window1 window1;
        string tempListBoxItemMore;

        public MainWindow()
        {
            InitializeComponent();
            AgeLimit();
            profile = new ProgrammerProfile();
        }

        private void btnPopup_Click(object sender, RoutedEventArgs e)
        {
            popUp_add.IsOpen = true;
        }

        private void Result_button(object sender, RoutedEventArgs e)
        {
            GetSurname();
            GetName();
            GetPatronymic();
            GetProgrammingLanguages();
            GetDescription();
            GetDateOfBirth();
            GetEnglishLevel();
            GetOS();
            if (ValidData())
            {
                window1 = new Window1();
                SetSurname();
                SetName();
                SetPatronymic();
                SetProgrammingLanguages();
                SetDiscription();
                SetDateOfBirth();
                SetEnglishLevel();
                SetOS();
                SetPassionPercentage();
                window1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }     
        void GetSurname()
        {
            profile.Surname = textBox_Surname.Text;
        }

        void SetSurname()
        {
            window1.textBlock_Surname.Text = profile.Surname;
        }

        void GetName()
        {
            profile.Name = textBox_Name.Text;
        }

        void SetName()
        {
            window1.textBlock_Name.Text = profile.Name;
        }

        void GetPatronymic()
        {
            profile.Patronymic = textBox_Patronymic.Text;
        }

        void SetPatronymic()
        {
            window1.textBlock_Patronymic.Text = profile.Patronymic;
        }

        void GetProgrammingLanguages()
        {
            foreach (CheckBox item in stackPanel_listOfProgrammingLanguages.Children.OfType<CheckBox>())
            {
                if (item.IsChecked == true)
                {
                    profile.listOfProgrammingLanguages.Add(item.Content.ToString());
                }
            }
            if (tempListBoxItemMore != string.Empty)
            {
                profile.listOfProgrammingLanguages.Add(tempListBoxItemMore);
            }
        }

        void SetProgrammingLanguages()
        {
            foreach (var item in profile.listOfProgrammingLanguages)
            {
                window1.textBlock_ProgrammingLanguages.Text += (item + "\n");
            }

            if (window1.textBlock_ProgrammingLanguages.Text != string.Empty)
            {
                window1.textBlock_ProgrammingLanguages.Text = window1.textBlock_ProgrammingLanguages.Text.Substring(0, window1.textBlock_ProgrammingLanguages.Text.LastIndexOf("\n"));
            }
        }

        void GetDescription()
        {
            profile.Discription = textBox_Discription.Text;
        }

        void SetDiscription()
        {
            window1.textBlock_AboutMe.Text = profile.Discription;
        }

        void GetDateOfBirth()
        {
            profile.DateOfBirthday = datePicker_DateOfBirth.Text;
        }

        void SetDateOfBirth()
        {
            DateTime dateOfBirth = DateTime.Parse(profile.DateOfBirthday);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.AddYears(age) > DateTime.Today)
            {
                age--;
            }
            window1.textBlock_DateOfBirth.Text = profile.DateOfBirthday;
            window1.textBlock_FullYears.Text = age.ToString();
        }
        void GetEnglishLevel()
        {
            foreach (RadioButton item in stackPanel_EnglishLevel.Children.OfType<RadioButton>())
            {
                if (item.IsChecked == true)
                {
                    profile.EnglishLevel = item.Content.ToString();
                    break;
                }
            }
            stackPanel_EnglishLevel.IsEnabled = false;
        }

        void SetEnglishLevel()
        {
            window1.textBlock_EnglishLevel.Text = profile.EnglishLevel;
        }

        void GetOS()
        {
            foreach (ComboBoxItem item in comboBox_OS.Items.OfType<ComboBoxItem>())
            {
                if (item.IsSelected == true)
                {
                    profile.OS = item.Tag.ToString();
                }
            }
        }

        void SetOS()
        {
            window1.textBlock_PreferredOS.Text = profile.OS;
        }

        private void slider_PassionPercentage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            profile.LevelOfPassionForProgramming = (int)e.NewValue;
        }

        void SetPassionPercentage()
        {
            window1.textBlock_PassionPercentage.Text = profile.LevelOfPassionForProgramming.ToString();
        }

        bool ValidData()
        {
            if (profile.ValidData())
            {
                return true;
            }
            return false;
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Add.Text != string.Empty)
            {
                profile.listOfProgrammingLanguages.Add(textBox_Add.Text);
            }
            textBox_Add.Text = string.Empty;
            popUp_add.IsOpen = false;
        }

        private void button_DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox item in stackPanel_listOfProgrammingLanguages.Children.OfType<CheckBox>())
            {
                item.IsChecked = false;
            }
            tempListBoxItemMore = string.Empty;
            profile.listOfProgrammingLanguages.Clear();
        }

        private void textBox_Discription_TextChanged(object sender, TextChangedEventArgs e)
        {
            label_Discription.Content = $"{textBox_Discription.Text.Length}/500";
        }

        void AgeLimit()
        {
            datePicker_DateOfBirth.DisplayDateEnd = DateTime.Now.AddYears(-18);
        }

        private void listBoxItem_More_Selected(object sender, RoutedEventArgs e)
        {
            tempListBoxItemMore = textBlock_More.Text;
            expander_Additional.IsExpanded = false;
            listBoxItem_More.IsEnabled = false;
        }
    }
}
