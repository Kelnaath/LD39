using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;

    [Header("Resources")]
    public float currentPower;
    public float maxPower { get { return UpgradeManager.instance.GetUpgradePower(UpgradeManager.UpgradeType.LANTERNCAPACITY); } }

    public float currentFood;
    public float maxFood;

    public float currentMaterials;
    public float maxMaterials;

    public bool drainingBattery = true;

    [Header("Resource variables")]
    public float powerDrain = .8f;
    public float powerDrainTickRate = 1f; //In seconds.

    public float minFoodFound = 1f;
    public float maxFoodFound = 1f;

    public float minMaterialsFound = 1f;
    public float maxMaterialsFound = 1f;

    public Light lantern;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () {
        currentPower = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (drainingBattery)
        {
            DepletePower(powerDrain);
            var lanternStrength = CalculateSpotAngle();
            lantern.spotAngle = Mathf.Lerp(lantern.spotAngle,lanternStrength, Time.deltaTime);
        }

    }

    public void DepletePower(float amount)
    {
        currentPower = Mathf.Clamp(currentPower - amount, 0f, maxPower);
    }

    public void AddPower(float amount)
    {
        currentPower = Mathf.Clamp(currentPower + amount, 0f, maxPower);
    }

    public void DepleteFood(float amount)
    {
        currentFood -= amount;
    }

    public void AddFood(float amount)
    {
        currentFood += amount;
    }

    public void AddMaterials(float amount)
    {
        currentMaterials += amount;
    }

    public void DepleteMaterials(float amount)
    {
        currentMaterials -= amount;
    }

    private float CalculateSpotAngle()
    {
        //Bereken angle
        //Max strengt
        var min = 5f;
        var max = UpgradeManager.instance.GetUpgradePower(UpgradeManager.UpgradeType.LANTERNSTRENGTH);

        var powerpercentage = (currentPower / maxPower) * 100;

        var anglePower = Mathf.Clamp(powerpercentage, min, max);

        if((currentPower / maxPower) * 100 < 50)
        {
            var pp = (powerpercentage / max) * max;
            anglePower = Mathf.Clamp(powerpercentage, min, max);
        }

        return anglePower;
    }
}
