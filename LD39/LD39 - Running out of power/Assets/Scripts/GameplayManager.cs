using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : AbstractTimeTick
{
    public static GameplayManager instance;

    public float distanceToExit; //In Meters
    public float distanceFromHorde; //In Meters
    public float moveSpeed
    {
        get
        {
            if (!isWalking)
                return 0f;

            var mvSpeed = UpgradeManager.instance.GetUpgradePower(UpgradeManager.UpgradeType.MOVESPEED);

            if (generatedPowerCD > 0f)
                mvSpeed = (mvSpeed / 100) * 50;

            return mvSpeed;
        }
    }
    public float hordeWalkSpeed;
    public int hordeIncrementTime;

    private int currentHordeTime;

    public bool isWalking = true;
    public bool isHordeMoving = true;
    public float generatedPowerCD = 0f;

    public bool gameOver = false;
    public bool wonGame = false;

    public Tutorial tut;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () {
        tut = GetComponent<Tutorial>();
        currentHordeTime = hordeIncrementTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update movement ticks.
        base.Update();

        if (distanceFromHorde <= 0f)
            GameOver();

        if (distanceToExit <= 0f)
        {
            wonGame = true;
            GameOver();
        }           
	}

    public void MoveTowardsExit(float amount)
    {
        distanceToExit -= amount;
    }

    public void MoveHorde(float amount)
    {
        distanceFromHorde -= amount;
    }

    public void GeneratePowerPressed()
    {
        float power = UpgradeManager.instance.GetUpgradePower(UpgradeManager.UpgradeType.DYNAMOSTRENGTH);
        ResourceManager.instance.AddPower(power);
        generatedPowerCD = 1f;
        tut.clickedLantern = true;
    }

    public override void UpdateTick()
    {
        currentHordeTime--;

        if(currentHordeTime <= 0)
        {
            hordeWalkSpeed++;
            currentHordeTime = hordeIncrementTime;
            StartCoroutine(tut.AnimateText(tut.faster));
        }

        if (isWalking)
            MoveTowardsExit(moveSpeed);

        if (isHordeMoving)
        {
            float closedDistance = hordeWalkSpeed - moveSpeed;
            MoveHorde(closedDistance);
        }

        if (generatedPowerCD > 0f)
            generatedPowerCD -= 1f;
    }

    private void GameOver()
    {
        //Show some text that you lost.
        //Display button to go to menu
        gameOver = true;
    }

    public void EndGame()
    {
        //Go to start scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
