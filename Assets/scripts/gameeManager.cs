using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameeManager : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public GameObject Game;

    
    public List<Button> buttons = new List<Button>();
    public List<Sprite> puzzelsSprite = new List<Sprite>();

    public Sprite defultSprite;
/*    public Sprite[] puzzelsSprite;
*/
    private bool firstGuess, secondGuess;

    private int countGuess;
    private int countCorrectGuess;

    private int firstGuesstIndex, secondGuessIndex;

    private string firstGuesstPuzzels, secondGuessPuzzels;

  public Text time;

    public int sec;

    void Start()
    {



        GetButton();
        AddListeners();

          StartCoroutine(Timer());

        time.text = sec / 60 + ":" + sec % 60;

        countGuess = puzzelsSprite.Count / 2;
        suffle(puzzelsSprite);

    }

    



    void GetButton()
    {
        GameObject[] objects =
            GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        sec--;
        time.text = sec/60 + ":" + sec % 60;
        if (sec == 0)
        {
            lose.SetActive(true);
            Game.SetActive(false);
            StopCoroutine(Timer());
            StopAllCoroutines();
        }
        else
            StartCoroutine(Timer());
    }
    

    void AddListeners()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PickPuzzels);
        }
    }

    public void PickPuzzels()
    {
        FindObjectOfType<sounds>().SoundPlayer(0, 1);
        string name = UnityEngine.EventSystems.
            EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuesstIndex = int.Parse(name);
            firstGuesstPuzzels = puzzelsSprite[firstGuesstIndex].name;
            buttons[firstGuesstIndex].image.sprite = puzzelsSprite[firstGuesstIndex];
        }
        else if (!secondGuess)
        {
            secondGuessIndex = int.Parse(name);
            if (firstGuesstIndex != secondGuessIndex)
            {
                secondGuess = true;

                secondGuessPuzzels = puzzelsSprite[secondGuessIndex].name;
                buttons[secondGuessIndex].image.sprite = puzzelsSprite[secondGuessIndex];
                StartCoroutine(CheckIfThePuzzelsMatch());
            }

        }

    


        IEnumerator CheckIfThePuzzelsMatch()
        {
            yield return new WaitForSeconds(0.1f);
            if (firstGuesstPuzzels == secondGuessPuzzels)
            {
                CheckIfGameIsFinsh();
                buttons[firstGuesstIndex].interactable = false;
                buttons[secondGuessIndex].interactable = false;

                buttons[firstGuesstIndex].image.color = new Color(0, 0, 0, 0);
                buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                Handheld.Vibrate();
                FindObjectOfType<sounds>().SoundPlayer(0, 1);
                buttons[firstGuesstIndex].image.sprite = defultSprite;
                buttons[secondGuessIndex].image.sprite = defultSprite;


            }
            firstGuess = secondGuess = false;
        }

        void CheckIfGameIsFinsh()
        {
            countCorrectGuess++;
            if (countCorrectGuess == countGuess)
            {

                win.SetActive(true);
                StopAllCoroutines();


            }


        }
    }
    void suffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {

            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

        }



    }




}