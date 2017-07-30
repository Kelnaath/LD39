using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : AbstractTimeTick {

    public static SpawnManager instance;

    [Header("Spawnable objects")]
    public GameObject food;
    public GameObject materials;
    public GameObject barricade;

    [Header("Spawn points")]
    public Transform spawnPoint;
    public Transform despawnPoint;

    [Header("Timer settings")]
    public int minSpawnInterval= 5;
    public int maxSpawnInterval = 10;

    public Tutorial tut;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {
        base.nextBaseUpdate = SetNextSpawnTime();
        tut = GameplayManager.instance.GetComponent<Tutorial>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(GameplayManager.instance.isWalking && tut.playedLanternTut2)
            base.Update();
	}

    public override void UpdateTick()
    {
        GameObject objectToSpawn = RandomSelectObject();

        if (!tut.firstBarricadeSpawn)
        {
            if (objectToSpawn.name == "Barricade")
                tut.firstBarricadeSpawn = true;
        }
        else if (!tut.firstMatSpawn)
            tut.firstMatSpawn = true;

        SpawnRandomPosition(objectToSpawn);
    }

    public void SpawnRandomPosition(GameObject go)
    {
        float randomYPos = UnityEngine.Random.Range(0, 2) == 1 ? spawnPoint.position.y + UnityEngine.Random.Range(0f, 2f) : spawnPoint.position.y - UnityEngine.Random.Range(0f, 2f);
        Vector3 objectPos = new Vector3(spawnPoint.localPosition.x, randomYPos, spawnPoint.localPosition.z);
        Instantiate(go, objectPos, Quaternion.identity);
        base.nextBaseUpdate += SetNextSpawnTime();
    }

    public void SpawnObject(Vector3 position)
    {
        GameObject go = UnityEngine.Random.Range(0, 2) == 1 ? food : materials;
        Instantiate(go, position, Quaternion.identity);
    }

    public GameObject RandomSelectObject()
    {

        int random = UnityEngine.Random.Range(0, 3);
        GameObject returnObject = null;

        switch (random)
        {
            case 0:
                returnObject = food;
                break;
            case 1:
                returnObject = materials;
                break;
            case 2:
                returnObject = barricade;
                break;
        }

        return returnObject;
    }

    public int SetNextSpawnTime()
    {
        return UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
