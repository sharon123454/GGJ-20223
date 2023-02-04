using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUntilNextGame : MonoBehaviour
{
    public float _time;
    public float realTime;
    public TextMeshProUGUI timeText;
    public int ChangeScene;
    void Start()
    {
        AsyncOperationProgressExample.Instance.LoadButton(ChangeScene);
    }

    private bool wentIn = false;
    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            timeText.text = $"{realTime} / {_time}";
        }

        timeText.text = $"{realTime.ToString("0")}/ {_time.ToString("0")}";

        if (_time <= realTime && !wentIn)
        {
            wentIn = true;

            AsyncOperationProgressExample.Instance.StartNewGame();
        }

    }
}
