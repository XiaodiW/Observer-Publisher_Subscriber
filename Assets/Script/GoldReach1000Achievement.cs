using System;

namespace Script {

    public class GoldReach1000Achievement {
        // public event Action<string> onAchieve;

        public GoldReach1000Achievement() {
            // Dependencies.broker.SubscribeTo("GoldAmount",AmountUpdate);     
            Dependencies.broker.SubscribeTo<GoldAmountChangeMessage>(AmountUpdate);
        }
        public void AchievementGained() {
            // onAchieve?.Invoke("Gold Reach 1000");
            // Dependencies.broker.Publish("Achievement1000", "Gold Reach 1000");
            Dependencies.broker.Publish<AchievementMassage>(new AchievementMassage("Gold Reach 1000"));
        }
        
        public void AmountUpdate(GoldAmountChangeMessage a) {
            if((int)a.Amount >= 1000) AchievementGained();
        }
    }
    /*public class GoldReach1000Achievement { //Step 6
        private readonly Gold gold;
    
        public GoldReach1000Achievement(Gold gold) {
            this.gold = gold;
            // gold.GoldObserver += AmountUpdate;
        }
    
        public event Action<string> onAchieve;
    
        public void AchievementGained() {
            onAchieve?.Invoke("Gold Reach 1000");
        }
    
        public void AmountUpdate(int a) {
            if(a >= 1000) AchievementGained();
        }
    }*/

    /*public class GoldReach1000Achievement : IGoldReachObserver{
    // public event Action<string> onAchieve1000; //Step1-2
    public event Action<string> onAchieve; //Step3
    public void AchievementGained() {//Step 1
        // onAchieve1000?.Invoke("Gold Reach 1000");//Step1-2
        onAchieve?.Invoke("Gold Reach 1000");//Step3
    }
    public void AmountUpdate(int a) { //Step 2
        if(a >= 1000) AchievementGained();
    }
}*/
}