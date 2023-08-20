using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public Rigidbody Vehicle;
    public TextMeshProUGUI SpeedUi;

    // Update is called once per frame
    void Update()
    {
        SpeedUi.text = ((int)Vehicle.velocity.magnitude).ToString();
    }
}
