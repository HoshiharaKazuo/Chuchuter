using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{


    [SerializeField]
    private Button _button;

    private void Start()
    {
        EventManager.OnMenuButtonPressedEvent += MenuButtonPressedListener;
    }

    private void OnDestroy()
    {
        EventManager.OnMenuButtonPressedEvent -= MenuButtonPressedListener;
    }
    private void MenuButtonPressedListener()
    {
        StartCoroutine(DisableButtonDelay());
    }

    public void MenuButtonPressedTrigger()
    {
        EventManager.OnMenuButtonPressedTrigger();
    }

    private IEnumerator DisableButtonDelay()
    {
        _button.interactable = false;
        yield return new WaitForSeconds(.2f);
        _button.interactable = true;
    }


}
