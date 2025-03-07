using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDeviceManager : MonoBehaviour
{
    public Action PlayerAdded;

    [SerializeField, Header("InputAction")]
    private InputActionAsset playerActionAsset;

    [SerializeField, Header("PlayerData")]
    private int maxPlayerCount;

    private int currentPlayerCount = 0;

    private InputAction JoinAction;

    private List<int> registeredDevicesId = new List<int>();

    private void Awake()
    {
        InputActionMap inputActionMap = playerActionAsset.FindActionMap("Lobby");

        JoinAction = inputActionMap.FindAction("Join");
        JoinAction.performed += OnJoinActionPerformed;
    }

    private void OnJoinActionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("JoinPressed");
        if (registeredDevicesId.Contains(context.control.device.deviceId) == false && currentPlayerCount < maxPlayerCount)  
        {
            currentPlayerCount++;
            registeredDevicesId.Add(context.control.device.deviceId);
            //PlayerAdded.Invoke();
            SaveDeviceList();
        }
    }

    private void PlayerRemoved(int deviceId)
    {
        registeredDevicesId.Remove(registeredDevicesId.IndexOf(deviceId));
    }

    private void SaveDeviceList()
    {
        InputDeviceManagerSaveData deviceManagerData = new InputDeviceManagerSaveData();
        deviceManagerData.RegisteredInputDevicesId = registeredDevicesId;
        SaveSystem.Save("DeviceManager", deviceManagerData);
        Debug.Log(Application.persistentDataPath + "/");
    }

    private void OnEnable()
    {
        JoinAction.Enable();
    }

    private void OnDisable()
    {
        JoinAction.Disable();
    }
}
