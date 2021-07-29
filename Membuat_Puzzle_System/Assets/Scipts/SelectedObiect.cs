using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectedObiect : MonoBehaviour
{
    public void Drag()
    {
        transform.position = Input.mousePosition;
    }
 
}
