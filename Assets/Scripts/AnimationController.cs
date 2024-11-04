using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator ani;
    private bool crouching = false;

    public Transform rootBone;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        ani= GetComponent<Animator>();

        initialPosition = rootBone.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("backFlip");  
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            crouching = !crouching;
            ani.SetBool("crouching", crouching);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            ani.SetTrigger("dodge");
        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
        { 
            // Calculate the relative position change
            Vector3 deltaPosition = rootBone.position - initialPosition; 
            // Move the character to the new position
            transform.position += deltaPosition;
            // Update initial position for the next frame
            initialPosition = rootBone.position; }
        }
}
