using System.Collections.Generic;
using UnityEngine;

public class SphereCreator
{
    private static List<Vector3> vertices;
    private static List<Triangle> triangles;

    public static Sphere Create(int divisions, float radius, string name)
    {
        float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        // Initial Vertices and Triangles of Icosahedron
        vertices = new List<Vector3>
        {
            new Vector3(-1, t, 0).normalized,
            new Vector3(1, t, 0).normalized,
            new Vector3(-1, -t, 0).normalized,
            new Vector3(1, -t, 0).normalized,
            new Vector3(0, -1, t).normalized,
            new Vector3(0, 1, t).normalized,
            new Vector3(0, -1, -t).normalized,
            new Vector3(0, 1, -t).normalized,
            new Vector3(t, 0, -1).normalized,
            new Vector3(t, 0, 1).normalized,
            new Vector3(-t, 0, -1).normalized,
            new Vector3(-t, 0, 1).normalized
        };
        triangles = new List<Triangle>
        {
            new Triangle(0, 11, 5),
            new Triangle(0, 1, 7),
            new Triangle(0, 5, 1),
            new Triangle(0, 7, 10),
            new Triangle(0, 10, 11),
            new Triangle(1, 5, 9),
            new Triangle(5, 11, 4),
            new Triangle(11, 10, 2),
            new Triangle(10, 7, 6),
            new Triangle(7, 1, 8),
            new Triangle(3, 9, 4),
            new Triangle(3, 4, 2),
            new Triangle(3, 2, 6),
            new Triangle(3, 6, 8),
            new Triangle(3, 8, 9),
            new Triangle(4, 9, 5),
            new Triangle(2, 4, 11),
            new Triangle(6, 2, 10),
            new Triangle(8, 6, 7),
            new Triangle(9, 8, 1)
        };

        // Divide faces
        var midPointCache = new Dictionary<int, int>();
        for (int d = 0; d < divisions; d++)
        {
            var newTriangles = new List<Triangle>();
            foreach (Triangle triangle in triangles)
            {
                int a = triangle.vertices[0];
                int b = triangle.vertices[1];
                int c = triangle.vertices[2];

                int ab = GetMidPointIndex(midPointCache, a, b, vertices);
                int bc = GetMidPointIndex(midPointCache, b, c, vertices);
                int ca = GetMidPointIndex(midPointCache, c, a, vertices);

                newTriangles.Add(new Triangle(a, ab, ca));
                newTriangles.Add(new Triangle(b, bc, ab));
                newTriangles.Add(new Triangle(c, ca, bc));
                newTriangles.Add(new Triangle(ab, bc, ca));
            }
            triangles = newTriangles;
        }

        // Create Normals and adjust vertices by radius
        Vector3[] normals = new Vector3[vertices.Count];
        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] = vertices[i].normalized * radius; // Adjust vertex by radius
            normals[i] = vertices[i].normalized;
        }

        Sphere sphere = new Sphere(normals, triangles.ToArray(), vertices.ToArray(), name);
        return sphere;
    }

    private static int GetMidPointIndex(Dictionary<int, int> cache, int indexA, int indexB, List<Vector3> vertices)
    {
        int smallerIndex = Mathf.Min(indexA, indexB);
        int greaterIndex = Mathf.Max(indexA, indexB);
        int key = (smallerIndex << 16) + greaterIndex;

        if (cache.TryGetValue(key, out int ret))
            return ret;

        Vector3 p1 = vertices[indexA];
        Vector3 p2 = vertices[indexB];
        Vector3 middle = Vector3.Lerp(p1, p2, 0.5f).normalized;

        ret = vertices.Count;
        vertices.Add(middle);

        cache.Add(key, ret);
        return ret;
    }
}