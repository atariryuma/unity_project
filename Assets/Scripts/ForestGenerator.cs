using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public int treeCount = 50;
    public float areaSize = 50f;
    public Material trunkMaterial;
    public Material leavesMaterial;

    void Start()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-areaSize * 0.5f, areaSize * 0.5f),
                0f,
                Random.Range(-areaSize * 0.5f, areaSize * 0.5f)
            );
            CreateTree(position);
        }
    }

    void CreateTree(Vector3 position)
    {
        GameObject tree = new GameObject("Tree");

        GameObject trunk = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        trunk.transform.SetParent(tree.transform);
        trunk.transform.localPosition = new Vector3(0f, 1f, 0f);
        trunk.transform.localScale = new Vector3(0.2f, 1f, 0.2f);
        if (trunkMaterial != null)
        {
            Renderer rend = trunk.GetComponent<Renderer>();
            rend.material = trunkMaterial;
        }

        GameObject leaves = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leaves.transform.SetParent(tree.transform);
        leaves.transform.localPosition = new Vector3(0f, 2f, 0f);
        leaves.transform.localScale = Vector3.one;
        if (leavesMaterial != null)
        {
            Renderer rend = leaves.GetComponent<Renderer>();
            rend.material = leavesMaterial;
        }

        tree.transform.position = position;
    }
}
