using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public Camera fps;

    private bool isScoped = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);
            if (isScoped)
            {
                scopeOverlay.SetActive(true);
                fps.cullingMask = fps.cullingMask & ~(1 << 11);
            }
            else
            {
                scopeOverlay.SetActive(false);
                fps.cullingMask = fps.cullingMask | (1 << 11);
            }
        }
    }
}
