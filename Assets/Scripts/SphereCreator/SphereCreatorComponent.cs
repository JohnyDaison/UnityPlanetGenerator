using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SphereCreatorComponent : MonoBehaviour
{
    public int divisions = 0;
    public float radius = 1f;

    private void Awake () {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Sphere sphere = SphereCreator.Create(divisions, radius, "World");
        meshFilter.mesh = sphere.Render();
    }
}
