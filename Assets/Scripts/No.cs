using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No : MonoBehaviour
{
    public void NetAnimating()
    {
        StartCatScene.IsAnimated = false;
    }
    public void EstAnimating()
    {
        StartCatScene.IsAnimated = true;
    }
}
