using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private int rMultiplier = 1;
    private int gMultiplier;
    private int bMultiplier = -1;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        gMultiplier = Random.Range(0, 2) == 0 ? -1 : 1;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.0f, Random.Range(0.0f, 1.0f), 1.0f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
        transform.Translate(Vector3.up * Time.deltaTime);
        Material material = Renderer.material;
        Color color = material.color;
        if (color.r >= 1.0f || color.r <= 0.0f)
        {
            rMultiplier *= -1;
        }

        if (color.g >= 1.0f || color.g <= 0.0f)
        {
            gMultiplier *= -1;
        }

        if (color.b >= 1.0f || color.b <= 0.0f)
        {
            bMultiplier *= -1;
        }
        
        color.r += 0.1f * Time.deltaTime * rMultiplier;
        color.b += 0.1f * Time.deltaTime * gMultiplier;
        color.b += 0.1f * Time.deltaTime * bMultiplier;
        material.color = color;
    }
}
