using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text text1;
    public Text text2;
    public Text text3;
    public Button darkTunnel;

    private float tt1;
    private float tt2;
    private float tt3;
    private float dtt;

    private float animSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Color c = text1.color;
        c.a = Mathf.Lerp(0f, 1f, tt1);
        text1.color = c;

        tt1 += animSpeed * Time.deltaTime;

        if (c.a >= 1f)
        {
            Color c1 = text2.color;
            c1.a = Mathf.Lerp(0f, 1f, tt2);
            text2.color = c1;

            tt2 += animSpeed * Time.deltaTime;

            if (c1.a >= 1f)
            {

                Color c2 = text3.color;
                c2.a = Mathf.Lerp(0f, 1f, tt3);
                text3.color = c2;

                tt3 += animSpeed * Time.deltaTime;

                if (c2.a >= 1f)
                {
                    Color c3 = darkTunnel.image.color;
                    c3.a = Mathf.Lerp(0f, 1f, dtt);
                    darkTunnel.image.color = c1;

                    dtt += animSpeed * Time.deltaTime;

                }
            }
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
