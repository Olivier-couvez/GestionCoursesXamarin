using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.ViewModels;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionCoursesXamarin
{
    public partial class App : Application
    {
        public static List<Course> ListeCourses { get; set; }
        public static List<Coureur> ListeCoureurs { get; set; }
        public static List<Inscription> ListeInscription { get; set; }

        EnregListeCoureurs sauvegardeC;
        EnregListeCourses sauvegardeCo;
        EnregListeInscrit sauvegardeI;
        public App()
        {
            InitializeComponent();

            if (ListeCourses == null)
            {
                ListeCourses = new List<Course>();
            }
            if (ListeCoureurs == null)
            {
                ListeCoureurs = new List<Coureur>();
            }
            if (ListeInscription == null)
            {
                ListeInscription = new List<Inscription>();
            }


            

            // Recup données serialisé

            InitListes();



            MainPage = new ListeCourses();
        }
        public void InitListeCourse()
        {
            ListeCourses.Add(new Course { Nom = "Marathon de Paris", Lieu = "Paris", Distance = 42.195d });
            ListeCourses.Add(new Course { Nom = "Marathon de Phalempin", Lieu = "Phalempin", Distance = 42.195d });
            ListeCourses.Add(new Course { Nom = "Marathon de New York", Lieu = "New York", Distance = 42.195d });
            ListeCourses.Add(new Course { Nom = "Demi marathon de Lille", Lieu = "Lille", Distance = 21.100d });
            ListeCourses.Add(new Course { Nom = "Marathon du nouvel an", Lieu = "Zurich", Distance = 42.195d });
            ListeCourses.Add(new Course { Nom = "Winter Enigma Running", Lieu = "Milton Keynes", Distance = 42.195d });
            ListeCourses.Add(new Course { Nom = "Snowspeeder - Virtual", Lieu = "Milton Keynes", Distance = 10d });
        }

        public void InitListeCoureur()
        {
            ListeCoureurs.Add(new Coureur { Nom = "Couvez", Prenom = "Olivier", Age = 57, Sexe = "1"  });
            ListeCoureurs.Add(new Coureur { Nom = "Jaspart", Prenom = "Olivier", Age = 52, Sexe = "1" });
            ListeCoureurs.Add(new Coureur { Nom = "Brasme", Prenom = "Marion", Age = 25, Sexe = "0" });
            ListeCoureurs.Add(new Coureur { Nom = "Grigny", Prenom = "Kevin", Age = 31, Sexe = "1" });
            ListeCoureurs.Add(new Coureur { Nom = "Delarre", Prenom = "Alexis", Age = 25, Sexe = "1" });
        }

        public void InitListes()
        {
            // lecture fichier pour récup des informations enregistrer sur les rovers

            sauvegardeC = new EnregListeCoureurs();
            if (sauvegardeC.TestExistenceFichier() == true)
            {
                ListeCoureurs = sauvegardeC.recuperationListe(); // si une sauvegarde existe on la récupère
            }
            else
            {
                InitListeCoureur();
            }

            sauvegardeCo = new EnregListeCourses();
            if (sauvegardeCo.TestExistenceFichier() == true)
            {
                ListeCourses = sauvegardeCo.recuperationListe(); // si une sauvegarde existe on la récupère
            }
            else
            {
                InitListeCourse();
            }

            sauvegardeI = new EnregListeInscrit();
            if (sauvegardeI.TestExistenceFichier() == true)
            {
                ListeInscription = sauvegardeI.recuperationListe(); // si une sauvegarde existe on la récupère
            }
            else
            {
                InitListeCourse();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            sauvegardeC.sauveListe(ListeCoureurs);
            sauvegardeCo.sauveListe(ListeCourses);
            sauvegardeI.sauveListe(ListeInscription);
        }

        protected override void OnResume()
        {
        }
    }
}
