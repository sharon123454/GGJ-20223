using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class LerpDolly : MonoBehaviour
{
    float t = 0;
    float duration = 1f;
    public GameObject image;
    public Image _image;
    private int getView = 0;
    public AnimationCurve anim;

    public int ChangeLevel;
    void Start()
    {
        getView = (int)Camera.main.fieldOfView;
    }

    public IEnumerator CameraLerEnumerator()
    {
        AsyncOperationProgressExample.Instance.LoadButton(ChangeLevel);
        while (t < duration)
        {
            t += Time.deltaTime;
            image.transform.localScale = Vector3.Lerp(new Vector3(1.4f, 1.4f, 1.4f),
                new Vector3(10, 10, 10), anim.Evaluate(t / duration));
            _image.color = Color.Lerp(_image.color, new Color(_image.color.r, _image.color.g, _image.color.b, 1), anim.Evaluate(t / (duration * 25)));
            Camera.main.fieldOfView = Mathf.Lerp(getView, 1, anim.Evaluate(t /duration));
            yield return null;
        }
        AsyncOperationProgressExample.Instance.StartNewGame();
    }   

    public void LerpCamera()
    {
        StartCoroutine(CameraLerEnumerator());
    }
}
