using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Body : MonoBehaviour
{
    [SerializeField] private BodyPart[] BodyParts;

    [SerializeField] private Animator Animator;
    [SerializeField] private IKManager2D IKManager2D;

    [SerializeField] private SpriteRenderer NormalHead;
    [SerializeField] private SpriteRenderer AmazedHead;

    [SerializeField] private Patrol PatrolScript;

    public void SwitchToDynamic()
    {
        foreach (BodyPart bodyPart in BodyParts)
            bodyPart.SwitchToDynamic();

        FlyManager.Fly = true;

        Animator.enabled = false;
        IKManager2D.enabled = false;

        NormalHead.enabled = false;
        AmazedHead.enabled = true;

        PatrolScript.enabled = false;
    }

    public void SwitchToKinematic()
    {
        foreach (BodyPart bodyPart in BodyParts)
            bodyPart.SwitchToKinematic();

        FlyManager.Fly = false;

        Animator.enabled = true;
        Animator.SetTrigger("StandUp");

        IKManager2D.enabled = true;

        NormalHead.enabled = true;
        AmazedHead.enabled = false;

        PatrolScript.enabled = true;
    }
}
