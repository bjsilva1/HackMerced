using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(ActivateEventArgs arg)
    {
        GameObject newBullet = Instantiate(bullet, spawnpoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * fireSpeed;
        Destroy(newBullet, 5);

    }
}
