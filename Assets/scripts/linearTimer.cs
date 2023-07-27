using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class linearTimer : MonoBehaviour
{
    //linear time 
    float timeLeft;
    public float maxTime = 5f;
    Image timeBar;
    //end of linear time 
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {

        //timer code
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
        //end of timerCode

    }

    void Update()
    {
        /*  if (timeLeft > 0)
          {
              timeLeft -= Time.deltaTime;
              timeBar.fillAmount = timeLeft / maxTime;
          }
          else
          {
              lose.SetActive(true);
              Time.timeScale = 0;


          }*/
        Timer();
    }
    void Timer()
    {
        
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
            
        }
        else
        {
            Time.timeScale = 0;
            lose.SetActive(true);
            StopAllCoroutines();

        }
    }
}
