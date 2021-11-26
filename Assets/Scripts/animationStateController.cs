using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{    
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    int isPunchingHash;
    int isRunningHash;
    void Start()
    {
        animator = GetComponent<Animator>();   
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isPunchingHash = Animator.StringToHash("isPunching");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        ProcessWalk();
        ProcessJump();
        ProcessPunch();
        ProcessRun();
    }

    void ProcessWalk()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        float moveZ = Input.GetAxis("Horizontal");

        if(!isWalking && moveZ != 0)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if(isWalking && moveZ == 0)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }

    void ProcessJump()
    {
        bool isJumping = animator.GetBool(isJumpingHash);
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);

        if(!isJumping && spacePressed)
        {
            animator.SetBool(isJumpingHash, true);
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }

    void ProcessPunch()
    {
        bool isPunching = animator.GetBool(isPunchingHash);
        bool clickPressed = Input.GetMouseButtonDown(0);

        if(!isPunching && clickPressed)
        {
            animator.SetBool(isPunchingHash, true);
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isPunchingHash, false);
        }
    }

    void ProcessRun()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        if(isWalking && !isRunning && shiftPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if(isRunning && !shiftPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
