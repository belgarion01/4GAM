using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HappyFunTimes;

public class ShowInstruction : MonoBehaviour
{
    HFTInstructions intruction;

    private void Start()
    {
        Show(true);
    }

    public void Show(bool flag) {
        GetComponent<HFTInstructions>().show = flag;
    }
}
