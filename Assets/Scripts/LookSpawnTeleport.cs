using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookSpawnTeleport : MonoBehaviour
{
    private Color saveColor;
    private GameObject currentTarget;
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject upPoint;
    public GameObject downPoint;
    CursorPositioner cursPos;

    void Awake()
    {
        cursPos = GetComponent<CursorPositioner>();
        player.transform.position = new Vector3(spawnPoint.transform.position.x, 4.0f, spawnPoint.transform.position.z);
        //player.transform.rotation = 90;
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitTarget;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("Door")))
        {

        }
        else if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("TeleportSpawn")))
        {
            hitTarget = hit.collider.gameObject;
            if (hitTarget != currentTarget)
            {
                Unhighlight();
                Highlight(hitTarget);
            }
            if (Input.GetButtonDown("Fire1") && cursPos.equipRet == true && hitTarget.CompareTag("GoUpstairs"))
            {
                player.transform.position = new Vector3(upPoint.transform.position.x, 14.0f, upPoint.transform.position.z);
            }
            else if (Input.GetButtonDown("Fire1") && cursPos.equipRet == true && hitTarget.CompareTag("GoDownstairs"))
            {
                transform.position = new Vector3(downPoint.transform.position.x, 4.0f, downPoint.transform.position.z);
            }
            else if (Input.GetButtonDown("Fire1") && cursPos.equipRet == true && hitTarget.CompareTag("UpStairs"))
            {
                transform.position = new Vector3(hitTarget.transform.position.x, 14.0f, hitTarget.transform.position.z);
            }
            else if (Input.GetButtonDown("Fire1") && cursPos.equipRet == true)
            {
                transform.position = new Vector3(hitTarget.transform.position.x, 4.0f, hitTarget.transform.position.z);
            }
        }
        else if (currentTarget != null)
        {
            Unhighlight();
        }

    }

    private void Highlight(GameObject target)
    {
        Material material = target.GetComponent<Renderer>().material;
        saveColor = material.color;
        Color hiColor = material.color;
        hiColor.r = 100.0f;
        material.color = hiColor;
        currentTarget = target;
    }

    private void Unhighlight()
    {
        if(currentTarget != null)
        {
            Material material = currentTarget.GetComponent<Renderer>().material;
            material.color = saveColor;
            currentTarget = null;
        }
    }
}