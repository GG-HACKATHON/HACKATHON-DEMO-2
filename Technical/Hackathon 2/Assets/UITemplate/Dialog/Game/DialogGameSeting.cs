using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGameSeting : BaseDialog {

    private AudioSource audioSource;
    public Slider sliderSound;
    public Slider sliderMusic;
    


    void Start()
    {

    }
    public void onChangeSound()
    {
    }

     
    public void onChangeMusic()
    {

    }
    public void onClickOk()
    {

        this.OnCloseDialog();
    }

    void GetAudioSource()
    {
        audioSource = this.gameObject.transform.root.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
    }
}
