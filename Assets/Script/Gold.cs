using System;
using System.Collections.Generic;
using System.Linq;

namespace Script {

    public class Gold {
        private int _amount;
        // public static event Action<int> OnAmountChange; //For UI Display.
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

        // public delegate void GoldReachObserver(int newGoldAmount);// Step6-7
        // public event GoldReachObserver GoldObserver;// Step6-7
        // private Broker broker;
        public int Amount { 
            get => this._amount;
            private set {
                if(value < 0) value = 0;
                _amount = value;
                // OnAmountChange?.Invoke(value);
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
                // GoldObserver?.Invoke(value);// Step6-7
                PublishMessage(value);
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
            // this.broker = broker;
        }
        
        public void PublishMessage(int value)  
        {  
            // broker.Publish(new Mymessage());  
            // broker.Publish(value);  
            Dependencies.broker.Publish("GoldAmount",value);
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
}
