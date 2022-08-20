using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBird : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fly() {

        animator.SetInteger("animation", 14);
    }

    public void flyLeft() {

        animator.SetInteger("animation", 15);
    }

    public void flyRight() {

        animator.SetInteger("animation", 16);
    }
}
