using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI timerText;
    public Image imageDisplay;
    public Image textImage;

    private int score;
    private int stage;
    private int currentLanguageIndex;
    private int currentFlagIndex;
    private int currentRiddleIndex;
    private int currentAnswerIndex;
    private float timer = 30.0f;
    private bool timerRunning = false;


    private string[] languages = {
        " bonjour Astro, joli costume!", // French (original)
        "Nihao Astro!!", // Mandarin Chinese (China)
         " hola Astru, lindo traje!",// Spanish (Mexico)
        " Salam Astro!!" // Egyptian Arabic (Egypt)
        //" G'day Astro mate! Noice Costume!", // Australian English (Australia)
        //"Nihao Astro!!", // Mandarin Chinese (China)
        //" Privet Astro!!", // Russian (Russia)
        //" Hello Astro, cute costume!", // English (Canada)
        ////" hola Astru, lindo traje!", // Spanish (Mexico)
        //" ol? Astru, traje bonito!", // Portuguese (Brazil)
        //" Namaste Astro!!" // Hindi (India)
    };
    private string[] flags = { "Egypt", "France", "China","Russia" };
    // "Australia", "Russia", "Canada", "Mexico", "Brazil", "India"
    private string[] riddles = {
        "I'm a land of kangaroos that hop with glee \n Deserts and beaches, as far as you can see \n Down under is where I'm found,\n Guess my name, and run to me as fast as you can!\n",
        "I'm a land of maple syrup sweet, \n  With forests and lakes, a scenic treat \n Cold winters, friendly and true, \n",
        "Vibrant colors and flavors in every corner you explore. From ancient ruins to modern cities, my culture you'll adore",
        "Explore my ancient wonders and history so grand \n Pyramids rise in the desert \n stretching across the land \n"
        //"Embark on a journey through my vast and diverse terrain. From tundra to taiga, where nature's beauty reigns.",
        //"Discover my wilderness, from the Rockies to the sea. A land of maple syrup, politeness, and courtesy.",
        //"Vibrant colors and flavors in every corner you explore. From ancient ruins to modern cities, my culture you'll adore.",
        //"Carnival rhythms fill the air, a spectacle beyond compare. In the heart of the Amazon, find adventure everywhere.",
        //"Land of spirituality and traditions, ancient stories and vibrant visions. Guess my name, where unity and diversity thrive."
    };
    //private string[] riddles = { "I'm a land of kangaroos that hop with glee Deserts and beaches, as far as you can see.Down under is where I'm found,Guess my name, and run to me as fast as you can !",
    private string[] Lanswers = { "France", "China", "Mexico","Egypt" };
    private string[] Fanswers = { "Egypt", "France", "China","Russia" };
    private string[] Ranswers = { "Australia", "Canada", "India","Egypt" };

    void Start()
    {
        //questionText = GetComponent<TextMeshProUGUI>();
        //scoreText = GetComponent<TextMeshProUGUI>();
        //timerText = GetComponent<TextMeshProUGUI>();
        InitializeGame();
    }
    private void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                Debug.Log("Time is up!");
                SceneManager.LoadScene("Game Over");

                timer = 30.0f;
                timerRunning = false; // Stop the timer
            }
            timerText.text = "Time: " + Mathf.Round(timer).ToString();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        bool answerCheck = CheckAnswer(other);

        if (answerCheck)
        {
            score++;

            if (stage < 3)
            {
                stage++;
                currentAnswerIndex++;
            }
            else
            {
                stage = 0;
            }

            UpdateUI();
        }
    }

    bool CheckAnswer(Collider other)
    {
        string currentAnswerTag = GetAnswerTag();

        if (currentAnswerTag != null && other.CompareTag(currentAnswerTag))
        {
            IncrementIndices();
            return true;
        }

        return false;
    }

    string GetAnswerTag()
    {
        int temp;
        switch (stage)
        {
            case 1:
                temp = currentLanguageIndex;
                currentLanguageIndex++;
                return Lanswers[temp];
            case 2:
                temp = currentFlagIndex;
                currentFlagIndex++;
                return Fanswers[temp];
            case 3:
                temp = currentRiddleIndex;
                if (currentRiddleIndex < riddles.Length - 1)
                {
                    currentRiddleIndex++;
                }
                return Ranswers[temp];

            default:
                return null;
        }

    }

    void IncrementIndices()
    {
        currentAnswerIndex++;  // Increment outside the if statements
        if (stage == 1)
        {
            currentLanguageIndex++;
        }
        else if (stage == 2)
        {
            currentFlagIndex++;
        }
        else if (stage == 3)
        {
            currentRiddleIndex++;
        }
    }

    void UpdateUI()
    {
        string s;

        switch (stage)
        {
            case 1:
                s= languages[currentLanguageIndex];
                questionText.text = s.ToString();
                SetImageVisibility(false);
                break;
            case 2:
                questionText.text = " ";
                SetImageVisibility(true);
                SetImageVisibilityy(false);
                break;
            case 3:
                SetImageVisibilityy(true);
                SetImageVisibility(false);
                s = riddles[currentRiddleIndex];
                questionText.text = s.ToString();
               // Debug.Log("Current Text: " + questionText.text);
                break;
        }

        // Update the score text
        scoreText.text = "Score: " + score.ToString();
    }

    void SetImageVisibility(bool isVisible)
    {
        if (imageDisplay != null)
        {
            imageDisplay.enabled = isVisible;

            if (isVisible)
            {
                string flagName = flags[currentFlagIndex];
                string imageName = flagName.ToLower();
                Sprite imageSprite = Resources.Load<Sprite>("Flags/" + imageName);
                imageDisplay.sprite = imageSprite;
            }
        }
    }

    void InitializeGame()
    {
        //if (scoreText != null && questionText != null)
        //{
        //    scoreText = GetComponent<TextMeshProUGUI>();
        //    questionText = GetComponent<TextMeshProUGUI>();
        //}
        SetImageVisibility(false);
        score = 0;
        stage = 1;
        currentLanguageIndex = 0;
        currentFlagIndex = 0;
        currentRiddleIndex = 0;
        currentAnswerIndex = 0;

        // Start the timer when the game initializes
        timerRunning = true;

        UpdateUI();
    }

    void SetImageVisibilityy(bool isVisible)
    {
        if (textImage != null)
        {
            textImage.enabled = isVisible;

        }
    }
}







