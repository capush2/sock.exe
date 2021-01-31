using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingGroup : MonoBehaviour
{
    [SerializeField] private GameObject prefabPicture = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        Afficher(GameObject.Find("DickBoy").GetComponent<CameraTest>().SockInventory);
    }

    void Afficher(List<GameObject> list)
    {
        GameObject current;
        for (int i = 0; i < list.Count; i++)
        {
            current = Instantiate(prefabPicture);
            GameObject daddy = transform.Find("InventaireSlots").gameObject;
            current.transform.parent = daddy.transform;
            current.transform.localScale = new Vector3(1, 1, 1);

            float width = daddy.transform.GetComponent<RectTransform>().rect.width / 2;
            float height = daddy.transform.GetComponent<RectTransform>().rect.height / 2;
            float side = current.transform.GetComponent<RectTransform>().rect.width / 2;
            float hGap = (width - 3 * side) / 2;
            float vGap = (height - 3 * side) / 2;

            current.transform.position = daddy.transform.position;
            current.transform.position += new Vector3((i % 3 + 1) * hGap - side / 2 - side / 4, -(Mathf.FloorToInt(i / 3) + 1 / 2f) * vGap - side / 2 + side / 4, 0);
        }
    }
}
