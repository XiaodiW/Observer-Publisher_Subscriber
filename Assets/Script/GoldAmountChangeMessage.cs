namespace Script {

    public class GoldAmountChangeMessage {
        private readonly int amount;
        public GoldAmountChangeMessage(int value) {
            this.amount = value;
        }
        public int Amount => amount;
    }

}