using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FadeToWhite : MonoBehaviour
{
    public static FadeToWhite instance;


    [SerializeField] private float timeForFade;

    private Color clear = new Color(1, 1, 1, 0);
    private Color full = new Color(1, 1, 1, 1);
    private Image imageToFade;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        imageToFade = GetComponent<Image>();
    }

    public void CallFadeIn() { StartCoroutine(FadeIn()); }
    public void CallFadeOut() { StartCoroutine(FadeOut()); }

    private IEnumerator FadeIn()
    {
        while (imageToFade.color.a < 1)
        {
            yield return new WaitForEndOfFrame();
            imageToFade.color = Color.Lerp(imageToFade.color, full, timeForFade);
            yield return new WaitForEndOfFrame();
        }

    }
    private IEnumerator FadeOut()
    {
        while (imageToFade.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            imageToFade.color = Color.Lerp(imageToFade.color, clear, timeForFade);
            yield return new WaitForEndOfFrame();
        }

    }

}