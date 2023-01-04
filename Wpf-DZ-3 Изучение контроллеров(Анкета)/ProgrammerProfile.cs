using System;
using System.Collections.Generic;

namespace Wpf_DZ_3_Анкета_
{
    internal class ProgrammerProfile {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public List<string> listOfProgrammingLanguages;
        public string Discription { get; set; }
        public string DateOfBirthday { get; set; }
        public string EnglishLevel { get; set; }
        public string OS { get; set; }
        public int LevelOfPassionForProgramming { get; set; }

        public ProgrammerProfile()
        {
            SettingProperties();
        }

        public void SettingProperties()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            listOfProgrammingLanguages = new List<string>();
            Discription = string.Empty;
            DateOfBirthday = string.Empty;
            EnglishLevel = string.Empty;
            OS = string.Empty;
            LevelOfPassionForProgramming = 0;
        }

        bool ValidSurname()
        {
            return Surname != string.Empty;
        }

        bool ValidName()
        {
            return Name != string.Empty;
        }

        bool ValidPatronymic()
        {
            return Patronymic != string.Empty;
        }

        bool ValidListOfProgrammingLanguages()
        {
            return listOfProgrammingLanguages.Count != 0;
        }


        bool ValidDiscription()
        {
            return Discription != string.Empty;
        }


        bool ValidDateOfBirth()
        {
            return DateOfBirthday != string.Empty;
        }

        bool ValidEnglishLevel()
        {
            return EnglishLevel != string.Empty;
        }

        bool ValidOS()
        {
            return OS != string.Empty;
        }

        public bool ValidData()
        {
            if (ValidSurname() && ValidName() && ValidPatronymic()
                && ValidListOfProgrammingLanguages() && ValidDiscription()
                && ValidDateOfBirth() && ValidEnglishLevel() && ValidOS())
            {
                return true;
            }
            return false;
        }
    }
}