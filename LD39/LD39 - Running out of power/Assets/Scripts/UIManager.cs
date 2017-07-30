using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text hordeText;
    public Text exitText;
    public Text foodText;
    public Text materialsText;

    public Text dynamoLevelText;
    public Text lanternStrengthText;
    public Text lanternSizeText;
    public Text walkspeedText;
    public Text playerStrengthText;

    public Text dynamoLevelCostText;
    public Text lanternStrengthCostText;
    public Text lanternSizeCostText;
    public Text walkspeedCostText;
    public Text playerStrengthCostText;

    public Text gameOverText;
    public Image blackBG;
    public Button backButton;

    private float time = 0f;
    private float animSpeed = 0.2f;
    private float time1 = 0f;
    private float animSpeed1 = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //UI stuff
        if (!GameplayManager.instance.gameOver)
        {
            hordeText.text = GameplayManager.instance.distanceFromHorde.ToString() + "m";
            exitText.text = GameplayManager.instance.distanceToExit.ToString() + "m";
            foodText.text = ": " + ResourceManager.instance.currentFood.ToString();
            materialsText.text = ": " + ResourceManager.instance.currentMaterials.ToString();

            //Level
            dynamoLevelText.text = "Lv " + UpgradeManager.instance.GetUpgradeLevel(UpgradeManager.UpgradeType.DYNAMOSTRENGTH).ToString();
            lanternStrengthText.text = "Lv " + UpgradeManager.instance.GetUpgradeLevel(UpgradeManager.UpgradeType.LANTERNSTRENGTH).ToString();
            lanternSizeText.text = "Lv " + UpgradeManager.instance.GetUpgradeLevel(UpgradeManager.UpgradeType.LANTERNCAPACITY).ToString();
            walkspeedText.text = "Lv " + UpgradeManager.instance.GetUpgradeLevel(UpgradeManager.UpgradeType.MOVESPEED).ToString();
            playerStrengthText.text = "Lv " + UpgradeManager.instance.GetUpgradeLevel(UpgradeManager.UpgradeType.BARRICADE).ToString();

            //Cost
            dynamoLevelCostText.text = UpgradeManager.instance.GetUpgradeCost(UpgradeManager.UpgradeType.DYNAMOSTRENGTH).ToString();
            lanternStrengthCostText.text = UpgradeManager.instance.GetUpgradeCost(UpgradeManager.UpgradeType.LANTERNSTRENGTH).ToString();
            lanternSizeCostText.text = UpgradeManager.instance.GetUpgradeCost(UpgradeManager.UpgradeType.LANTERNCAPACITY).ToString();
            walkspeedCostText.text = UpgradeManager.instance.GetUpgradeCost(UpgradeManager.UpgradeType.MOVESPEED).ToString();
            playerStrengthCostText.text = UpgradeManager.instance.GetUpgradeCost(UpgradeManager.UpgradeType.BARRICADE).ToString();
        }
        else
        {
            if (GameplayManager.instance.wonGame)
                gameOverText.text = "You reached the end of the tunnel and escaped the herd!";
            else
                gameOverText.text = "The herd caught you...";

            Color c = blackBG.color;
            c.a = Mathf.Lerp(0f, 1f, time);
            blackBG.color = c;

            time += animSpeed * Time.deltaTime;

            if(c.a >= 1f)
            {
                Color c1 = gameOverText.color;
                c1.a = Mathf.Lerp(0f, 1f, time1);
                gameOverText.color = c1;

                time1 += animSpeed1 * Time.deltaTime;

                if (c1.a >= 1f)
                {
                    backButton.gameObject.SetActive(true);
                }
            }
        }
    }
}
