using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator ani;
    private bool crouching = false;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
            ani.SetTrigger("dodge");
        }
    }
}
