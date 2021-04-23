using GestionCoursesXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.ViewModels
{
    class GestionInscriptionViewModel : BindableObject
    {
        private Inscription _inscript;

        public Inscription Inscrit { get => _inscript; set { _inscript = value; OnPropertyChanged(); } }

        public Command btnRetour { get; set; }
        public INavigation Navigation { get; set; }

        public GestionInscriptionViewModel(INavigation navigation)
        {
            if (Inscrit == null)
            {
                Inscrit = new Inscription();
                btnRetour = new Command(RetourCommand);

                Navigation = navigation;
            }
        }

        private void RetourCommand()
        {
            Navigation.PopModalAsync();
        }

        public void MajDonnees(ItemTappedEventArgs e, int NumCourse)
        {
            var selecteditem = (Coureur)e.Item;
            Inscrit.IdxCoureur = selecteditem.Num;
            Inscrit.IdxCourse = NumCourse;
            App.ListeInscription.Add(Inscrit);
        }
    }
}
