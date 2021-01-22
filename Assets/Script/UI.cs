using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script {

    public class UI : MonoBehaviour {
        public Gold gold;
        public Text amountText;
        public Text achievementText;

        private void Awake() {
            this.gold = new Gold(0);
            Gold.ONAmountChange += onAmountChange;
            gold.to100Achievement.onAchieve100 += onAchieveChange;
            gold.to1000Achievement.onAchieve1000 += onAchieveChange;
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