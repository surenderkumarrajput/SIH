using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New Question",menuName ="Quiz/Questions")]
public class Questions :ScriptableObject
{
    [TextArea]
    public string questions;
    public string[] answers;
    public Sprite image;
    public int rightanswer;
}
