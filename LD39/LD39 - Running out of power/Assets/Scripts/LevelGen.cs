using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {

    public static LevelGen instance;

    public List<GameObject> walls;
    public List<GameObject> roads;
    public Transform parent;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
