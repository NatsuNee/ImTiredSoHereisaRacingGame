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
        Instantiate(trashPrefab, trashSP.transform.position, Quaternion.identity);
        Instantiate(trashPrefab, trashSP2.transform.position, Quaternion.identity);
        Instantiate(trashPrefab, trashSP3.transform.position, Quaternion.identity);
        Instantiate(trashPrefab, trashSP4.transform.position, Quaternion.identity);
        Instantiate(trashPrefab, trashSP5.transform.position, Quaternion.identity);
        Instantiate(trashPrefab, trashSP6.transform.position, Quaternion.identity);
    }

}
