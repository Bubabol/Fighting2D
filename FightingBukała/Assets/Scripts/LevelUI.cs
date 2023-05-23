using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshPro AnnouncerTextLine1;
    public TextMeshPro AnnouncerTextLine2;
    public TextAlignment LevelTimer;

    public SliderJoint2D[] healthSliders;

    public GameObject[] winIndicatorGrids;
    public GameObject winIndicator;

    public static LevelUI Instance;
    public static LevelUI GetInstance()
    {
        return Instance;
    }

    private void Awake()
    {
        Instance = this;
    }
    public void AddWinIndicator(int player)
    {
        GameObject go = Instantiate(winIndicator, transform.position, Quaternion.identity) as GameObject;
        go.transform.SetParent(winIndicatorGrids[player].transform);

    }
}