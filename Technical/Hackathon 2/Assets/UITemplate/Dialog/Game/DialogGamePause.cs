using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGamePause : BaseDialog {

    private AudioSource audioSource;

    void Start()
    {
        GetAudioSource();
        audioSource.Pause();
    }
    public void onClickResume()
    {
        audioSource.Play();
        this.OnCloseDialog();
    }
    public void onClickExit()
    {
        DialogManager.Instance.ShowMessageBox("Bạn có muốn thoát không?", MESSAGETYPE.YES_NO, () => this.onExit());
    }
    void onExit()
    {
        DialogManager.Instance.ShowDialog<DialogGameStart>("Dialog/Portrait/GameStart");
        this.OnCloseDialog();
        
    }
    void GetAudioSource()
    {
        audioSource = this.gameObject.transform.root.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
    }
}
