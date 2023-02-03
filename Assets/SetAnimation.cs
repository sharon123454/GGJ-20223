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
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Idle Back", true);

            }
        }
        else
        {
            if (!enteredButtom)
            {
                enteredTop = false;
                enteredButtom = true;
                skeletonAnimation.AnimationState.SetAnimation(trackIndex, "Idle Front", true);
            }
        }
    }
}
