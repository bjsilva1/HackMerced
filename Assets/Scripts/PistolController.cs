using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolController : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float fireSpeed = 20;
    public Transform modelTransform;
    public GameObject sightLine;

    private XRGrabInteractable grabbable;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
        rb = GetComponent<Rigidbody>();
        sightLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 1)
        {
            sightLine.SetActive(false);
        }
        else if (transform.GetChild(1).gameObject.name.Contains("Left"))
        {
            modelTransform.localEulerAngles = new Vector3(0, 0, -90f);
            rb.useGravity = true;
            sightLine.SetActive(true);
        }
        else if (transform.GetChild(1).gameObject.name.Contains("Right"))
        {
            modelTransform.localEulerAngles = new Vector3(0, 0, 90f);
            rb.useGravity = true;
            sightLine.SetActive(true);
        }
    }

    public void Fire(ActivateEventArgs arg)
    {
        GameObject newBullet = Instantiate(bullet, spawnpoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * fireSpeed;
        Destroy(newBullet, 5);
    }
}
