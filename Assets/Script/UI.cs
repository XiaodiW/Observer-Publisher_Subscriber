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

        private void Awake() {
            // this.gold = new Gold(0); //Step1-2
            Gold.ONAmountChange += onAmountChange;
            // gold.to100Achievement.onAchieve100 += onAchieveChange; //Step1-2
            // gold.to1000Achievement.onAchieve1000 += onAchieveChange; //Step1-2
            GoldReach100Achievement I1 = new GoldReach100Achievement();
            GoldReach1000Achievement I2 = new GoldReach1000Achievement();
            var types = new IGoldReachObserver[] {I1, I2};
            this.gold = new Gold(0,types);//Step3
            foreach(IGoldReachObserver type in types) {//Step3
                type.onAchieve += onAchieveChange;
            }
            gold.ClicktoAdd(0); //Initialize Gold Amount UI.
        }

        private void onAmountChange(int a) {
            amountText.text = a.ToString();
        }
        private void onAchieveChange(string s) {

            achievementText.text = s;
        }

        public void onClickAdd(int a) {
            gold.ClicktoAdd(a);
        }
    }

}