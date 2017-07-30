using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour {

    public Transform playerTransform;
    public GameObject particle;

    private float health;

	// Use this for initialization
	void Start () {
        health = Random.Range(20f,30f);
        playerTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x - playerTransform.position.x <= 2.5f)
        {
            GameplayManager.instance.isWalking = false;
        }

        var moveSpeed = GameplayManager.instance.moveSpeed;

        if(GameplayManager.instance.isWalking)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.AudioClips.HIT);
        health -= UpgradeManager.instance.GetUpgradePower(UpgradeManager.UpgradeType.BARRICADE);
        Instantiate(particle, transform.position, particle.transform.rotation);

        if (health <= 0)
        {
            if(Random.Range(0,2) == 1)
                SpawnManager.instance.SpawnObject(transform.position);

            AudioManager.instance.PlayAudioClip(AudioManager.AudioClips.DESTROY);

            Destroy(gameObject);
            GameplayManager.instance.isWalking = true;
        }

    }
}
