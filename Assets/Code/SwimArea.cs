using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Invector.vCharacterController;

public class SwimArea : MonoBehaviour
{
    public vThirdPersonController vThird;
    public Transform cameraTransform;
    public Animator animator;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int swimAndDiveLayerIndex = animator.GetLayerIndex("Swim And Dive");
            animator.SetLayerWeight(swimAndDiveLayerIndex, 1);
            other.GetComponent<vThirdPersonController>().isSwimming = true;
        }

        if (other.CompareTag("MainCamera"))
        {
            other.GetComponentInParent<vThirdPersonController>().isUnderWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int swimAndDiveLayerIndex = animator.GetLayerIndex("Swim And Dive");
            animator.SetLayerWeight(swimAndDiveLayerIndex, 0);
            other.GetComponent<vThirdPersonController>().isSwimming = false;
        }

        if (other.CompareTag("MainCamera"))
        {
            other.GetComponentInParent<vThirdPersonController>().isUnderWater = false;
        }
    }
}