using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField] private GameObject trashSP;
    [SerializeField] private GameObject trashSP2;
    [SerializeField] private GameObject trashSP3;
    [SerializeField] private GameObject trashSP4;
    [SerializeField] private GameObject trashSP5;
    [SerializeField] private GameObject trashSP6;

    [SerializeField] private GameObject trashPrefab;

    private void Start()  //DELETE OLD TRASH CANS UPON SLEEPING
    {
        spawnalltrash();
    }
    public void spawnalltrash()
    {
        var clones = GameObject.FindGameObjectsWithTag("Garbage");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        GameObject Trash = Instantiate(trashPrefab, trashSP.transform.position, Quaternion.identity);
        GameObject Trash1 = Instantiate(trashPrefab, trashSP2.transform.position, Quaternion.identity);
        GameObject Trash2 = Instantiate(trashPrefab, trashSP3.transform.position, Quaternion.identity);
        GameObject Trash3 = Instantiate(trashPrefab, trashSP4.transform.position, Quaternion.identity);
        GameObject Trash4 = Instantiate(trashPrefab, trashSP5.transform.position, Quaternion.identity);
        GameObject Trash5 = Instantiate(trashPrefab, trashSP6.transform.position, Quaternion.identity);

        Trash.tag = "Garbage";
        Trash1.tag = "Garbage";
        Trash2.tag = "Garbage";
        Trash3.tag = "Garbage";
        Trash4.tag = "Garbage";
        Trash5.tag = "Garbage";
    }

}
