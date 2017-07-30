using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public static UpgradeManager instance;

    [Serializable]
    public class Upgrade
    {
        public UpgradeType upgradeType;
        public int level;
        public float upgradePower;
        public int costIncrement;
        public int cost { get { return level * costIncrement; } }
        public float currentPower { get { return level * upgradePower + initialValue; } }
        public float initialValue;
    }

    [Serializable]
    public enum UpgradeType
    {
        LANTERNCAPACITY,
        LANTERNSTRENGTH,
        DYNAMOSTRENGTH,
        MOVESPEED,
        BARRICADE
    }

    public List<Upgrade> upgrades;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Upgradelantern(float uTypeNr)
    {
        UpgradeType uType = (UpgradeType)uTypeNr;
        Upgrade upgrade = upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First();

        if (ResourceManager.instance.currentMaterials >= upgrade.cost)
        {
            ResourceManager.instance.DepleteMaterials(upgrade.cost);
            upgrade.level++;
        }
    }

    public void Upgradelantern(UpgradeType uType)
    {
        Upgrade upgrade = upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First();

        if (ResourceManager.instance.currentMaterials >= upgrade.cost)
        {
            ResourceManager.instance.DepleteMaterials(upgrade.cost);
            upgrade.level++;
        }
    }

    public void UpgradePlayer(float uTypeNr)
    {
        UpgradeType uType = (UpgradeType)uTypeNr;
        Upgrade upgrade = upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First();

        if (ResourceManager.instance.currentFood >= upgrade.cost)
        {
            ResourceManager.instance.DepleteFood(upgrade.cost);
            upgrade.level++;
        }
    }

    public void UpgradePlayer(UpgradeType uType)
    {
        Upgrade upgrade = upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First();

        if (ResourceManager.instance.currentFood >= upgrade.cost)
        {
            ResourceManager.instance.DepleteFood(upgrade.cost);
            upgrade.level++;
        }
    }

    public float GetUpgradePower(UpgradeType uType)
    {
        return upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First().currentPower;
    }

    public float GetUpgradeLevel(UpgradeType uType)
    {
        return upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First().level;
    }

    public int GetUpgradeCost(UpgradeType uType)
    {
        return upgrades.Where(u => Enum.Equals(u.upgradeType, uType) == true).First().cost;
    }
}


