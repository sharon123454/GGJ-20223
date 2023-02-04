using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LerpDolly dolly;
    private int count3Events = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }

    private bool wentIn = false;
    void Update()
    {
        if (count3Events == 3 && !wentIn)
        {
            wentIn = true;
            dolly.LerpCamera();
        }
    }
    public void StartGame(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void RiseCount()
    {
        count3Events++;
    }

}