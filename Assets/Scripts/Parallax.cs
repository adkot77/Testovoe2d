using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] parallaxStrengths;
    [SerializeField] protected float paralaxStrength;
    private Transform cameraTransform;
    private Vector3 lastCameraPos;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPos = cameraTransform.position;

     
            parallaxStrengths = new float[layers.Length];
            for (int i = 0; i < layers.Length; i++)
                parallaxStrengths[i] = i*paralaxStrength; // значение по умолчанию
        
    }

    private void FixedUpdate()
    {
        if (layers == null || layers.Length == 0) return;

        Vector3 delta = cameraTransform.position - lastCameraPos;
        for (int i = 0; i < layers.Length; i++)
        {
            if (layers[i] != null)
                layers[i].position += delta * parallaxStrengths[i]*Time.deltaTime;
        }
        lastCameraPos = cameraTransform.position;
    }
}