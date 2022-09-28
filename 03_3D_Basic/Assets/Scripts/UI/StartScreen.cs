using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Close();
        GameManager.Inst.GameStart();
    
    }

    void Update()
    {    // 현재 키보드에서 어느키든 이프레임에 눌러졌을때 true 다.
        if (Keyboard.current.anyKey.wasPressedThisFrame) 
        {
            Close();
            GameManager.Inst.GameStart();
        }
      
    }

    void Close() 
    {
        this.gameObject.SetActive(false);
    
    }

}
