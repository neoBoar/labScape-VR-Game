using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRetScript : MonoBehaviour
{
    private GameObject currentTarget;
    CursorPositioner cursPos;
    // Start is called before the first frame update

    void Awake()
    {
        cursPos = GetComponent<CursorPositioner>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitTarget;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
    }
}
