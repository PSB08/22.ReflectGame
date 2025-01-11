using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isOpend;

    private void Start()
    {
        panel.SetActive(false);
        isOpend = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpend == false)
            {
                panel.SetActive(true);
                isOpend = true;
            }
            else if (isOpend == true)
            {
                panel.SetActive(false);
                isOpend = false;
            }
        }
        
    }

}
