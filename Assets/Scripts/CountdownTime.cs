using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTime : MonoBehaviour
{
    float currentTime = 180f;
    public int speed = 1;
    public GameObject gameoverscene;

    [SerializeField] TextMeshProUGUI countdowntext;

    private void Start()
    {
        gameoverscene.SetActive(false);
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime * speed;
        }
        else
        {
            currentTime = 0;
            gameoverscene.SetActive(true);
            this.gameObject.GetComponent<AudioSource>().Stop();
        }
        DisplayTime(currentTime);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        countdowntext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
