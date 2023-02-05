using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEditor;
using static UnityEngine.Rendering.DebugUI;

public class Dissolve : MonoBehaviour
{
    private Shader _shader;
    public float myValue = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shader.SetGlobalFloat("_Cutoff_Height", 0);


        }
    }
}
