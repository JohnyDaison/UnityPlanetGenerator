using UnityEngine;

public class Sphere
{
    public Vector3[] normals;
    public Triangle[] triangles;
    public Vector3[] vertices;
    public string name;

    public Sphere(Vector3[] normals, Triangle[] triangles, Vector3[] vertices, string name)
    {
        this.normals = normals;
        this.triangles = triangles;
        this.vertices = vertices;
        this.name = name;
    }

    public Mesh Render()
    {
        int[] triangleIndices = new int[triangles.Length * 3];

        int i = 0;
        foreach (Triangle triangle in triangles)
        {
            triangleIndices[i + 0] = triangle.vertices[0];
            triangleIndices[i + 1] = triangle.vertices[1];
            triangleIndices[i + 2] = triangle.vertices[2];
            i += 3;
        }

        Mesh mesh = new Mesh
        {
            name = name,
            vertices = vertices,
            triangles = triangleIndices,
            normals = normals
        };

        return mesh;
    }
}
