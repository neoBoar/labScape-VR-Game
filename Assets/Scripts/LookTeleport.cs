using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTeleport : MonoBehaviour
{
    public GameObject target;
    public GameObject ground;

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            target.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            target.SetActive(false);
            transform.position = target.transform.position;
        }
        else if (target.activeSelf)
        {
            ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            if (Physics.Raycast(ray,out hit) && (hit.collider.gameObject != ground))
            {
                target.transform.position = hit.point;
            }
            else
            {
                target.transform.position = transform.position;
            }

        }
    }
}
