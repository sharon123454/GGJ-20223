using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        timeText.text = $"You Survived {realTime} Seconds Out of {_time}";

        if (_time <= realTime && !wentIn)
        {
            wentIn = true;
            
             AsyncOperationProgressExample.Instance.StartNewGame();
        }

    }
}
