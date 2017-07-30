using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractClickablePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

    private void OnMouseDown()
    {
        ClickedObject();
    }

    protected abstract void ClickedObject();
}
