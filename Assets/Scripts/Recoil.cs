using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private float _horizontalRecoil = -0.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.Translate(new Vector3(0, 0, _horizontalRecoil));
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            transform.Translate(new Vector3(0, 0, -_horizontalRecoil));
        }
            
    }
}
