using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdSelectStory : MonoBehaviour
{

    public Canvas myUI;

    public int storyNum;
    public Animator animator;

    bool isAction = false;

    public int myAction = 0;
    public int myTouchAction = 0;

    // Start is called before the first frame update
    void Start()
    {
        /***
        switch (storyNum) { 
        
            case 0:
                myAction =1;
                animator.SetInteger("animation",1);
                break;
            case 1:
                myAction = 2;
                animator.SetInteger("animation", 2);
                break;
            case 2:
                myAction = 3;
                animator.SetInteger("animation", 3);
                break;
            
        }
        */
        animator.SetInteger("animation", myAction);
    }

    public void slient() { 
        
        myUI.gameObject.SetActive(false);
        animator.SetInteger("animation", myAction);
    }

    public void showStory() {

        myUI.gameObject.SetActive(true);

        Vector3 oldSCale = myUI.transform.localScale;

        Vector3 newSCale = Vector3.zero;

        myUI.transform.localScale = newSCale;

        myUI.transform.DOScale(oldSCale,0.5f);
    }
    public void ByTouch()
    {

        if (!isAction)
        {           
            AudioManager.I().playEffect(4);

            animator.SetInteger("animation", myTouchAction);

            isAction = true;

            Invoke("reCoverAnimation", 1f);
        }
    }

    void reCoverAnimation()
    {
        animator.SetInteger("animation", myAction);

        isAction = false;

        BirdSelectStory bs = gameObject.GetComponent<BirdSelectStory>();

        bs.showStory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
