using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.Models
{
    public class Coureur : BindableObject
    {
        private int _num;
        private string _nom;
        private string _prenom;
        private string _sexe;


        public Coureur()
        {

        }
        public Coureur(int num, string nom, string prenom, string sexe)
        {
            _nom = nom;
            _prenom = prenom;
            _sexe = sexe;
        }

        public int Num { get => _num; set => _num = value; }
        public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }
        public string Prenom { get => _prenom; set { _prenom = value; OnPropertyChanged(); } }
        public string Sexe { get => _sexe; set { _sexe = value; OnPropertyChanged(); } }

    }
}
