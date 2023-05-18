using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private Player _player;

    private float bandaidsRegen = 15f;

    private int costOfBandaids = 15;
    private float healthPotRegen = 25f;

    private int costOfHeathPots = 25;

    private float MedkitRegen = 50f;

    private int costOfMedkits = 50;

    private float chugJugRegen = 100f;

    private int costOfChugJug = 100;

    private float strengthPotDam = 25f;

    private int costOfStrengthPot = 25;

    public void BuyBandaid() {
        if (_player.mon >= costOfBandaids) {
            _player.HeathItem(bandaidsRegen);
            _player.AdjustMon(-costOfBandaids);
            print("Bandaid obtained. You now have " + _player.health.ToString() + " health and have" + _player.mon.ToString() + " left.");
        } else {
            print(" You dont have enough for that or you are full health young traveler!!");
        }
    }

     public void BuyHealthPot() {
        if (_player.mon >= costOfHeathPots) {
            _player.HeathItem(healthPotRegen);
            _player.AdjustMon(-costOfHeathPots);
            print("Health pot obtained. You now have " + _player.health.ToString()+ " health and have" + _player.mon.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }

    public void BuyMedKit() {
        if (_player.mon >= costOfMedkits) {
            _player.HeathItem(MedkitRegen);
            _player.AdjustMon(-costOfMedkits);
            print("Med Kit obtained. You now have " + _player.health.ToString()+ " health and have" + _player.mon.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }

    public void BuyChugJug() {
        if (_player.mon >= costOfChugJug) {
            _player.HeathItem(chugJugRegen);
            _player.AdjustMon(-costOfChugJug);
            print("Chug Jug obtained. You now have " + _player.health.ToString()+ " health and have" + _player.mon.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }

    public void BuyStrengthPot() {
        if (_player.mon >= costOfChugJug) {
            _player.DamageItem(strengthPotDam);
            _player.AdjustMon(-costOfStrengthPot);
            print("Strength pot obtained. You now do" + _player.damage.ToString()+ " Damage and have" + _player.mon.ToString() + " left.");
        } else {
            print(" You dont have enough for that young traveler!!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
