using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    PuzzlePiece heldPuzzlePiece;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }

    private void Update()
    {
        

    }

    public void StartGame(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

}