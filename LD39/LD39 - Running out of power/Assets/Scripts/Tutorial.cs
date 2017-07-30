using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public List<Text> tutorialTexts;

    public Text faster;

    public float animSpeed = 0.5f;

    public bool clickedLantern = false;
    public bool playedLanternTut2 = false;
    public bool firstMatSpawn = false;
    public bool firstBarricadeSpawn = false;

    private bool playedBarricadeTut = false;
    private bool playedMatTut = false;
    private bool playedLastTut = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartTutorials());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(playedLanternTut2 && firstBarricadeSpawn && !playedBarricadeTut)
        {
            StartCoroutine(AnimateText(tutorialTexts[2]));
            playedBarricadeTut = true;
        }
        else if(playedLanternTut2 && firstMatSpawn && !playedMatTut)
        {
            StartCoroutine(AnimateText(tutorialTexts[3]));
            playedMatTut = true;
        }
    }

    public IEnumerator StartTutorials()
    {
        yield return StartCoroutine(AnimateText(tutorialTexts[0]));
        yield return StartCoroutine(AnimateText(tutorialTexts[1]));
        yield return StartCoroutine(AnimateText(tutorialTexts[4]));
        playedLanternTut2 = true;
    }

    public IEnumerator AnimateText(Text t)
    {
        Color c = t.color;

        for (float time = 0f; time < 1f; time += animSpeed * Time.deltaTime)
        {
            c.a = Mathf.Lerp(0f, 1f, time);
            t.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        for (float time = 1f; time > 0f; time -= animSpeed * Time.deltaTime)
        {
            c.a = Mathf.Lerp(0f, 1f, time);
            t.color = c;
            yield return null;
        }
    }
}
