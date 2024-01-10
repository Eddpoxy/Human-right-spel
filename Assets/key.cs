using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    movement movement;
    // Start is called before the first frame update
    void Start()
    {
        ChangeObjectTransparency(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.key == true)
        {
            ChangeObjectTransparency(1);
        }
    
    }
    void ChangeObjectTransparency(float alpha)
    {
        // Ensure there is a renderer component attached to the object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Get the current material of the object
            Material material = renderer.material;

            // Change the shader to one that supports transparency
            material.shader = Shader.Find("Standard");

            // Set the rendering mode to transparent
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

            // Set the alpha component to the desired transparency level
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
        else
        {
            Debug.LogError("No renderer component found on the object.");
        }
    }
}
