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

    public Button Dice;
    public int diceRange;

    public List<string[]> preguntasRespuestas = new List<string[]>()
{
    new string[] { "¿En qué año fue fundada la ciudad de Roma?", "753 a.C.", "900 d.C.", "1812 d.C.", "117 d.C." },
    new string[] { "¿Qué río pasa por París?", "El Sena", "El Támesis", "El Danubio", "El Nilo" },
    new string[] { "¿Cuál es el planeta más grande del sistema solar?", "Júpiter", "Tierra", "Marte", "Venus" },

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

        // Mostrar el menú principal
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
    
    public void game()
    {
        gameScreen.SetActive(true);
        newGameScreen.SetActive(false);

        banner1.text = player1NameInput.text;
        banner2.text = player2NameInput.text;


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
        //desactiva el dado una vez asi el jugador no podrá darle
        Dice.interactable = false;

        diceRange = Random.Range(1, 4);

        Dice.GetComponent<Text>().text = diceRange.ToString();


    }

    private void showPreguntas()
    {
        questionScreen.SetActive(true);

    }
}
