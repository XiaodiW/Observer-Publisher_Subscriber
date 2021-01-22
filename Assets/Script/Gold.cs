﻿using System;
using UnityEngine;

namespace Script {

    public class Gold {
        private int _amount;
        public static event Action<int> ONAmountChange;
        public GoldReach100Achievement to100Achievement;
        public GoldReach1000Achievement to1000Achievement;
        
        public int Amount { 
            get => this._amount;
            private set {
                if(value < 0) value = 0;
                _amount = value;
                ONAmountChange?.Invoke(value);
                if(this._amount >= 100) to100Achievement.AchievementGained();
                if(this._amount >= 1000) to1000Achievement.AchievementGained();
            }
        }
        public Gold(int amount) {
            this._amount = amount;
            this.to100Achievement = new GoldReach100Achievement();
            this.to1000Achievement = new GoldReach1000Achievement();
        }
        public void ClicktoAdd(int add) {
            Amount += add;
        }
    }

    public class GoldReach100Achievement {
        public event Action<string> onAchieve100; 
        public string Text;

        public void AchievementGained() {
            // Text = "Gold Reach 100";
            onAchieve100?.Invoke("Gold Reach 100");
        }
    }
    
    public class GoldReach1000Achievement {
        public event Action<string> onAchieve1000; 
        public string Text;

        public void AchievementGained() {
            // Text = "Gold Reach 100";
            onAchieve1000?.Invoke("Gold Reach 1000");
        }
    }

}
