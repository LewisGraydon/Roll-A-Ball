using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text levelText;
    public GameObject PauseMenu;
    public GameObject Player;

    private Rigidbody rb;
    private int count;
    private int sceneNumber;

    void Start()
    {
        //sets the rigidbody variable
        rb = GetComponent<Rigidbody>();

        //sets the sceneNumber by getting the build index
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        //Initialises the number of cubes collected to be 0
        count = 0;

        //Calls the function to set the cubes collected and check whether all cubes have been picked up
        SetCountText();

        levelText.text = "Level " + sceneNumber.ToString();
        PlayerPrefs.SetInt("Level", sceneNumber);
    }

    void FixedUpdate()
    {
        //creates floats for the movement in the x and z axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //adds force to the player for the movement and speed
        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Checks to see if there is a collision between the player and the cubes
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Cubes Collected: " + count.ToString() + " / 8";
        if(count >= 8)
        {
            //Stores a variable to whether the level has been completed
            if(sceneNumber == 1)
            {
                PlayerPrefs.SetInt("LevelOneCompleted", 1);
            }

            if (sceneNumber == 2)
            {
                PlayerPrefs.SetInt("LevelTwoCompleted", 1);
            }

            if (sceneNumber == 3)
            {
                PlayerPrefs.SetInt("LevelThreeCompleted", 1);
            }

            if (sceneNumber == 4)
            {
                PlayerPrefs.SetInt("LevelFourCompleted", 1);
            }

            if (sceneNumber == 5)
            {
                PlayerPrefs.SetInt("LevelFiveCompleted", 1);
            }

            sceneNumber++;
            SceneManager.LoadScene(sceneNumber);
            PlayerPrefs.SetInt("Level", sceneNumber);
        }
    }

    public void Pause()
    {
        if (PauseMenu.gameObject.activeInHierarchy == false)
        {
            PauseMenu.gameObject.SetActive(true); //enables the pause menu
            //Time.timeScale = 0; //stops the timer
            Cursor.visible = true; //enables the cursor
            Player.SetActive(false); //disables the player's movement
        }
        else
        {
            PauseMenu.gameObject.SetActive(false); //disables the pause menu
            //Time.timeScale = 1; //re enables timer
            Cursor.visible = false; //disables the cursor
            Player.SetActive(true); //re activates the player's movement
        }
    }
}
