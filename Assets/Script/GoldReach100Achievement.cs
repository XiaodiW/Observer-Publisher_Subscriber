using System;

namespace Script {

    public class GoldReach100Achievement {
        // public event Action<string> onAchieve;
        
        public GoldReach100Achievement() {
            // Dependencies.broker.SubscribeTo("GoldAmount",AmountUpdate);       
            Dependencies.broker.SubscribeTo<GoldAmountChangeMessage>(AmountUpdate);
        }
        public void AchievementGained() {
            // onAchieve?.Invoke("Gold Reach 100");
            // Dependencies.broker.Publish("Achievement100", "Gold Reach 100");
            Dependencies.broker.Publish<AchievementMassage>(new AchievementMassage("Gold Reach 100"));
        }

        public void AmountUpdate(GoldAmountChangeMessage a) {
            if((int)a.Amount >= 100) AchievementGained();
        }
    }

    /*public class GoldReach100Achievement { //Step 6
        private readonly Gold gold;

        public GoldReach100Achievement(Gold gold) {
            this.gold = gold;
            // gold.GoldObserver += AmountUpdate;
        }

        public event Action<string> onAchieve;

        public void AchievementGained() {
            onAchieve?.Invoke("Gold Reach 100");
        }

        public void AmountUpdate(int a) {
            if(a >= 100) AchievementGained();
        }
    }*/
    
    
        /*public class GoldReach100Achievement : IGoldReachObserver { //Step 3-5
            // public event Action<string> onAchieve100; //Step1-2
            public event Action<string> onAchieve;//Step3
            public void AchievementGained() {//Step 1
                // onAchieve100?.Invoke("Gold Reach 100");//Step1-2
                onAchieve?.Invoke("Gold Reach 100"); //Step3
            }
            public void AmountUpdate(int a) { //Step 2
                if(a >= 100) AchievementGained();
            }
        }*/

}