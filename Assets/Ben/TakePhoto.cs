using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour
{
    Camera cam;
    [SerializeField] RenderTexture rt;
    [SerializeField] SpriteRenderer Target;
    private void Awake()
    {
        cam = GetComponent<Camera>();

    }


    public void Stuff()
    {
        Target.sprite = RenderTextureToSprite(rt);
    }

    Sprite RenderTextureToSprite(RenderTexture rt)
    {
        Texture2D texture = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
