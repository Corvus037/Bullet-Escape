using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{   
    public static ConfigController instance;
   
    public AudioMixer mixer;

    public Slider sldMusic;

    public Slider sldFx;

    public Slider sldTotal;

    public GameObject panel;

    public GameObject Audiopanel;

    public bool showPanel = false;

    public bool isPause;

    void Awake()
    {
        if (instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
          showPanel = !showPanel;
            panel.SetActive(showPanel);
            Audiopanel.SetActive(false);
            SetPause(showPanel);
        }
    }

    public void ChangeMusicVolume(){
        mixer.SetFloat("Music",(sldMusic.value*80 - 80));
    }

    public void ChangeFxVolume(){
        mixer.SetFloat("Fx",(sldFx.value*80 - 80));
    }

    public void ChangeMasterVolume(){
        mixer.SetFloat("Master",(sldTotal.value*80 - 80));
    }

    
    public void SetPause(bool p)
    {
        isPause = p;
        if(isPause){
            Time.timeScale = 0.0f;
        }else{
            Time.timeScale = 1.0f;
        }
    }

    public void Menu(bool s = true)
            {          
            s = !s;
            panel.SetActive(s);
            SetPause(s);
            showPanel = !showPanel;
            }
}
