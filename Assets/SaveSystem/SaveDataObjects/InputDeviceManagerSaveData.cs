using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputDeviceManagerSaveData : ISaveData
{
    public List<int> RegisteredInputDevicesId = new List<int>();
}
