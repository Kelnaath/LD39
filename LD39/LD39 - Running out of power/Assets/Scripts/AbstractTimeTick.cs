using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTimeTick : MonoBehaviour {

    protected int nextBaseUpdate = 1;
    private int overflow = 10000;

    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        if (Time.time >= nextBaseUpdate)
        {
            if (nextBaseUpdate > overflow)
                nextBaseUpdate = 1;

            nextBaseUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateTick();
        }

    }

    public abstract void UpdateTick();
}
