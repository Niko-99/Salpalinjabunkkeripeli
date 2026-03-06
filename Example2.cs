using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Example2 : MonoBehaviour
{
    public float nopeus;

    public InputActionReference MoveReference = null;
    // Start is called before the first frame update
    void Awake()
    {
        MoveReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        MoveReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        this.transform.Translate(Vector3.forward * nopeus * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

