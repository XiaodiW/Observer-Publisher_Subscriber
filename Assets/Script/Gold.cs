using System;
using System.Collections.Generic;
using System.Linq;

namespace Script {

    public class Gold {
        private int _amount;
        public static event Action<int> ONAmountChange;
        // public GoldReach100Achievement to100Achievement; //Step1-2
        // public GoldReach1000Achievement to1000Achievement; //Step1-2
        // readonly IGoldReachAchievement[] goldReachAchievements; //Step3
        // readonly IGoldReachObserver[] goldReachObservers; //Step4
        // readonly List<IGoldReachObserver> goldReachObservers; //Step5

        // public void SubscribToGoldAmount(IGoldReachObserver goldReachObserver) {//Step5
        //     goldReachObservers.Add(goldReachObserver);
        // }
        // public void UnsubscriptToGoldAmount(IGoldReachObserver goldReachObserver) {//Step5
        //     goldReachObservers.Remove(goldReachObserver);
        // }

        public delegate void GoldReachObserver(int newGoldAmount);

        public event GoldReachObserver GoldObserver;
        public int Amount { 
            get => this._amount;
            private set {
                if(value < 0) value = 0;
                _amount = value;
                ONAmountChange?.Invoke(value);
                // if(this._amount >= 100) to100Achievement.AchievementGained(); //Step1
                // if(this._amount >= 1000) to1000Achievement.AchievementGained();//Step1
                // to100Achievement.AmountUpdate(value); //Step2
                // to1000Achievement.AmountUpdate(value); //Step2
                // foreach(var goldReachAchievement in goldReachAchievements) { //Step3
                //     goldReachAchievement.AmountUpdate(value);
                // }
                // foreach(var goldReachObserver in goldReachObservers) { //Step4-5
                //     goldReachObserver.AmountUpdate(value);
                // }
                GoldObserver?.Invoke(value);
            }
        }
        public Gold(int amount){ //Step1-2,5
        // public Gold(int amount, IGoldReachAchievement[] goldReachAchievements) { //Step3
        // public Gold(int amount, IGoldReachObserver[] goldReachObservers) { //Step4
            this._amount = amount;
            // this.to100Achievement = new GoldReach100Achievement();//Step1-2
            // this.to1000Achievement = new GoldReach1000Achievement();//Step1-2
            // this.goldReachAchievements = goldReachAchievements; //Step3
            // this.goldReachObservers = goldReachObservers; //Step4
            // goldReachObservers = new List<IGoldReachObserver>(); //Step5
        }
        public void ClicktoAdd(int add) {
            Amount += add;
        }
    }
    
    // public interface IGoldReachAchievement { //Step3
    // public interface IGoldReachObserver { //Step4-5
    //     void AmountUpdate(int a);
    //     event Action<string> onAchieve;
    // }
    
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
    public class GoldReach100Achievement { //Step 6
        private readonly Gold gold;

        public GoldReach100Achievement(Gold gold) {
            this.gold = gold;
            gold.GoldObserver += AmountUpdate;
        }

        public event Action<string> onAchieve;

        public void AchievementGained() {
            onAchieve?.Invoke("Gold Reach 100");
        }

        public void AmountUpdate(int a) {
            if(a >= 100) AchievementGained();
        }
    }



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

    public class GoldReach1000Achievement { //Step 6
        private readonly Gold gold;

        public GoldReach1000Achievement(Gold gold) {
            this.gold = gold;
            gold.GoldObserver += AmountUpdate;
        }

        public event Action<string> onAchieve;

        public void AchievementGained() {
            onAchieve?.Invoke("Gold Reach 1000");
        }

        public void AmountUpdate(int a) {
            if(a >= 1000) AchievementGained();
        }
    }
}
