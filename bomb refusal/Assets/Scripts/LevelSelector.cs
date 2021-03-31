using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public ChangeScene sean;
    public string level;

    public void LevelSelected()
    {
        sean.Next = level;
        sean.Outie();
    }
}
