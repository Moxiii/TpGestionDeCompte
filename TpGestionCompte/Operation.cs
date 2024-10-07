namespace TpGestionCompte
{
    public class Operation
    {
        private decimal montant;
        private Mouvement type;

        public Operation(decimal montant, Mouvement type)
        {
            this.montant = montant;
            this.type = type;
        }
        public Operation(){}
    }
}