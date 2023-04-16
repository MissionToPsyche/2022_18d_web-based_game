using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public QnA[] listOfQuestions;
    private static List<QnA> unansweredQuestions;
    private QnA currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject questionPanel;
    [SerializeField] AudioSource bg;
    [SerializeField] private GameObject correctFeedback;
    [SerializeField] private GameObject incorrectFeedback;

    public int successEndgame;

    // Start is called before the first frame update
    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = listOfQuestions.ToList<QnA>();
        }

        //get a random question
        GetQuestion();
    }

    void GetQuestion()
    {
        int randomQuestion = Random.Range(0, unansweredQuestions.Count);
        QnA qna = unansweredQuestions[randomQuestion];
        currentQuestion = qna;

        questionText.text = currentQuestion.question;

        unansweredQuestions.RemoveAt(randomQuestion);
    }

    void SetCorrectFalse() { correctFeedback.SetActive(false); }
    void SetIncorrectFalse() { incorrectFeedback.SetActive(false); }

    //if user selects "True"
    public void SelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            score += 1;
            scoreText.text = score.ToString();
            questionPanel.SetActive(false);
            Time.timeScale = 1f;
            bg.Play();

            correctFeedback.SetActive(true);
            Invoke("SetCorrectFalse", 2.0f);

            GetQuestion();
        }
        else
        {
            questionPanel.SetActive(false);
            Time.timeScale = 1f;
            bg.Play();

            incorrectFeedback.SetActive(true);
            Invoke("SetIncorrectFalse", 2.0f);

            GetQuestion();
        }
    }

    //if user selects "False"
    public void SelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            score += 1;
            scoreText.text = score.ToString();
            questionPanel.SetActive(false);
            Time.timeScale = 1f;
            bg.Play();

            correctFeedback.SetActive(true);
            Invoke("SetCorrectFalse", 2.0f);

            GetQuestion();
        }
        else
        {
            questionPanel.SetActive(false);
            Time.timeScale = 1f;
            bg.Play();

            incorrectFeedback.SetActive(true);
            Invoke("SetIncorrectFalse", 2.0f);

            GetQuestion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 5)
        {
            SceneManager.LoadScene(successEndgame);
        }
    }
}
