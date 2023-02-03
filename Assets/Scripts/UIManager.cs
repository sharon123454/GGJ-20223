using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour

{
    [SerializeField] Image heartOne;
    [SerializeField] Image heartTwo;
    [SerializeField] Image heartThree;


    public void RefreshHeart(int updatedHearts)
    {
        switch (updatedHearts)
        {
            case 1:
                heartOne.enabled = true;
                heartTwo.enabled = false;
                heartThree.enabled = false;
                break;
            case 2:
                heartOne.enabled = true;
                heartTwo.enabled = true;
                heartThree.enabled = false;
                break;
            case 3:
                heartOne.enabled = true;
                heartTwo.enabled = true;
                heartThree.enabled = true;
                break;
            default:
                break;
        }
    }


}


