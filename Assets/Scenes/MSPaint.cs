using UnityEngine;
using UnityEngine.UI;

public class MSPaint : MonoBehaviour
{
    [SerializeField] GameObject thing;
    [SerializeField] float ASDAS = 1;
    LayerMask wall;
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
                if (hit.collider.gameObject.name == "RawImage")
                {
                    print("3");
                    Instantiate(thing, new Vector3(
                       hit.point.x ,
                       hit.point.y,
                       hit.point.z + ASDAS)
                     , thing.transform.rotation);

                }


            }
        }


    }
}