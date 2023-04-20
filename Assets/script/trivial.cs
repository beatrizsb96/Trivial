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

    private int Actual = 0;


    public GameObject errorMessage;

    public Text Dice;
    public int diceRange;

    public Text banner1;
    public Text banner2;

    public Text pregunta;
    public Text respuesta0;
    public Text respuesta1;
    public Text respuesta2;
    public Text respuesta3;

    public Text victoriaJugador;

    public InputField player1NameInput;
    public InputField player2NameInput;

    public Image[] hearts1;
    public Image[] hearts2;
    public Image[] achievements1;
    public Image[] achievements2;

    public Text[] answerButtons; // Array de botones para respuestas
    public Button[] buttonsRespuesta;

    public Text timeText;
    public Text categoryText;
    public Text questionText;

    private string[] preguntas;


    private int[] scores = { 0, 0 };
    private int[] playerLives = { 5, 5 };

    
    public List<Question>[] questionLists;
    private int respuestaCorrecta;
    private int MAX_LIVES = 5;

    private string[] players = new string[2];

    private AudioSource audioSource;

    public bool starttime =false;
    public float time = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        gameScreen.SetActive(false);
        victoryScreen.SetActive(false);
        errorMessage.SetActive(false);
        newGameScreen.SetActive(false);
        questionScreen.SetActive(false);

        // Mostrar el men� principal
        mainMenuScreen.SetActive(true);

        // Inicializar las listas de preguntas
        questionLists = new List<Question>[3];
        questionLists[0] = CienciasQuestions;
        questionLists[1] = HistoriaQuestions;
        questionLists[2] = EntretenimientoQuestions;

        //Reproducir sonido durante el juego
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        //ESTO NO SE SI FUNCIONA NO LO HE PROBADO ES EL TIEMPO DE TRANSCURRE CUANDO CONTESTAS LA PREGUNTS
        /* if (gameStarted && waitingForAnswer)
         {
             timeRemaining -= Time.deltaTime;
             timeText.text = Mathf.RoundToInt(timeRemaining).ToString();

             if (timeRemaining <= 0)
             {
                 waitingForAnswer = false;

             }
         }*/
        timeText.text = time.ToString("F0");
        if (starttime == true)
        {
           
            time -= Time.deltaTime;
            if (time <= 0)
            {
                playerLives[Actual]--;
                updateLives(hearts1, playerLives[0]);
                updateLives(hearts2, playerLives[1]);
                questionScreen.SetActive(false);
                starttime = false;
                siguienteTurno();
            }
        }
        



    }

    public void NewGame()
    {
        newGameScreen.SetActive(true);
        mainMenuScreen.SetActive(false);

    }
    
    public void game()
    {
        if (!string.IsNullOrEmpty(player1NameInput.text) && !string.IsNullOrEmpty(player2NameInput.text))
        {
            gameScreen.SetActive(true);
            newGameScreen.SetActive(false);
            // En la pantalla de inicio pones los dos nombres de los jugadores 
            banner1.text = player1NameInput.text;
            banner2.text = player2NameInput.text;

            //Inicia el juego
            //timeRemaining = 10f; //Tiempo
            scores[0] = 0; // Puntucaion maxima 3
            scores[1] = 0; // Puntucion Maxima 3
            playerLives[0] = 5; // Array de Vidas del jugador 1
            playerLives[1] = 5; // Array de Vidad del jugador 2

            players[0] = player1NameInput.text;
            players[1] = player2NameInput.text;

            

        }
        else
        {
            errorMessage.SetActive(true);
        }
    }
    // Muestra la pantalla de creditos
    public void creditos()
    {
        creditsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }
    // Muestra el menu principal
    public void menu()
    {
        mainMenuScreen.SetActive(true);
        creditsScreen.SetActive(false);
        newGameScreen.SetActive(false);
        errorMessage.SetActive(false);
        gameScreen.SetActive(false);
        questionScreen.SetActive(false);

        player1NameInput.text = "Introduzca el jugador 1";
        player2NameInput.text = "Introduzca el jugador 2";



    }

    public void restart()
    {
        scores[0] = 0;
        scores[1] = 0;
        playerLives[0] = MAX_LIVES;
        playerLives[1] = MAX_LIVES;
        updateLives(hearts1, 5);
        updateLives(hearts2, 5);
        updateScores(achievements1, 0);
        updateScores(achievements2, 0);
        gameScreen.SetActive(true);
        questionScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }

    // Sale de la aplicacion NECESITA ARREGLO NO FUNCIONA
    public void quit()
    {
        Application.Quit();
    }

    public void rollDice()
    {
        // diceRange atributo que indica el numero random entre 1 y 3
        diceRange = Random.Range(1, 4);
        print(diceRange);
        // Se iguala el numero al texto del boton
        Dice.text = diceRange.ToString();
        // Muestra la pantalla pregunta
        showPreguntas();


    }

    private void showPreguntas()
    {
        // Obtener una categoria aleatoria
        List<Question> categoriaSeleccionada = null;
        switch (diceRange)
        {
            case 1:
                categoriaSeleccionada = HistoriaQuestions;
                break;
            case 2:
                categoriaSeleccionada = CienciasQuestions;
                break;
            case 3:
                categoriaSeleccionada = EntretenimientoQuestions;
                break;
        }
        
        // Obtener una pregunta aleatoria de la categoria seleccionada
        int indexPregunta = Random.Range(0, 3);
        Question preguntaSeleccionada = categoriaSeleccionada[indexPregunta];

        //Mostrar la pregunta en la pantalla
        pregunta.text = preguntaSeleccionada.QuestionText;

        // Mostrar las respuestas posibles en los botones correspondientes
        for(int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].text = preguntaSeleccionada.Options[i];
        }

        // Guardar la respuesta correcta actual
        respuestaCorrecta = preguntaSeleccionada.CorrectOptionIndex;


        questionScreen.SetActive(true);


        starttime = true;
        time = 10;

    }

    // Esta funcion averigua si esta correcta la respuesta
    private bool esRespuestaCorrecta(int respuestaSeleccionada)
    {
        if (respuestaSeleccionada == respuestaCorrecta)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Funcion que realiza al pulsar una respuesta y saber si es incorrecta o correcta

    public void correccion(int respuestaSeleccionada)
    {
        if (esRespuestaCorrecta(respuestaSeleccionada))
        {

            // Mostrar imagen correspondiente a la pregunta
            if (Actual == 0)
            {
                switch (diceRange)
                {
                    case 1:
                        achievements1[0].gameObject.SetActive(true);
                        break;
                    case 2:
                        achievements1[1].gameObject.SetActive(true);
                        break;
                    case 3:
                        achievements1[2].gameObject.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
            else if (Actual == 1)
            {
                switch (diceRange)
                {
                    case 1:
                        achievements2[0].gameObject.SetActive(true);
                        break;
                    case 2:
                        achievements2[1].gameObject.SetActive(true);
                        break;
                    case 3:
                        achievements2[2].gameObject.SetActive(true);
                        break;
                    default:
                        break;
                }
            }


            if (achievements1[0].IsActive() && achievements1[1].IsActive() && achievements1[2].IsActive()) {
                victoryScreen.SetActive(true);
                gameScreen.SetActive(false);
                victoriaJugador.text = players[0];
            }
            if (achievements2[0].IsActive() && achievements2[1].IsActive() && achievements2[2].IsActive())
            {
                victoryScreen.SetActive(true);
                gameScreen.SetActive(false);
                victoriaJugador.text = players[1];
            }
            questionScreen.SetActive(false);

        }


            //if (scores[Actual] == 3)
            //{
            //    // Mostrar la pantalla de victoria
            //    victoryScreen.SetActive(true);
            //    gameScreen.SetActive(false);

            //    if (Actual == 0)
            //    {
            //        victoriaJugador.text = players[0];
            //    }
            //    else
            //    {
            //        victoriaJugador.text = players[1];
            //    }
            //}

        else
        {
            // La respuesta es incorrecta
            playerLives[Actual]--;
            questionScreen.SetActive(false);
            siguienteTurno();
            // Actualizar el n�mero de vidas en la pantalla
            if (Actual == 0)
            {
                updateLives(hearts1, playerLives[Actual]);
            }
            else
            {
                updateLives(hearts2, playerLives[Actual]);
            }
            if (playerLives[Actual] == 0)
            {
                // Mostrar la pantalla de fin del juego
                gameScreen.SetActive(false);
                questionScreen.SetActive(false);
                victoryScreen.SetActive(true);
                if (Actual == 0)
                {
                    victoriaJugador.text= players[1];
                }
                else
                {
                    victoriaJugador.text = players[0];
                }
            }
            else
            {
                // Siguiente turno
                siguienteTurno();
                questionScreen.SetActive(false);
            }
            siguienteTurno();

        }

        starttime = false;
        time = 10;
        
    }
    // Actualizar las vidas de los jugadores
    public void updateLives(Image[] heartImages, int numLives)
    {
        // Mostrar las im�genes de coraz�n correspondientes al n�mero de vidas restantes
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < numLives)
            {
                // La imagen de coraz�n debe estar activada
                heartImages[i].gameObject.SetActive(true);
            }
            else
            {
                // La imagen de coraz�n debe estar desactivada
                heartImages[i].gameObject.SetActive(false);
            }
        }
    }
    // Actualizar la puntuaci�n del jugador
    public void updateScores(Image[] achivement, int score)
    {

        // Actualizar la imagen de la puntuaci�n del jugador
        for (int i = 0; i < achivement.Length; i++)
        {
            if (i < score)
            {
                // La imagen de puntuaci�n debe estar activada
                achivement[i].gameObject.SetActive(true);
            }
            else
            {
                // La imagen de puntuaci�n debe estar desactivada
                achivement[i].gameObject.SetActive(false);
            }
        }
    }
    // Pasa el turno del jugador
    public void siguienteTurno()
    {
        // Cambiar al siguiente jugador
        Actual = (Actual + 1) % 2;

        banner1.color = (Actual == 0) ? Color.red : Color.white;
        banner2.color = (Actual == 1) ? Color.red : Color.white;

        for (int i = 0; i < hearts1.Length; i++)
        {
            hearts1[i].enabled = (i < playerLives[0]);
            hearts2[i].enabled = (i < playerLives[1]);
        }
        
        // Volver a mostrar la pantalla del juego
        gameScreen.SetActive(true);
        questionScreen.SetActive(false);
    }
    // Esta es la clase de Preguntas
    

    public class Question
    {
        public string QuestionText { get; set; } //texto de la pregunta
        public string[] Options { get; set; } //Array de string de las respuestas
        public int CorrectOptionIndex { get; set; } //numero de la posicion donde est� la respuesta
    }

    public List<Question> CienciasQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "CIENCIA: CUAL ES EL ELEMENTO MAS ABUNDANTE DEL UNIVERSO?",
        Options = new string[] {"HELIO", "OXIGENO", "HIDROGENO", "CARBONO" },
        CorrectOptionIndex = 2
    },
    new Question()
    {
        QuestionText = "CIENCIA: CUAL ES LA FORMULA QUIMICA DEL AGUA?",
        Options = new string[] {"H2O", "CO2", "NaCl", "CH4"},
        CorrectOptionIndex = 0
    },
    new Question()
    {
        QuestionText = "CIENCIA: QUIEN DESCUBRIO LA PENICILINA?",
        Options = new string[] {"MARIE CURIE", "ALEXANDER FLEMING", "ALBERT EINSTEIN", "ISAAC NEWTON"},
        CorrectOptionIndex = 1
    }
};

    public List<Question> HistoriaQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "HISTORIA: CUANDO OCURRIO EL DESCUBRIMIENTO DE AMERICA?",
        Options = new string[] {"1776", "1812", "1945","1492"},
        CorrectOptionIndex = 3
    },
    new Question()
    {
        QuestionText = "HISTORIA: QUIEN FUE EL PRIMER PRESIDENTE DE LOS ESTADOS UNIDOS?",
        Options = new string[] {"ABRAHAM LINCOLN", "GEORGE WASHINGTON", "THOMAS JEFFERSON", "JOHN F. KENNEDY"},
        CorrectOptionIndex = 1
    },
    new Question()
    {
        QuestionText = "HISTORIA: CUANDO EMPEZO LA SEGUNDA GUERRA MUNDIAL?",
        Options = new string[] {"1939", "1941", "1943", "1945"},
        CorrectOptionIndex = 0
    }
};

    public List<Question> EntretenimientoQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "ENTRETENIMIENTO: QUIEN ESCRIBIO LA SAGA DE HARRY POTTER?",
        Options = new string[] {"J.K. ROWLING", "STEPHENIE MEYER", "SUZANNE COLLINS", "VERONICA ROTH"},
        CorrectOptionIndex = 0
    },
    new Question()
    {
        QuestionText = "ENTRETENIMIENTO: EN QUE PELICULA APARECE EL PERSONAJE DE DARTH VADER?",
        Options = new string[] {"INDIANA JONES", "JURASSIC PARK", "STAR WARS", "TITANIC" },
        CorrectOptionIndex = 2
    },
    new Question()
    {
        QuestionText = "ENTRETENIMIENTO: CUAL ES EL NOMBRE DEL PERSONAJE PRINCIPAL EN BREAKING BAD?",
        Options = new string[] {"JESSE PINKMAN", "GUS FRING", "WALTER WHITE", "SAUL GOODMAN" },
        CorrectOptionIndex = 2
    }
};
}



/*Lista de cosas que faltan:
 * Falta el boton restart en la pantalla del game de preguntas, el boton verde donde pone restart
 * 
*/