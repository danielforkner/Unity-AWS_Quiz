using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion = 15f;
    [SerializeField] float timeToShowCorrectAnswer = 7f;
    public bool isAnsweringQuestion;
    public float fillFraction;
    public bool loadNextQuestion;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToAnswerQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                timerValue = timeToAnswerQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }
}
