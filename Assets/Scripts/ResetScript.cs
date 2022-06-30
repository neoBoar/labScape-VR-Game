using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    private GameObject currentTarget;
    public ParticleSystem pSystem;
    public bool lighting1Correct;
    public bool lighting2Correct;
    public bool lighting3Correct;
    public bool lighting4Correct;
    public GameObject lighting1;
    public GameObject lighting2;
    public GameObject lighting3;
    public GameObject lighting4;
    public Material matGreen;
    public Material matBlue;
    public Material matRed;
    public Material matPink;
    public bool boole;
    //public int count;
    CursorPositioner cursPos;

    // Start is called before the first frame update
    void Awake()
    {
        boole = false;
        cursPos = GetComponent<CursorPositioner>();
        pSystem.GetComponentInChildren<ParticleSystem>().Stop();
        //lighting1 = GetComponent<GameObject>();
        //lighting2 = GetComponent<GameObject>();
        //lighting3 = GetComponent<GameObject>();
        //lighting4 = GetComponent<GameObject>();
    }

    void Update()
    {

        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitTarget;
        if (Physics.Raycast(ray, out hit, 20f, LayerMask.GetMask("Button")))
        {
            int count = 0;
            boole = true;
            hitTarget = hit.collider.gameObject;
            currentTarget = hitTarget;
            //Debug.Log("Text: " + currentTarget.GetComponent<Renderer>().sharedMaterial.name);
            if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.GetComponent<Renderer>().sharedMaterial.name == "red emission")
            {
                Material material = currentTarget.GetComponent<Renderer>().sharedMaterial = matBlue;
            }
            else if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.GetComponent<Renderer>().sharedMaterial.name == "dblue emission")
            {
                Material material = currentTarget.GetComponent<Renderer>().sharedMaterial = matGreen;
            }
            else if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.GetComponent<Renderer>().sharedMaterial.name == "green emission")
            {
                Material material = currentTarget.GetComponent<Renderer>().sharedMaterial = matPink;
            }
            else if (Input.GetButtonDown("Fire1") && currentTarget.gameObject.GetComponent<Renderer>().sharedMaterial.name == "pink emission")
            {
                Material material = currentTarget.GetComponent<Renderer>().sharedMaterial = matRed;
            }

        }
        else if (currentTarget != null)
        {
            boole = false;
        }
    }

        void FixedUpdate()
        {
        if (lighting1.GetComponent<Renderer>().sharedMaterial.name == "dblue emission")
        {
            lighting1Correct = true;
        }
        else
        {
            lighting1Correct = false;
        }
        if (lighting2.GetComponent<Renderer>().sharedMaterial.name == "pink emission")
        {
            lighting2Correct = true;
        }
        else
        {
            lighting2Correct = false;
        }
        if (lighting3.GetComponent<Renderer>().sharedMaterial.name == "red emission")
        {
            lighting3Correct = true;
        }
        else
        {
            lighting3Correct = false;
        }
        if (lighting4.GetComponent<Renderer>().sharedMaterial.name == "green emission")
        {
            lighting4Correct = true;
        }
        else
        {
            lighting4Correct = false;
        }

        if (lighting1Correct == true && lighting2Correct == true && lighting3Correct == true && lighting4Correct == true)
        {
            pSystem.GetComponentInChildren<ParticleSystem>().Play();
            SceneManager.LoadScene("Menu");
            //Debug.Log("Finished");
        }
    }
}
