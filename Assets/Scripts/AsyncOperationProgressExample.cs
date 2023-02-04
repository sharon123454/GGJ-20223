//This script lets you load a Scene asynchronously. It uses an asyncOperation to calculate the progress and outputs the current progress to Text (could also be used to make progress bars).

//Attach this script to a GameObject
//Create a Button (Create>UI>Button) and a Text GameObject (Create>UI>Text) and attach them both to the Inspector of your GameObject
//In Play Mode, press your Button to load the Scene, and the Text changes depending on progress. Press the space key to activate the Scene.
//Note: The progress may look like it goes straight to 100% if your Scene doesn’t have a lot to load.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncOperationProgressExample : MonoBehaviour
{
    public static AsyncOperationProgressExample Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public Text m_Text;
    public Button m_Button;

    private AsyncOperation asyncOperation;
    void Start()
    {
        //Call the LoadButton() function when the user clicks this Button
        // m_Button.onClick.AddListener(LoadButton);
    }

    public void LoadButton(int currentScene)
    {
        //Start loading the Scene asynchronously and output the progress bar
        StartCoroutine(LoadScene(currentScene));
    }

    public void StartNewGame()
    {
        asyncOperation.allowSceneActivation = true;
    }
    IEnumerator LoadScene(int currentScene)
    {
        yield return null;

        //Begin to load the Scene you specify
        asyncOperation = SceneManager.LoadSceneAsync(currentScene);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        // Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            asyncOperation.allowSceneActivation = true;


            yield return null;
        }
    }
}