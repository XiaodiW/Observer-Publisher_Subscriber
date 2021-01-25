using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Script {

    public class UI : MonoBehaviour {
        public Gold gold;
        public Text amountText;
        public Text achievementText;
        private Broker broker;

        private void Awake() {
             this.gold = new Gold(0); //Step1-2
            // Gold.OnAmountChange += onAmountChange;
            // gold.to100Achievement.onAchieve100 += onAchieveChange; //Step1-2
            // gold.to1000Achievement.onAchieve1000 += onAchieveChange; //Step1-2
            // GoldReach100Achievement I1 = new GoldReach100Achievement();
            // GoldReach1000Achievement I2 = new GoldReach1000Achievement();
            // var types = new IGoldReachObserver[] {I1, I2};//Step4
            // // this.gold = new Gold(0,types);//Step3 -4
            // this.gold = new Gold(0); //Step5-6
            // gold.SubscribToGoldAmount(I1);
            // gold.SubscribToGoldAmount(I2);
            // foreach(IGoldReachObserver type in types) {//Step3-5
            //     type.onAchieve += onAchieveChange;
            // }
            GoldReach100Achievement I1 = new GoldReach100Achievement();//Step5-6
            GoldReach1000Achievement I2 = new GoldReach1000Achievement();//Step5-6
            // I1.onAchieve += onAchieveChange;//Step5-6
            // I2.onAchieve += onAchieveChange;//Step5-6
            // this.broker = new Broker();
            // this.gold = new Gold(0, broker);
            // GoldReach100Achievement I1 = new GoldReach100Achievement();
            // broker.Subscribe<int>(I1.AmountUpdate);
            // GoldReach1000Achievement I2 = new GoldReach1000Achievement();
            // broker.Subscribe<int>(I2.AmountUpdate);
            // I1.onAchieve += onAchieveChange;//Step5-6
            // I2.onAchieve += onAchieveChange;//Step5-6
            // Dependencies.broker.SubscribeTo("GoldAmount",onAmountChange);
            Dependencies.broker.SubscribeTo<GoldAmountChangeMessage>(onAmountChange);
            // Dependencies.broker.SubscribeTo("Achievement100", onAchieveChange);
            // Dependencies.broker.SubscribeTo("Achievement1000", onAchieveChange);
            Dependencies.broker.SubscribeTo<AchievementMassage>(onAchieveChange);
            gold.ClicktoAdd(0); //Initialize Gold Amount UI.
        }

        private void onAmountChange(GoldAmountChangeMessage a) {
            amountText.text = a.Amount.ToString();
        }

        private void onAchieveChange(AchievementMassage s) {
            achievementText.text = (string)s.Massage;
        }

        public void onClickAdd(int a) {
            gold.ClicktoAdd(a);
        }
    }

}