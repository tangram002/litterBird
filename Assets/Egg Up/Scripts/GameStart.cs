using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Suriyun;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update

    public BirdSelectStory[] birds;

    void Start()
    {
        AudioManager.I().playAudio(0);
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                foreach (var birdd in birds) {

                    if(birdd!=null)
                        birdd.slient();
                }
                                
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject != null)
                {
                    BirdSelectStory c = hit.collider.gameObject.GetComponent<BirdSelectStory>();

                    if(c!=null)
                        c.ByTouch();
                }


            }
            
        }

    }

    public void startGame() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Cinema");

    }
}
