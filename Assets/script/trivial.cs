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

    private int Actual = 0;
   // private int indexActual = 0;

    public GameObject errorMessage;

    public Text Dice;
    public int diceRange;

<<<<<<< HEAD
=======
    public List<string[]> preguntasRespuestas = new List<string[]>()
{
    new string[] { "ï¿½En quï¿½ aï¿½o fue fundada la ciudad de Roma?", "753 a.C.", "900 d.C.", "1812 d.C.", "117 d.C." },
    new string[] { "ï¿½Quï¿½ rï¿½o pasa por Parï¿½s?", "El Sena", "El Tï¿½mesis", "El Danubio", "El Nilo" },
    new string[] { "ï¿½Cuï¿½l es el planeta mï¿½s grande del sistema solar?", "Jï¿½piter", "Tierra", "Marte", "Venus" },

};

>>>>>>> 9293a77a68c3e32d56ead3693ef15d6cfc6bf2e8
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

    public Text timeText;
    public Text categoryText;
    public Text questionText;

    private int[] scores = { 0, 0 };
    private int[] playerLives = { 5, 5 };

    private List<Question>[] questionLists;
    private int respuestaCorrecta;
    
    private string[] players = new string[2];

    // Variables de control del juego
   /* private bool gameStarted = false;
    private bool waitingForAnswer = false;*/
    //private float timeRemaining = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameScreen.SetActive(false);
        victoryScreen.SetActive(false);
<<<<<<< HEAD
        errorMessage.SetActive(false);
        newGameScreen.SetActive(false);
        questionScreen.SetActive(false);
=======
        errorMessage.SetActive(false); //Bea
>>>>>>> 9293a77a68c3e32d56ead3693ef15d6cfc6bf2e8

        // Mostrar el menï¿½ principal
        mainMenuScreen.SetActive(true);

        // Inicializar las listas de preguntas
        questionLists = new List<Question>[3];
        questionLists[0] = CienciasQuestions;
        questionLists[1] = HistoriaQuestions;
        questionLists[2] = EntretenimientoQuestions;

        
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
    }

    public void NewGame()
    {
        newGameScreen.SetActive(true);
        mainMenuScreen.SetActive(false);

    }
    
    public void game() //Bea
    {
<<<<<<< HEAD
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
=======
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
        
        
>>>>>>> 9293a77a68c3e32d56ead3693ef15d6cfc6bf2e8

            

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
    // Sale de la aplicacion NECESITA ARREGLO NO FUNCIONA
    public void quit()
    {
        Application.Quit();
    }

    public void rollDice()
    {
<<<<<<< HEAD
        // diceRange atributo que indica el numero random entre 1 y 3
        diceRange = Random.Range(1, 3);
        // Se iguala el numero al texto del boton
        Dice.text = diceRange.ToString();
        // Muestra la pantalla pregunta
        showPreguntas();
=======
        //desactiva el dado una vez asi el jugador no podrï¿½ darle
        Dice.interactable = false;

        diceRange = Random.Range(1, 4);

        Dice.GetComponent<Text>().text = diceRange.ToString();
>>>>>>> 9293a77a68c3e32d56ead3693ef15d6cfc6bf2e8


    }

    private void showPreguntas()
    {
        // Obtener una categoria aleatoria
        List<Question> categoriaSeleccionada = null;
        switch (diceRange)
        {
            case 1:
                categoriaSeleccionada = CienciasQuestions;
                break;
            case 2:
                categoriaSeleccionada = HistoriaQuestions;
                break;
            case 3:
                categoriaSeleccionada = EntretenimientoQuestions;
                break;
        }
        
        // Obtener una pregunta aleatoria de la categoria seleccionada
        int indexPregunta = Random.Range(1, 3);
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
            // La respuesta es correcta
            scores[Actual]++;
            questionScreen.SetActive(false);
            if (scores[Actual] == 3)
            {
                // Mostrar la pantalla de victoria
                victoryScreen.SetActive(true);
                gameScreen.SetActive(false);
                if (Actual == 0)
                {
                    victoriaJugador.text = players[0];
                }
                else
                {
                    victoriaJugador.text = players[1];
                }
            }

        }
        else
        {
            // La respuesta es incorrecta
            playerLives[Actual]--;
            questionScreen.SetActive(false);
            siguienteTurno();
            // Actualizar el número de vidas en la pantalla
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

        }
    }
    private string jugadorActual()
    {
        return players[Actual];
    }
    // Actualizar las vidas de los jugadores
    public void updateLives(Image[] heartImages, int numLives)
    {
        // Mostrar las imágenes de corazón correspondientes al número de vidas restantes
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < numLives)
            {
                // La imagen de corazón debe estar activada
                heartImages[i].gameObject.SetActive(true);
            }
            else
            {
                // La imagen de corazón debe estar desactivada
                heartImages[i].gameObject.SetActive(false);
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
        for (int i = 0; i < achievements1.Length; i++)
        {
            achievements1[i].enabled = (scores[0] > i);
            achievements2[i].enabled = (scores[1] > i);
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
        public int CorrectOptionIndex { get; set; } //numero de la posicion donde está la respuesta
    }

    public List<Question> CienciasQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "¿Cuál es el elemento más abundante en el universo?",
        Options = new string[] {"Helio", "Oxígeno", "Hidrógeno", "Carbono" },
        CorrectOptionIndex = 2
    },
    new Question()
    {
        QuestionText = "¿Cuál es la fórmula química del agua?",
        Options = new string[] {"H2O", "CO2", "NaCl", "CH4"},
        CorrectOptionIndex = 0
    },
    new Question()
    {
        QuestionText = "¿Quién descubrió la penicilina?",
        Options = new string[] {"Marie Curie", "Alexander Fleming", "Albert Einstein", "Isaac Newton"},
        CorrectOptionIndex = 1
    }
};

    public List<Question> HistoriaQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "¿En qué año se descubrió América?",
        Options = new string[] {"1776", "1812", "1945","1492"},
        CorrectOptionIndex = 3
    },
    new Question()
    {
        QuestionText = "¿Quién fue el primer presidente de los Estados Unidos?",
        Options = new string[] {"Abraham Lincoln", "George Washington", "Thomas Jefferson", "John F. Kennedy"},
        CorrectOptionIndex = 1
    },
    new Question()
    {
        QuestionText = "¿En qué año comenzó la Segunda Guerra Mundial?",
        Options = new string[] {"1939", "1941", "1943", "1945"},
        CorrectOptionIndex = 0
    }
};

    public List<Question> EntretenimientoQuestions = new List<Question>()
{
    new Question()
    {
        QuestionText = "¿Quién escribió la saga de Harry Potter?",
        Options = new string[] {"J.K. Rowling", "Stephenie Meyer", "Suzanne Collins", "Veronica Roth"},
        CorrectOptionIndex = 0
    },
    new Question()
    {
        QuestionText = "¿En qué película aparece el personaje de Darth Vader?",
        Options = new string[] {"Indiana Jones", "Jurassic Park", "Star Wars", "Titanic" },
        CorrectOptionIndex = 2
    },
    new Question()
    {
        QuestionText = "¿Cuál es el nombre del personaje principal en Breaking Bad?",
        Options = new string[] {"Jesse Pinkman", "Gus Fring", "Walter White", "Saul Goodman" },
        CorrectOptionIndex = 2
    }
};
}



/*Lista de cosas que faltan:
 * Poner un texto donde baje el tiempo cuando se contesta la pregunta de 10 segundos hacia 0, cuando se conteste a la pregunta antes del tiempo
 * mostrara otra vez la pantalla del juego y se quitara la pregunta si ha fallado un corazon menos si ha acertado un logro mas
 * Si se acaba el tiempo pasa al siguiente jugador
 * Saber que jugador esta jugando y cuando falle pasar al siguiente jugador
 * Cuando un jugador tenga todos las categorias correctas que salga la pantalla victoria, array de imagenes creo
 * Que salgan las respuestas en los botones respectivamente a su pregunta que haya salido
 * Los botones de las respuestas que sean verdes para las correctas y rojas para las incorrectas
 * Cuando falles se resta una vida, es decir, tendriamos un array de imagenes y se restaria uno a uno la vida cuando fallas una pregunta
 * Falta el boton restart en la pantalla del game de preguntas, el boton verde donde pone restart
 * 
*/