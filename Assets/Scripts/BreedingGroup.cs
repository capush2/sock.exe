using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Afficher();
    }

    public void Afficher()
    {
        List<GameObject> list = GameObject.Find("DickBoy").GetComponent<CameraTest>().SockInventory;
        GameObject current;
        for (int i = 0; i < list.Count; i++)
        {
            current = list[i];
            current.SetActive(true);
            
            GameObject daddy = transform.Find("InventaireSlots").gameObject;
            current.transform.SetParent(daddy.transform);
            current.transform.localScale = new Vector3(1, 1, 1);

            float width = daddy.transform.GetComponent<RectTransform>().rect.width / 2;
            float height = daddy.transform.GetComponent<RectTransform>().rect.height / 2;
            float side = current.transform.GetComponent<RectTransform>().rect.width / 2;
            float hGap = (width - 3 * side) / 3;
            float vGap = (height - 3 * side) / 3;

            current.transform.position = daddy.transform.position;
            current.transform.position += new Vector3((i % 3 + 1) * hGap - side / 2, -(Mathf.FloorToInt(i / 3) + 1/2f) * vGap - side / 2 + side/4, 0);
        }
    }
    public void Effacer()
    {
        GameObject daddy = transform.Find("InventaireSlots").gameObject;
        foreach(var i in daddy.transform)
        {
            Destroy(transform.gameObject);
        }
    }
}
