using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TestApp
{
    internal class PageContext : NotifyClass
    {
        //для того чтобы пайдж контекс был общий на всю программу и могли манипулировать из любой точки
        private static PageContext _currentPageContext=new PageContext();
        public static PageContext CurrentPageContext { 
            get { return _currentPageContext; } 
            set {
                if (_currentPageContext == null)
                    _currentPageContext = value;
                }
        }



        private Stack<UserControl> _pages = new Stack<UserControl>();
        public UserControl CurrentPage { get; private set; }

        public void AddPage(UserControl page)
        {
            _pages.Push(page);
            CurrentPage = page;
            OnPropertyChanged("CurrentPage");
        }

        public void DropPage()
        {
            _pages.Pop();
            CurrentPage = _pages.Peek();
            OnPropertyChanged("CurrentPage");
        }

        public void NextPage(UserControl page)
        {
            DropPage();
            AddPage(page);
        }

        public void RefrashPage(params object[] parameters)  //переобновляет страницу
        {
            Type typePage = CurrentPage.GetType();
            CurrentPage = (UserControl)Activator.CreateInstance(typePage, parameters);
        }

        public void ChangeRootPage(UserControl page)
        {
            _pages.Clear();
            AddPage(page);
        }


    }
}
