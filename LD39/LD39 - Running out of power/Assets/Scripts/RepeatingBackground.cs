using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    //Awake is called before Start.
    private void Awake()
    {
        groundHorizontalLength = GetComponent<BoxCollider2D>().size.x;
    }

    //Update runs once per frame
    private void Update()
    {
        var moveSpeed = GameplayManager.instance.moveSpeed;
        if (GameplayManager.instance.isWalking)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -groundHorizontalLength)
            RepositionBackground();
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2)transform.position + groundOffSet;
    }
}