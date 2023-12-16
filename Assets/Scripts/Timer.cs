using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line to use TextMeshProUGUI

public class Timer : MonoBehaviour
{
    public float countdown = 59;
    public GameObject timeTextGameObject;
    private TextMeshProUGUI timeText; // Reference to the TextMeshProUGUI component
    public bool stopped = false;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeText = timeTextGameObject.GetComponent<TextMeshProUGUI>();
        
        if (timeText == null)
        {
            Debug.LogError("Text component not found on the timeText GameObject.");
        } else {
            timeText.text = getTimeString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopped) {
            if(countdown > 0) {
                countdown -= Time.deltaTime;

                timeText.text = getTimeString();
            } else {
                stopped = true;
                GameOver();
            Debug.Log("Temporizador parado");
            }
        }
    }

    string getTimeString()
    {
        string minutes;
        string seconds;
        minutes = (Mathf.Floor(Mathf.Round(countdown)/60)).ToString();
        seconds = (Mathf.Round(countdown)%60).ToString();

        if(minutes.Length==1){minutes="0"+minutes;}
        if(seconds.Length==1){seconds="0"+seconds;}

        return minutes + ":" + seconds;
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
