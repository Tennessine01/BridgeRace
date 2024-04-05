using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NguyenSpace;


public class MaterialManager : Singleton<MaterialManager>
{
    public List<Material> materials;

    public void SetMaterialByColor(GameObject obj, ColorType color)
    {
        // Check if enum's index are in list materials of not
        if ((int)color > 0 && (int)color <= materials.Count)
        { 
            // Set material by correspond color
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[(int)color - 1]; 
            }
           
        }
    }
}
