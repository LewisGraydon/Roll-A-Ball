using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelSelection : MonoBehaviour {

    public Button LevelTwo;
    public Button LevelThree;
    public Button LevelFour;
    public Button LevelFive;
    public Button LevelSix;

    int isLevelOneComplete;
    int isLevelTwoComplete;
    int isLevelThreeComplete;
    int isLevelFourComplete;
    int isLevelFiveComplete;

    void Start()
    {
        isLevelOneComplete = PlayerPrefs.GetInt("LevelOneCompleted");
        isLevelTwoComplete = PlayerPrefs.GetInt("LevelTwoCompleted");
        isLevelThreeComplete = PlayerPrefs.GetInt("LevelThreeCompleted");
        isLevelFourComplete = PlayerPrefs.GetInt("LevelFourCompleted");
        isLevelFiveComplete = PlayerPrefs.GetInt("LevelFiveCompleted");

        if (isLevelOneComplete != 1)
            {
                LevelTwo.GetComponent<Button>().enabled = false;
            }    
        else
            {
                LevelTwo.GetComponent<Button>().enabled = true;
            }

        if(isLevelTwoComplete != 1)
            {
                LevelThree.GetComponent<Button>().enabled = false;
            }    
        else
            {
                LevelThree.GetComponent<Button>().enabled = false;
            }

        if(isLevelThreeComplete != 1)
            {
                LevelFour.GetComponent<Button>().enabled = false;
            }    
        else
            {
                LevelFour.GetComponent<Button>().enabled = false;
            }

        if(isLevelFourComplete != 1)
            {
                LevelFive.GetComponent<Button>().enabled = false;
            }    
        else
            {
                LevelFive.GetComponent<Button>().enabled = false;
            }

        if(isLevelFiveComplete != 1)
            {
                LevelSix.GetComponent<Button>().enabled = false;
            }    
        else
            {
                LevelSix.GetComponent<Button>().enabled = false;
            }
    }

    public void Level1 ()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
}
