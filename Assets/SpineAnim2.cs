using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnim2 : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public int trackIndex = 0;
    private bool wentLeft = false;
    private bool wentRight = false;

    private void Start()
    {
     //   skeletonAnimation.AnimationState.SetAnimation(1, "Final Walk", true);
    }
}
