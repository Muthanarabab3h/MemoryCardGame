using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using Unity.VisualScripting;

public class Bar : MonoBehaviour
{
    float timeLeft;
    public float maxTime = 5f;
    public Image timeBar;
    //end of linear time 
    public GameObject lose;
    public GameObject Game;


    // Sta
    void Start()
    {
        timeBar = GetComponent<Image>();

        timeLeft = maxTime;

    }

    void Update()
    {
        Timer();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if (timeLeft == 0)
        {
            Time.timeScale = 0;
            lose.SetActive(true);
            Game.SetActive(false);
            StopCoroutine(Timer());
            StopAllCoroutines();

        }
        else
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
    }
}