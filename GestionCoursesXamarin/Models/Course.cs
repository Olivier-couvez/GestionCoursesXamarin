using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.Models
{
    public class Course : BindableObject
    {
        private int _num;
        private string _nom;
        private string _lieu;
        private double _distance;
        private List<Coureur> _coureur;

        public Course( )
        {

        }

        public int Num { get => _num; set { _num = value; } }
        public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }
        public string Lieu { get => _lieu; set { _lieu = value; OnPropertyChanged(); } }
        public double Distance { get => _distance; set { _distance = value; OnPropertyChanged(); } }
        public List<Coureur> Coureurs { get => _coureur; set { _coureur = value; } }
    }
}
