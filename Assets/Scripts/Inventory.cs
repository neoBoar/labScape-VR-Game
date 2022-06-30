using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private GameObject currentTarget;
    public Rigidbody selector;
    public bool hasStaffPass;
    public bool hasBulb;
    public Image passHUD;
    public Image bulbHUD;
    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitTarget;
        passHUD.enabled = false;
        bulbHUD.enabled = false;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("Collectable")))
            {
                hitTarget = hit.collider.gameObject;
                if (hitTarget != currentTarget)
                {
                    Unhighlight();
                    Highlight(hitTarget);
                }
                if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.CompareTag("Pass"))
                {
                    hasStaffPass = true;
                    Destroy(hitTarget);
                    Unhighlight();
            }
                else if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.CompareTag("Bulb"))
            {
                hasBulb = true;
                Destroy(hitTarget);
                Unhighlight();
            }
        }
            else if (currentTarget != null)
            {
                Unhighlight();
            }
            if(hasStaffPass == true)
            {
                passHUD.enabled = true;
            }
            if(hasBulb == true)
            {
                bulbHUD.enabled = true;
            }
            if (hasStaffPass == false)
            {
                passHUD.enabled = false;
            }
            if (hasBulb == false)
            {
                bulbHUD.enabled = false;
            }
    }

        private void Highlight(GameObject target)
        {
            //Material material = target.GetComponent<Renderer>().material;
            //saveColor = material.color;
            //Color hiColor = material.color;
            //hiColor.r = 100.0f;
            //material.color = hiColor;
            currentTarget = target;

            Rigidbody newSelector = Instantiate(selector, target.transform.position, transform.rotation) as Rigidbody;
            newSelector.name = "Selector";
        
        }

        private void Unhighlight()
        {
            if (currentTarget != null)
            {
                //Material material = currentTarget.GetComponent<Renderer>().material;
                //material.color = saveColor;
                currentTarget = null;

            Destroy(GameObject.Find("Selector"));
            }
        }
}
