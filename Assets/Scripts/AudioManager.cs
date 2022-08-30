using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using DG.Tweening;

/***
 * 整个管理放到这里完成
 * 
 */
public class AudioManager : MonoBehaviour
{

    static AudioManager audioMgr;

  
    public List<AudioClip> myAudioList = new List<AudioClip>();

    public AudioSource myPlayer;

   
    private void Awake()
    {
        audioMgr = this;
    }

    void Start() {

        Application.targetFrameRate = 60;
    }

    public static AudioManager getBattleMgr() {

        if (audioMgr == null) {

            GameObject go = new GameObject(typeof(AudioManager).ToString());    //第一次调用GetInstance时实例化一个U3D的空对象，并挂载单例管理脚本
            DontDestroyOnLoad(go);
            audioMgr = go.AddComponent(typeof(AudioManager)) as AudioManager;

        }

        return audioMgr;
    }

    public void playAudio(int idx) { 
    
        
    }
        
}
