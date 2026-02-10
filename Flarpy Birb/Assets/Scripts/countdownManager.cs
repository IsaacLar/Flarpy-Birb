using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class countdownManager : MonoBehaviour
{
    public GameObject startScreen;
    public Text countdownText;

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

        for (countdownTime = 3; countdownTime > 0; countdownTime--)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        Time.timeScale = 1;
        startScreen.SetActive(false);
    }
}
