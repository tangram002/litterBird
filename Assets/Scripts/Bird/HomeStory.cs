using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HomeStory : MonoBehaviour
{

    public Text myText;

    public StoryBird myBird;

    public GameObject storyImage;

    public void OnClick() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

        storyImage.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {

        AudioManager.I().playAudio(1);

        myText.transform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraEnd(float arg) {

        myText.text = " One day,  I go out home to learn flying"; 

        Debug.Log("eeeeeeeeeeeeeeeeeeeeeee");

        storyStart();
    }

    public void storyStart() {

        myBird.fly();

        Vector3 oldPos =  myBird.transform.position;

        myBird.transform.DOMoveY(oldPos.y + 1.5f, 3f).OnComplete(() => {
            
           myBird.transform.DOMoveX(oldPos.x + 2, 3f).OnComplete(() => {

               myText.text = "I suddenly lost my power ...........";

               Invoke("losePower",1.5f);

               ; });
            ;         
        });
        
       
    }

    public void losePower()
    {

        Rigidbody rg = myBird.GetComponent<Rigidbody>();
        rg.useGravity = true;

        Invoke("startBattleGame", 2f);

        AudioManager.I().playEffect(3);
        //startBattleGame();

    }

    public void startBattleGame()
    {

        myText.transform.gameObject.SetActive(false);
        storyImage.SetActive(true);

       
    }


}
