using System;
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
    public GameObject eyes;
    public int trackIndex = 1;

    bool enteredTopLeft = false;
    bool enteredTopRight = false;

    bool enteredButtomLeft = false;
    bool enteredButtomRight = false;

    bool DashenteredTopLeft = false;
    bool DashenteredTopRight = false;

    bool DashenteredButtomLeft = false;
    bool DashenteredButtomRight = false;
    public Controller controller;
    private SpriteRenderer test;
    void Start()
    {
        skeletonAnimation.AnimationState.End += AnimationState_End;
        
    }

    private void AnimationState_End(TrackEntry trackEntry)
    {
        if (!trackEntry.Loop)
        {
            DashenteredTopLeft = false;
            DashenteredTopRight = false;
            DashenteredButtomLeft = false;
            DashenteredButtomRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FindMouseTopBottom.Instance.isTopSide() && !controller.isDashing)
        {
            eyes.gameObject.SetActive(false);

            if (Input.GetKey(KeyCode.A) && !enteredButtomLeft)
            {
                enteredButtomLeft = true;
                enteredButtomRight = false;

                enteredTopLeft = false;
                enteredTopRight = false;

                DashenteredButtomLeft = false;
                DashenteredButtomRight = false;
                DashenteredTopLeft = false;
                DashenteredTopRight = false;
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Walk Left", true);
                print("BACK LEFT");

            }

            if (Input.GetKey(KeyCode.D) && !enteredButtomRight)
            {
                enteredButtomLeft = false;
                enteredButtomRight = true;

                enteredTopLeft = false;
                enteredTopRight = false;

                DashenteredButtomLeft = false;
                DashenteredButtomRight = false;
                DashenteredTopLeft = false;
                DashenteredTopRight = false;
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Walk Right", true);
                print("BACK RIGHT");
            }

        }
        else if (FindMouseTopBottom.Instance.isTopSide() && controller.isDashing)
        {
            if (Input.GetKey(KeyCode.A) && !DashenteredButtomLeft)
            {
                DashenteredButtomRight = false;
                DashenteredButtomLeft = true;

                DashenteredTopRight = false;
                DashenteredTopLeft = false;

                enteredTopLeft = false;
                enteredTopRight = false;
                enteredButtomLeft = false;
                enteredButtomRight = false;

                fartPack.transform.rotation =
                    Quaternion.Euler(-90, fartPack.transform.rotation.y, -45);
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Back Left Dash", false);
                print("BACK LEFT DASH");

            }

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
            eyes.gameObject.SetActive(true);

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
                if (Input.GetKey(KeyCode.S) && !DashenteredTopRight)
                {
                    fartPack.transform.rotation =
                        Quaternion.Euler(90, fartPack.transform.rotation.y, 0);
                    DashenteredTopRight = false;
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
            }
        }
    }
}
