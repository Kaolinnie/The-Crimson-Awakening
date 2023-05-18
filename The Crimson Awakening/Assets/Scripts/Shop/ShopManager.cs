using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private int coins = 1000;
    private int numberOfHealPotions = 0;

    private int costOfHealPotions = 15;

    public void BuyHealthPot() {
        if (coins >= costOfHealPotions) {
            numberOfHealPotions++;
            coins -= costOfHealPotions;
            print("Health pot obtained. You now have " + numberOfHealPotions.ToString() + " potions and " + coins.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }
    public void BuyStrengthPot() {
        if (coins >= costOfHealPotions) {
            numberOfHealPotions++;
            coins -=costOfHealPotions;
            print("Health pot obtained. You now have " + numberOfHealPotions.ToString() + " potions and " + coins.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
