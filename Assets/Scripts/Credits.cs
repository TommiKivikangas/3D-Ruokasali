using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Canvas credits;
    void Start()
    {
        credits.enabled = false;
    }

    public void ShowCredits()
    {
        credits.enabled = true;
    }
    public void HideCredits()
    {
        credits.enabled = false;
    }
}
