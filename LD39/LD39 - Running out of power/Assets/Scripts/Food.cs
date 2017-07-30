using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : AbstractClickablePickup {

    private float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameplayManager.instance.moveSpeed;
        if (GameplayManager.instance.isWalking)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < SpawnManager.instance.despawnPoint.position.x)
            Destroy(gameObject);
    }

    protected override void ClickedObject()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.AudioClips.PICKUP);
        ResourceManager.instance.AddFood(UnityEngine.Random.Range(3, 6));
        Destroy(gameObject);
    }
}
