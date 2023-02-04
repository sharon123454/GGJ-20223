using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDolly : MonoBehaviour
{
    float t = 0;
    float duration = 1f;
    public GameObject image;
    private int getView = 0;
    void Start()
    {
        getView = (int)Camera.main.fieldOfView;
    }

    public IEnumerator CameraLerEnumerator()
    {
        AsyncOperationProgressExample.Instance.LoadButton();
        while (t < duration)
        {
            t += Time.deltaTime / duration;
            image.transform.localScale = Vector3.Lerp(new Vector3(1.4f, 1.4f, 1.4f),
                new Vector3(10, 10,10), t / duration);
            Camera.main.fieldOfView = Mathf.Lerp(getView, 1, t / duration);
            yield return null;
        }
        AsyncOperationProgressExample.Instance.StartNewGame();
    }

    public void LerpCamera()
    {
        StartCoroutine(CameraLerEnumerator());
    }
}
