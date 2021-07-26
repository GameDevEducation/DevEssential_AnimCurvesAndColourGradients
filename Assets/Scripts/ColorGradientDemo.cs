using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorGradientDemo : MonoBehaviour
{
    [SerializeField] Gradient AlbedoTint;
    [SerializeField] AnimationCurve ColourCurve;
    [SerializeField] float Duration = 5f;

    MaterialPropertyBlock PropertyBlock;
    MeshRenderer LinkedMR;

    float CurrentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LinkedMR = GetComponent<MeshRenderer>();
        PropertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        // update the time
        CurrentTime = Mathf.Repeat(CurrentTime + Time.deltaTime, Duration);

        // retrieve and apply the colour
        var colourProgress = ColourCurve.Evaluate(CurrentTime / Duration);
        var newColour = AlbedoTint.Evaluate(colourProgress);
        PropertyBlock.SetColor("_Color", newColour);
        LinkedMR.SetPropertyBlock(PropertyBlock);
    }
}
