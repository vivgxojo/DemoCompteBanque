﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBanque
{
    public class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Employeur { get; set; }
        private string _nas;
        private string _nip;
        public List<Compte> ListeComptes;

        public Client() 
        {
            ListeComptes = new List<Compte>();
        }

        public Client(string nom, string prenom, string employeur, string nas, string nip)
        {
            Nom = nom;
            Prenom = prenom;
            Employeur = employeur;
            _nas = nas;
            _nip = nip;
            ListeComptes = new List<Compte>();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="c">Le client qui sera copié</param>
        /// <return>Un nouvel objet Client avec les mêmes propriétés</return>
        public Client (Client c)
        {
            Nom = c.Nom;
            Prenom = c.Prenom;
            Employeur = c.Employeur;
            _nas = c._nas;
            _nip = c._nip;
            ListeComptes = new List<Compte>();
        }

        public bool Authentifier(string nip)
        {
            return _nip == nip;
        }

        public bool ChangerNIP(string ancienNIP, string nouveauNIP)
        {
            if (_nip == ancienNIP)
            {
                _nip = nouveauNIP;
                return true;
            }
            else
            {
                throw new Exception("Le nip est erroné.");
            }
        }

        public Compte OuvrirCompte()
        {
            Compte compte = new Compte(this);
            ListeComptes.Add(compte);
            return compte;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
