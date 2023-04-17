using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class trivial : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject gameScreen;
    public GameObject newGameScreen;
    public GameObject victoryScreen;
    public GameObject creditsScreen;
    public GameObject questionScreen;
    public GameObject errorMessage; //Bea

    public Button Dice;
    public int diceRange;

    public List<string[]> preguntasRespuestas = new List<string[]>()
{
    new string[] { "�En qu� a�o fue fundada la ciudad de Roma?", "753 a.C.", "900 d.C.", "1812 d.C.", "117 d.C." },
    new string[] { "�Qu� r�o pasa por Par�s?", "El Sena", "El T�mesis", "El Danubio", "El Nilo" },
    new string[] { "�Cu�l es el planeta m�s grande del sistema solar?", "J�piter", "Tierra", "Marte", "Venus" },

};

    public Text banner1;
    public Text banner2;

    public InputField player1NameInput;
    public InputField player2NameInput;

    public Image[] hearts1;
    public Image[] hearts2;
    public Image[] achievements1;
    public Image[] achievements2;

    public Text timeText;
    public Text categoryText;
    public Text questionText;

    private int[] scores = { 0, 0 };
    private int[] playerLives = { 5, 5 };

    // Variables de control del juego
    private bool gameStarted = false;
    private bool waitingForAnswer = false;
    private float timeRemaining = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameScreen.SetActive(false);
        victoryScreen.SetActive(false);
        errorMessage.SetActive(false); //Bea

        // Mostrar el men� principal
        mainMenuScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        newGameScreen.SetActive(true);
        mainMenuScreen.SetActive(false);

    }
    
    public void game() //Bea
    {
        if (!string.IsNullOrEmpty(player1NameInput.text) && !string.IsNullOrEmpty(player2NameInput.text)) 
        {
            gameScreen.SetActive(true);
            newGameScreen.SetActive(false);

            banner1.text = player1NameInput.text;
            banner2.text = player2NameInput.text;

        }
        else
        {
            errorMessage.SetActive(true);
        }
        
        

    }

    public void creditos()
    {
        creditsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    public void menu()
    {
        creditsScreen.SetActive(false);
        newGameScreen.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    private void rollDice()
    {
        //desactiva el dado una vez asi el jugador no podr� darle
        Dice.interactable = false;

        diceRange = Random.Range(1, 4);

        Dice.GetComponent<Text>().text = diceRange.ToString();


    }

    private void showPreguntas()
    {
        questionScreen.SetActive(true);

    }
}
