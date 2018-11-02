using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopopUp : MonoBehaviour {

    public Text TextA;
    public Text TextB;
    public Text TextC;

    public bool FlagA = false;
    public bool FlagB = false;
    public bool FlagC = false;

    public void ButtonA()
    {
        FlagA = true;
    }

    public void ButtonB()
    {
        FlagB = true;
    }

    public void ButtonC()
    {
        FlagC = true;
    }
}
