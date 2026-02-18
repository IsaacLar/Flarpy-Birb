using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class countdownManager : MonoBehaviour
{
    public GameObject startScreen;
    public Text countdownText;
    public Globalscript Global;

    private int countdownTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(startCountdown());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator startCountdown()
    {
        startScreen.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        Global.isPaused = true;

        for (countdownTime = 3; countdownTime > 0; countdownTime--)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        Time.timeScale = 1;
        AudioListener.pause = false;
        Global.isPaused = false;
        startScreen.SetActive(false);
    }
}
