using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;



public class SwimArea : MonoBehaviour
{

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

        }

        if (other.CompareTag("MainCamera"))
        {

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int swimAndDiveLayerIndex = animator.GetLayerIndex("Swim And Dive");
            animator.SetLayerWeight(swimAndDiveLayerIndex, 0);

        }

        if (other.CompareTag("MainCamera"))
        {

        }
    }
}