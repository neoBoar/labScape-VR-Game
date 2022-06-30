//333333333333333333333333333333333333333333333333333333333333333333\\
//
//          Arthur: Cato Parnell
//          Description of script: control keypad button clicks and actions
//          Edited: Neil Boardman
//         
//
//33333333333333333333333333333333333333333333333333333333333333333\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;

    [Header("Keypad Settings")]
    public string curPassword = "123";
    public string input;
    public GameObject door;
    public Text displayText;
    public AudioSource audioData;
    Animator anim;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    private void Awake()
    {
        anim = door.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                // LOG message that password is correct
                anim.SetTrigger("curPass");
                Debug.Log("Correct Password!");
                input = ""; //Clear Password
                btnClicked = 0;

            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }

    }

    void OnGUI()
    {
        // Action for clicking keypad( GameObject ) on screen
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {
            objectToEnable.SetActive(true);
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
