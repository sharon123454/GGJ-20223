using Spine;
using Spine.Unity;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;
using Color = UnityEngine.Color;

public class SetAnimation : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public GameObject fartPack;
    public int trackIndex = 1;

    bool enteredTopLeft = false;
    bool enteredTopRight = false;

    bool enteredButtomLeft = false;
    bool enteredButtomRight = false;
   public Controller controller;  
    // Update is called once per frame
    void Update()
    {
        if (FindMouseTopBottom.Instance.isTopSide() && !controller.isDashing)
        {

            fartPack.transform.rotation =
                 Quaternion.Euler(-90, fartPack.transform.rotation.y, fartPack.transform.rotation.z);
            if (Input.GetKey(KeyCode.A) && !enteredButtomLeft)
            {
                enteredButtomLeft = true;
                enteredButtomRight = false;

                enteredTopLeft = false;
                enteredTopRight = false;
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Walk Left", true);
                print("BACK LEFT");

            }
            if (Input.GetKey(KeyCode.D) && !enteredButtomRight)
            {
                enteredButtomLeft = false;
                enteredButtomRight = true;

                enteredTopLeft = false;
                enteredTopRight = false;
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Walk Right", true);
                print("BACK RIGHT");
            }
            //else
            //{
            //    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Idle", true);
            //}


        }
        else
        {
            if (!controller.isDashing)
            {
                fartPack.transform.rotation =
                    Quaternion.Euler(90, fartPack.transform.rotation.y, fartPack.transform.rotation.z);
                if (Input.GetKey(KeyCode.A) && !enteredTopLeft)
                {
                    enteredTopLeft = true;
                    enteredTopRight = false;

                    enteredButtomLeft = false;
                    enteredButtomRight = false;
                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Walk Left", true);
                    print("FRONT LEFT");

                }
                if (Input.GetKey(KeyCode.D) && !enteredTopRight)
                {
                    enteredTopLeft = false;
                    enteredTopRight = true;

                    enteredButtomLeft = false;
                    enteredButtomRight = false;
                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Walk Right", true);
                    print("FRONT RIGHT");
                }
            }
           

        }
    }
}
