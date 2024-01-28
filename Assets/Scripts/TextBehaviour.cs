using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private TextMeshProUGUI text;

    private float timer = 0f;
    FootBehavior foot;


    private void Start()
    {
        Invoke("clearText", maxTime);
        foot = transform.parent.GetComponent<FootBehavior>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && foot.isTickable())
        {
            text.text = "Tickle! Tickle!";
            Invoke("clearText", maxTime);
        }
    }

    void clearText()
    {
        text.text = "";
    }

}
