using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSPaint : MonoBehaviour
{
    [SerializeField] GameObject thing;
    [SerializeField] float ASDAS = 1;
    [SerializeField] Camera cam;
    [SerializeField] GameObject secondScreen;
    [SerializeField] GameObject firstScreen;
    [SerializeField] GameObject WhiteCanvas2;
    [SerializeField] GameObject WhiteCanvas1;
    List<GameObject> things = new List<GameObject>();


    LayerMask wall;
    float num =0;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = thing.GetComponent<SpriteRenderer>();
    }

    public void Red()
    {
        spriteRenderer.color = Color.red;
    }
    public void Black() 
    {
        spriteRenderer.color = Color.black;
    }

    public void Green()
    {
        spriteRenderer.color = Color.green;
    }
    public void yellow()
    {
        spriteRenderer.color = Color.yellow;
    }

    public void white()
    {
        spriteRenderer.color = Color.white;
    }

    public void Blue()
    {
        spriteRenderer.color = Color.blue;
    }

    public void Brown()
    {
        spriteRenderer.color = new Color(0.5f, 0.25f, 0);
    }

    public void Size1() 
    {
        thing.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    }
    public void Size2()
    { 
        thing.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }
    public void Size3()
    { 
        thing.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

    }


    public void ActiveScreen2()
    {
        
        secondScreen.SetActive(true);
        firstScreen.SetActive(false);
        WhiteCanvas2.SetActive(true);
        WhiteCanvas1.SetActive(false);

        foreach (var item in things)
        {
            item.SetActive(false);
        }

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            print("1");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,10000))
            {
                print("2");
                if (hit.collider.gameObject.name == "RawImage" || hit.collider.gameObject.name == "TestDontTouch(Clone)")
                {
                    print("3");
                   var x = Instantiate(thing, new Vector3(
                       hit.point.x ,
                       hit.point.y,
                       0.1791199f + (ASDAS+num))
                     , thing.transform.rotation);
                    num -= 0.00002f;
                    x.transform.LookAt(cam.transform);
                    things.Add(x);
                }
                
               


            }
        }


    }
}