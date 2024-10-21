using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
    public bool toAdd;
    public bool isQuestion;

    [HideInInspector]
    public bool answer;
    public string text;

    [SerializeField]
    public CloserLook cl;
}
