using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
public class CursorPositioner : MonoBehaviour
{
    private GameObject currentTarget;
    private float defaultPosZ;
    private float defaultPosX;
    private float defaultPosY;
    public Image passI;
    public Image bulbI;
    public Image retI;
    public Image equipedRet;
    public Image equipedPass;
    public Image equipedBulb;
    Inventory inventory;
    public bool equipPass;
    public bool equipBulb;
    public bool equipRet;
    public Material passM;
    public Material passA;
    public GameObject uvLight;
    public GameObject whiteboardReveal;
    public Material matGreen;
    public Material matBlue;
    public Material matRed;
    public Material matPink;
    Animator anim;
    ResetScript resScr;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        resScr = GetComponent<ResetScript>();
        equipRet = true;
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        defaultPosZ = transform.localPosition.z;
        defaultPosX = transform.localPosition.x;
        defaultPosY = transform.localPosition.y;
        retI.enabled = true;
        passI.enabled = false;
        bulbI.enabled = false;
        equipedBulb.enabled = false;
        equipedPass.enabled = false;
        equipedRet.enabled = true;
        equipPass = false;
        equipBulb = false;
        equipRet = true;
        uvLight.SetActive(false);
        whiteboardReveal.SetActive(true);

    }
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitTarget;


        if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("AccessCard")))
        {
            hitTarget = hit.collider.gameObject;
            if (hitTarget != currentTarget && equipPass == true)
            {
                Unhighlight();
                Highlight(hitTarget);
            }
            if (Input.GetButtonDown("Fire1") && equipedPass.enabled == true)
            {
                //hasStaffPass = true;
                // Annimation Code
                anim.SetTrigger("cardAccepted");
            }
        }
        else if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("Light")))
        {
            if (Input.GetButtonDown("Fire1") && equipedBulb.enabled == true)
            {
                //hasStaffPass = true;
                // Annimation Code
                uvLight.SetActive(true);
                whiteboardReveal.SetActive(false);
                equipBulb = false;
                bulbI.enabled = false;
                equipedBulb.enabled = false;
                inventory.hasBulb = false;
                equipRet = true;
                retI.enabled = true;
                equipedRet.enabled = true;
                
            }
        }
        else if (currentTarget != null)
        {
            Unhighlight();
        }
    }

    void FixedUpdate()
    {
        if (inventory.hasStaffPass == true && inventory.hasBulb == false)
        {
            if (equipRet == true)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    equipRet = false;
                    equipPass = true;

                    retI.enabled = true;
                    passI.enabled = true;

                    equipedRet.enabled = false;
                    equipedPass.enabled = true;
                }
            }
            else if (equipPass == true)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    equipRet = true;
                    equipPass = false;

                    retI.enabled = true;
                    passI.enabled = false;

                    equipedRet.enabled = true;
                    equipedPass.enabled = false;
                }
            }
        }
        else if (inventory.hasBulb == true && inventory.hasStaffPass == true)
        {
            if (equipRet == true)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    equipRet = false;
                    equipBulb = false;
                    equipPass = true;
                    
                    retI.enabled = true;
                    bulbI.enabled = false;
                    passI.enabled = true;

                    equipedRet.enabled = false;
                    equipedBulb.enabled = false;
                    equipedPass.enabled = true;
                    
                }
            }
            else if (equipPass == true)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    equipRet = false;
                    equipBulb = true;
                    equipPass = false;

                    retI.enabled = true;
                    bulbI.enabled = true;
                    passI.enabled = false;

                    equipedRet.enabled = false;
                    equipedBulb.enabled = true;
                    equipedPass.enabled = false;
                }
            }
            else if (equipBulb == true)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    equipRet = true;
                    equipBulb = false;
                    equipPass = false;

                    retI.enabled = true;
                    bulbI.enabled = false;
                    passI.enabled = false;

                    equipedRet.enabled = true;
                    equipedBulb.enabled = false;
                    equipedPass.enabled = false;
                }
            }
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

        //Rigidbody newSelector = Instantiate(selector, target.transform.position, transform.rotation) as Rigidbody;
        //newSelector.name = "Selector";

        Material material = currentTarget.GetComponent<Renderer>().material = passA;

    }

    private void Unhighlight()
    {
        if (currentTarget != null)
        {
            Material material = currentTarget.GetComponent<Renderer>().material = passM;
            //material.color = saveColor;
            currentTarget = null;

            //target.GetComponent<MeshRenderer>().material = passM;
        }
    }
}