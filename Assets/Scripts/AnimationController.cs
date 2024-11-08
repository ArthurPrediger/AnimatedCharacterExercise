using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator ani;
    private bool crouching = false;
    private bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var aniState = ani.GetCurrentAnimatorStateInfo(0);

        if (!walking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ani.SetTrigger("backFlip");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                crouching = !crouching;
                ani.SetBool("crouching", crouching);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                ani.SetTrigger("jumpOver");
            }

            if (aniState.IsName("JumpOver") && aniState.normalizedTime < 0.95f)
            {
                transform.position += 3f * Time.deltaTime * transform.forward;
            }
        }

        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            moveDir.z += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            moveDir.z -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDir.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDir.x -= 1;

        walking = false;
        if(moveDir.sqrMagnitude > 0.0001f && !crouching && !aniState.IsName("JumpOver") && !aniState.IsName("Backflip"))
        {
            moveDir.Normalize();
            transform.forward = moveDir;
            transform.position += 2f * Time.deltaTime * moveDir;
            walking = true;
        }

        ani.SetBool("walking", walking);
    }
}
