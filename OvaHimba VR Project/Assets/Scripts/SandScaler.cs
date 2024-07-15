using UnityEngine;

public class SandScaler : MonoBehaviour
{
    public GameObject sand1;
    public GameObject sand2;
    public GameObject sand3Prefab;
    private GameObject sand3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == sand1 || collision.gameObject == sand2)
        {
            // Reduce scale of collided sand
            float newScale = collision.gameObject.transform.localScale.x - 0.1f;
            collision.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

            // Spawn sand3 on shovel
            sand3 = Instantiate(sand3Prefab, transform.position, transform.rotation);
            sand3.transform.parent = transform; // Make sand3 child of shovel
        }
        else if (collision.gameObject == sand1 || collision.gameObject == sand2)
        {
            if (sand3 != null)
            {
                // Increase scale of collided sand
                float newScale = collision.gameObject.transform.localScale.x + 0.1f;
                collision.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

                // Destroy sand3
                Destroy(sand3);
            }
        }
    }
}
