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

    bool enteredTop = false;
    bool enteredButtom = false;
    // Update is called once per frame
    void Update()
    {
        if (FindMouseTopBottom.Instance.isTopSide())
        {
            if (!enteredTop)
            {
                enteredTop = true;
                enteredButtom = false;
                fartPack.transform.rotation =
                     Quaternion.Euler(-90, fartPack.transform.rotation.y, fartPack.transform.rotation.z);
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Idle", true);

            }
<<<<<<< HEAD
        }
        else
        {
            if (!enteredButtom)
            {
                enteredTop = false;
                enteredButtom = true;
                fartPack.transform.rotation =
                    Quaternion.Euler(90, fartPack.transform.rotation.y, fartPack.transform.rotation.z);
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Idle", true);
=======

            if (Input.GetKey(KeyCode.D) && !DashenteredButtomRight)
            {
                DashenteredButtomLeft = false;
                DashenteredButtomRight = true;

                DashenteredTopLeft = false;
                DashenteredTopRight = false;

                enteredTopLeft = false;
                enteredTopRight = false;
                enteredButtomLeft = false;
                enteredButtomRight = false;

                fartPack.transform.rotation =
                    Quaternion.Euler(-90, fartPack.transform.rotation.y, 45);
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Right Dash", false);
                print("BACK RIGHT DASH AAAAAAAAA");
            }
            //else if (Input.GetKey(KeyCode.W) && !DashenteredButtomRight)
            //{
            //    DashenteredButtomLeft = false;
            //    DashenteredButtomRight = false;

            //    DashenteredTopLeft = false;
            //    DashenteredTopRight = false;

            //    enteredTopLeft = false;
            //    enteredTopRight = false;
            //    enteredButtomLeft = false;
            //    enteredButtomRight = false;

            //    fartPack.transform.rotation =
            //        Quaternion.Euler(-90, fartPack.transform.rotation.y, 0);
            //    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Right Dash", false);
            //    print("BACK RIGHT DASH AAAAAAAAA");
            //}
        }
        else
        {

            if (!controller.isDashing)
            {
                if (Input.GetKey(KeyCode.A) && !enteredTopLeft)
                {
                    enteredTopLeft = true;
                    enteredTopRight = false;

                    enteredButtomLeft = false;
                    enteredButtomRight = false;

                    DashenteredButtomLeft = false;
                    DashenteredButtomRight = false;
                    DashenteredTopLeft = false;
                    DashenteredTopRight = false;

                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Walk Left", true);
                    print("FRONT LEFT");

                }

                if (Input.GetKey(KeyCode.D) && !enteredTopRight)
                {
                    enteredTopLeft = false;
                    enteredTopRight = true;

                    enteredButtomLeft = false;
                    enteredButtomRight = false;

                    DashenteredButtomLeft = false;
                    DashenteredButtomRight = false;
                    DashenteredTopLeft = false;
                    DashenteredTopRight = false;
                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Walk Right", true);
                    print("FRONT RIGHT");
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.A) && !DashenteredTopLeft)
                {
                    fartPack.transform.rotation =
                        Quaternion.Euler(90, fartPack.transform.rotation.y, -45);
                    DashenteredTopLeft = true;
                    DashenteredTopRight = false;

                    DashenteredButtomLeft = false;
                    DashenteredButtomRight = false;

                    enteredTopLeft = false;
                    enteredTopRight = false;
                    enteredButtomLeft = false;
                    enteredButtomRight = false;

                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Left Dash", false);
                    print("FRONT LEFT DASH");

                }

                if (Input.GetKey(KeyCode.D) && !DashenteredTopRight)
                {
                    fartPack.transform.rotation =
                        Quaternion.Euler(90, fartPack.transform.rotation.y, 45);
                    DashenteredTopRight = true;
                    DashenteredTopLeft = false;

                    DashenteredButtomLeft = false;
                    DashenteredButtomRight = false;

                    enteredTopLeft = false;
                    enteredTopRight = false;
                    enteredButtomLeft = false;
                    enteredButtomRight = false;

                    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Right Dash", false);
                    print("FRONT RIGHT DASH");
                }
                //if (Input.GetKey(KeyCode.S) && !DashenteredTopRight)
                //{
                //    DashenteredButtomLeft = false;
                //    DashenteredButtomRight = false;

                //    DashenteredTopLeft = false;
                //    DashenteredTopRight = false;

                //    enteredTopLeft = false;
                //    enteredTopRight = false;
                //    enteredButtomLeft = false;
                //    enteredButtomRight = false;

                //    fartPack.transform.rotation =
                //        Quaternion.Euler(90, fartPack.transform.rotation.y, 0);
                //    skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Front Right Dash", false);
                //    print("BACK RIGHT DASH AAAAAAAAA");
                //}
>>>>>>> 983e8d1 (no message)
            }
        }
    }
}
