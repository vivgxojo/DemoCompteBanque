using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompteBanque
{
    public class VM_Banque : INotifyPropertyChanged
    {
        public ObservableCollection<Client> _lesClients;
        public ObservableCollection<Client> LesClients 
        { 
            get 
            {
                return _lesClients;
            } 
            set
            { 
                _lesClients = value;
                OnPropertyChanged(nameof(LesClients));
            }
        }

        public Client client { get; set; }

        private Client _clientS;
        public Client clientSelect { 
            get { return _clientS; }
            set { 
                _clientS = value;
                OnPropertyChanged(nameof(clientSelect));
                OnPropertyChanged(nameof(clientSelect.ListeComptes));
            }
        }

        public Compte compte { get; set; }

        public string NAS { get; set; }
        public string NIP { get; set; }

        public ICommand commandNouveauClient { get; set; }
        public ICommand commandNouveauCompte { get; set; }
        public ICommand commandConnexion { get; set; }
        public ICommand commandChangerNip { get; set; }
        public ICommand commandRetirer { get; set; }
        public ICommand commandDeposer { get; set; }

        public VM_Banque() 
        {
            LesClients = new ObservableCollection<Client>();
            client = new Client();
            clientSelect = new Client();
            compte = new Compte();

            commandNouveauClient = new RelayCommand(NouveauClient);
            commandNouveauCompte = new RelayCommand(NouveauCompte);
            commandConnexion = new RelayCommand(Connexion);
            commandChangerNip = new RelayCommand(ChangerNip);
            commandDeposer = new RelayCommand(Deposer);
            commandRetirer = new RelayCommand(Retirer);
        }

        private void Retirer()
        {
            throw new NotImplementedException();
        }

        private void Deposer()
        {
            throw new NotImplementedException();
        }

        private void ChangerNip()
        {
            throw new NotImplementedException();
        }

        private void Connexion()
        {
            throw new NotImplementedException();
        }

        private void NouveauCompte()
        {
            if (clientSelect != null)
            {
                clientSelect.OuvrirCompte();
                MessageBox.Show("Le compte a été créé");
                Client copie = clientSelect;
                clientSelect = null; // forcer la mise à jour du combobox
                clientSelect = copie;
            }
            else
            {
                MessageBox.Show("Vous devez d'abord sélectionner un client");
            }
        }

        private void NouveauClient()
        {
            Client c = new Client(client);
            c.ChangerNIP(null, NIP);
            LesClients.Add(c);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
