using System;
using System.Collections.Generic;

namespace TpGestionCompte.Properties
{
    public class Compte
    {
        private List<Operation> Operations = new List<Operation>();

        public string Propriétaire
        {
            get;
            set;
        }
        public decimal Solde { get; private set; }

        public Compte(string propriétaire, decimal soldeInitial)
        {
            this.Propriétaire = propriétaire;
            this.Solde = soldeInitial;
        }
        public void crediter(decimal montant)
            {
                if (montant < 0)
                {
                    throw new ArgumentException("Le montant a crediter dois etre prositif");
                }
                Operations.Add(new Operation(montant,Mouvement.Credit));
                Solde += montant;
            }
        public void débiter(decimal montant)
        {
            if (Solde<0)
            {
                throw new ArgumentException("Il n'y a plus d'argent");
            }
            Operations.Add(new Operation(montant,Mouvement.Débit));
            Solde -= montant;
        }

        public void Crediter(decimal montant , Compte CompteADebiter)
        {
            if (montant<=0)
            {
                throw new ArgumentException("Le montant doit etre positif");
            }

            if (CompteADebiter.Solde < montant)
            {
                throw new InvalidOperationException("le compte n'a pas assez de fond");
            }

            this.Solde += montant;
            Operations.Add(new Operation(montant,Mouvement.Credit));
            CompteADebiter.Solde -= montant;
            CompteADebiter.Operations.Add(new Operation(montant,Mouvement.Débit));
        }

        public void Debiter(decimal montant, Compte CompteACrediter)
        {
            if (montant <= 0)
            {
                throw new ArgumentException("le montant doit être positif");
            }

            if (this.Solde < montant)
            {
                throw new InvalidOperationException("Les fond ne sont pas suffisant");
            }

            this.Solde -= montant;
            Operations.Add(new Operation(montant,Mouvement.Débit));
            CompteACrediter.Solde += montant;
            CompteACrediter.Operations.Add(new Operation(montant,Mouvement.Credit));
        }

        public void Informations()
        {
            Console.WriteLine($"Le solde de {Propriétaire} est de {Solde} \r\n les operations sont $");
        }
    }
    
    
}