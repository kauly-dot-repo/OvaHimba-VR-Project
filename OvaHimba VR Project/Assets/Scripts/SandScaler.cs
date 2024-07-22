using UnityEngine;

public class SandScaler : MonoBehaviour
{
    public GameObject sand1;
    public GameObject sand2;
    public GameObject sand3Prefab;

    // private GameObject sand3Prefab;

    void Start()
    {
        sand3Prefab.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.contactCount <= 1 && !sand3Prefab.activeSelf){
            sand3Prefab.SetActive(true);
            float newScale = collision.gameObject.transform.localScale.x - 0.05f;
            collision.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        } else {

        }
        // if (
        //     (collision.gameObject == sand1 || collision.gameObject == sand2)
        //     && !sand3Prefab.activeSelf
        // )
        // {
        //     // Reduce scale of collided sand
        //     float newScale = collision.gameObject.transform.localScale.x - 0.1f;
        //     collision.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

        //     // Spawn sand3Prefab on shovel
        //     sand3Prefab.SetActive(true);
        // }
        // else if (collision.gameObject == sand1 || collision.gameObject == sand2)
        // {
        //     // Increase scale of collided sand
        //     float newScale = collision.gameObject.transform.localScale.x + 0.1f;
        //     collision.gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

        //     // Destroy sand3Prefab
        //     Destroy(sand3Prefab);
        // }
    }
}
