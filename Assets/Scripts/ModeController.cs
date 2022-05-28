using System;
using UI;
using UnityEngine;
using Event = EventSystem.Event;


// TODO: redo with FSM
public class ModeController : MonoBehaviour
{
    public CameraController cameraController;
    public UIController uiController;
    private bool _simulating;
    private bool _unitEditing;
    private int _unitsLayerMask;
    private RaycastHit _hitInfo;
    
    public Event startSimulation;
    public Event endSimulation;

    public void StartSimulation()
    {
        if (_simulating)
        {
            return;
        }
        _simulating = true;
        Time.timeScale = 1;
        startSimulation.RaiseEvent();
    }
    
    public void EndSimulation()
    {
        if (!_simulating)
        {
            return;
        }
        _simulating = false;
        Time.timeScale = 0;
        endSimulation.RaiseEvent();
    }
    
    public void ExitUnitEditing()
    {
        uiController.DisableUnitUI();
        cameraController.enabled = true;
        _unitEditing = false;
    }
    
    public void EnterUnitEditing()
    {
        uiController.EnableUnitUI(_hitInfo.collider.gameObject.GetComponent<Unit>());
        cameraController.enabled = false;
        _unitEditing = true;
    }
    
    private void Awake()
    {
        _unitsLayerMask = LayerMask.GetMask("Units");
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_unitEditing)
            {
                ExitUnitEditing();
            }
            else
            {
                StartSimulation();
            }
        }
        if (!_simulating && !_unitEditing && Input.GetMouseButtonDown(0))
        {
            var camTransform = cameraController.transform;
            if (Physics.Raycast(new Ray(camTransform.position, camTransform.forward), out _hitInfo, 1000, _unitsLayerMask))
            {
                EnterUnitEditing();
            }
        }
    }
}