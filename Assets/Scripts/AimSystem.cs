using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Animator _myAnimator;
    private float _fieldOfView;
    [SerializeField] private Camera _mainCamera;
    private string _aimingAnim = "TriggerAim";
    private string _disAimingAnim = "TriggerDisAim";

    private void Awake()
    {
        _myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        _fieldOfView = 60f;
    }

    void Update()
    {
        _mainCamera.fieldOfView = _fieldOfView;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _myAnimator.SetTrigger(_aimingAnim);
            _fieldOfView = 30f;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            _myAnimator.SetTrigger(_disAimingAnim);
            _fieldOfView = 60f;
        }
    }
}
