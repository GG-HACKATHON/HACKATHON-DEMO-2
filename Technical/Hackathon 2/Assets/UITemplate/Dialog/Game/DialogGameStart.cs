using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGameStart : BaseDialog {

    private AudioSource audioSource;
    public AudioSource startAudio;
    
    void Start()
    {
        GetAudioSource();
        audioSource.Stop();
        startAudio.Play();
    }
	public void onClickPlayGame()
    {
        
        audioSource.Play();
        this.OnCloseDialog();
    }
    public void onClickSeting()
    {
        DialogManager.Instance.ShowDialog <DialogGameSeting>("Dialog/Portrait/GameSetting");

    }

    void GetAudioSource()
    {
        audioSource = this.gameObject.transform.root.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
    }
}
