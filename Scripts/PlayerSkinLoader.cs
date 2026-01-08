using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSkinLoader : MonoBehaviour
{
    [Header("Skin Materials")]
    public Material defaultMat; // Skin 0
    public Material redMat;     // Skin 1
    public Material blueMat;    // Skin 2

    void Start()
    {
        // 1. Read the "Letter" from the Shop (Get the ID)
        int skinID = PlayerPrefs.GetInt("SelectedSkin", 0);

        // 2. Get the Player's Renderer (The thing that shows color)
        MeshRenderer playerRenderer = GetComponent<MeshRenderer>();

        // 3. Pick the right material based on the ID
        if (skinID == 1)
        {
            playerRenderer.material = redMat;
        }
        else if (skinID == 2)
        {
            playerRenderer.material = blueMat;
        }
        else
        {
            // Default (0) or anything else
            playerRenderer.material = defaultMat;
        }
    }
}
