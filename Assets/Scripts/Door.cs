using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public GameObject inText;
    public bool inReach = false;
    private bool isNearDoor = false;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            //inReach = true;
            isNearDoor = true;
            inText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            //inReach = false;
            isNearDoor = false;
            inText.SetActive(false);
        }
    }

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            inReach = !inReach;
            animator.SetBool("open", inReach);
        }
    }

}
