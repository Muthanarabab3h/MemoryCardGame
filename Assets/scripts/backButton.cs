using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    [SerializeField]
    private int level;
    // Start is called before the first frame update
    public void backButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 - level);
    }
    public void homeButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - level);
    }

}
