using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private LayerMask layerMask;
    PuzzlePiece heldPuzzlePiece;
    RaycastHit2D hit;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    var lookpos = Camera.main.(Input.mousePosition);
        //     hit = Physics2D.Raycast(Input.mousePosition, lookpos, float.MaxValue , layerMask);
        //    Debug.DrawRay(lookpos, lookpos + Vector3.forward * 15);
        //    if (hit)
        //    {
        //        print(hit.collider.name);
        //        heldPuzzlePiece = hit.collider.gameObject.GetComponent<PuzzlePiece>();
        //        heldPuzzlePiece.isMoving = true;
        //    }
        //}
    }
    public void StartGame(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
   


}
