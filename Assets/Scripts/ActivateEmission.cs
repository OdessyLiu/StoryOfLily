using UnityEngine;

public class ActivateEmission : MonoBehaviour
{
    private Material marsMaterial;

    void Start()
    {
        // Initialize the marsMaterial by getting the Renderer component's material
        // Assuming Mars uses a Renderer component with a material that supports emission.
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            marsMaterial = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer component not found on the GameObject.");
        }
    }

    // Public method to activate emission, which can be called by Fungus using CallMethod
    public void ActivateEmissionIntensity()
    {
        if (marsMaterial != null)
        {
            // Enable the emission keyword and set the emission color.
            // You can adjust the color and intensity to fit your needs.
            marsMaterial.EnableKeyword("_EMISSION");
            marsMaterial.SetColor("_EmissionColor", Color.white * Mathf.LinearToGammaSpace(1f));
            
            // For dynamic lighting to recognize the emission at runtime
            DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.red * 1f);
        }
        else
        {
            Debug.LogError("Material not found on the GameObject.");
        }
    }
}
