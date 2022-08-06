using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField] KeyCode toggleKey = KeyCode.I;
    [SerializeField] GameObject uiContainer;
    
    void Start()
    {
        uiContainer.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            uiContainer.SetActive(!uiContainer.activeSelf);
        }
    }
}
