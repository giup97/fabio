using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeskin : MonoBehaviour
{
    public AnimatorOverrideController blue;
    public AnimatorOverrideController skele;

    public void blueskin()
    {
        GetComponent<Animator>().runtimeAnimatorController = blue as RuntimeAnimatorController;
    }

    public void skeleskin()
    {
        GetComponent<Animator>().runtimeAnimatorController = skele as RuntimeAnimatorController;
    }
}
