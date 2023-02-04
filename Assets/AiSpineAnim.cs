using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpineAnim : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public int trackIndex = 0;
    private bool wentLeft = false;
    private bool wentRight = false;

    private void Start()
    {
        skeletonAnimation.AnimationState.SetAnimation(1, "Walk Right", true);
    }
    private void Update()
    {

        if (transform.rotation.y >= 45 && !wentLeft)
        {
            wentLeft = true;
            wentRight = false;
            skeletonAnimation.AnimationState.SetAnimation(1, "Walk Left", true);
        }
        if (transform.rotation.y <= -45 && !wentRight)
        {
            wentLeft = false;
            wentRight = true;
            skeletonAnimation.AnimationState.SetAnimation(1, "Walk Right", true);
        }
    }

    public void Attack()
    {
        skeletonAnimation.AnimationState.SetAnimation(1, "Attack", false);
    }
}
