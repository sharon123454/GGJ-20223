using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    float t = 0;
    float _t = 0;
    float duration = 1f;
    float _duration = 1f;
    public Image _image;
    public AnimationCurve anim;
    public GameObject FirstClicked;
    public GameObject SecondClicked;
    public GameObject UglyDrawing;
    public GameObject stuffToClose;
    public IEnumerator CameraLerEnumerator()
    {
        while (t < duration)
        {
            t += Time.deltaTime;
            _image.color = Color.Lerp(_image.color, new Color(_image.color.r, _image.color.g, _image.color.b, 1), anim.Evaluate(t / (duration * 15)));
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        UglyDrawing.SetActive(false);
        stuffToClose.SetActive(false);
        SecondClicked.SetActive(true);
        while (_t < _duration)
        {
            _t += Time.deltaTime;
            _image.color = Color.Lerp(_image.color, new Color(_image.color.r, _image.color.g, _image.color.b, 0), anim.Evaluate(t / (duration * 15)));
            yield return null;
        }
        FirstClicked.SetActive(false);

    }
    public void LerpIn()
    {
        StartCoroutine(CameraLerEnumerator());
    }
}
