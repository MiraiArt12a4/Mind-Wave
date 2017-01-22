﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public static Radio instance;

    private Room currentLocation;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        checkRadio();
    }

    public static void checkRadio()
    {
        if (instance == null) return;

        instance.currentLocation = Floor.GetCurrentFloor().GetTile(instance.transform.localPosition).GetComponentInParent<Room>();
        Floor.GetCurrentFloor().CleanRadioWaves();
        instance.currentLocation.SendRadioWaves();
        Floor.GetCurrentFloor().TempColorRoomTiles();
    }

}
