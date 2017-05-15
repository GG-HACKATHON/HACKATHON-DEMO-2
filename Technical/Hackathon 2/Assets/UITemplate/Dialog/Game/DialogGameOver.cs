using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogGameOver : BaseDialog {

    private AudioSource audioSource;
    public void onClickReplay()
    {
        this.OnCloseDialog();
    }
    public void onClickHome()
    {
        DialogManager.Instance.ShowDialog<DialogGameStart>("Dialog/Portrait/GameStart");
    }

    void GetAudioSource()
    {
        audioSource = this.gameObject.transform.root.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
    }
}
