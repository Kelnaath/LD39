using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
