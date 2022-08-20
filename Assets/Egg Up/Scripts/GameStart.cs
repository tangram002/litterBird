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

    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            ////Debug.Log("dddddddddddddddddddddddd");

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                foreach (var birdd in birds) {

                    birdd.slient();
                }

                // Debug.Log("碰到对象：" + hit.collider.name + " ta的位置：" + hit.point);
                ///Debug.DrawLine(ray.origin, hit.point, Color.red);//将射线绘制出来 射线显示红色
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
