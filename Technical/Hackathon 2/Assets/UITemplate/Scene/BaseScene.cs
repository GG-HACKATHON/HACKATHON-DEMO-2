using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Transform panelPopup;
    public int index;
    private object data;

    void Start()
    {
        DialogManager.Instance.ShowDialog<DialogGameStart>("Dialog/Portrait/GameStart");
    }

    public virtual void OnShow(object data)
    {
        this.data = data;
    }
    public virtual void OnHide()
    { }
    public virtual void NextScene()
    { }
    public virtual void PrevScene()
    { }
    public virtual void Init()
    { }

    public void onClickPause()
    {
        DialogManager.Instance.ShowDialog<DialogGamePause>("Dialog/Portrait/GamePause");
    }

}
