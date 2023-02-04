using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class LerpDolly : MonoBehaviour
{
    float t = 0;
    float duration = 3f;
    public GameObject image;
    public GameObject distortion;
    public Image _image;
    private int getView = 0;
    public AnimationCurve anim;

    public int ChangeLevel;
    void Start()
    {
        AsyncOperationProgressExample.Instance.LoadButton(ChangeLevel);
        getView = (int)Camera.main.fieldOfView;
    }

    public IEnumerator CameraLerEnumerator()
    {
        distortion.SetActive(true);
        while (t < duration)
        {
            t += Time.deltaTime;
            image.transform.localScale = Vector3.Lerp(new Vector3(1.4f, 1.4f, 1.4f),
                new Vector3(10, 10, 10), t / duration);
            _image.color = Color.Lerp(_image.color, new Color(_image.color.r, _image.color.g, _image.color.b, 1), t / (duration*100));
            Camera.main.fieldOfView = Mathf.Lerp(getView, 1, t / duration);
            yield return null;
        }
        AsyncOperationProgressExample.Instance.StartNewGame();
    }

    public void LerpCamera()
    {
      //  
        StartCoroutine(CameraLerEnumerator());
    }
}
