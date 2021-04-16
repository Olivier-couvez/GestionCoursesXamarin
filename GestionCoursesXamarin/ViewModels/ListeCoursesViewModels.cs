using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.ViewModels
{
    public class ListeCoursesViewModels : BindableObject
    {
        private List<Course> _courses;
        public List<Course> Courses { get => _courses; set { _courses = value; OnPropertyChanged(); } }
        public Command AddCoureur {get; set;}

        public INavigation Navigation { get; set; }

        public ListeCoursesViewModels(INavigation navigation)
        {
            if (Courses == null)
            {
                Courses = new List<Course>();
            }
            Courses = App.ListeCourses;

            AddCoureur = new Command(AddCoureurAction);
            Navigation = navigation;
        }

        private void AddCoureurAction()
        {
            Navigation.PushModalAsync(new GestionCoureur());
        }
    }
}
