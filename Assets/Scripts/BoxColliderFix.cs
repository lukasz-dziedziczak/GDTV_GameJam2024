using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderFix : MonoBehaviour
{
    private void Start()
    {
        BoxCollider[] boxColliders = FindObjectsByType<BoxCollider>(FindObjectsSortMode.None);
        List<GameObject> toFix = new List<GameObject>();

        //List<GameObject> Villa2_Door_As = new List<GameObject>();

        int count = 0;
        foreach (BoxCollider boxCollider in boxColliders)
        {
            //if (boxCollider.gameObject.name != "Villa2_Door_A") continue;

            if (boxCollider.transform.localScale.x <= 0 ||
                boxCollider.transform.localScale.y <= 0 ||
                boxCollider.transform.localScale.z <= 0)
            {
                //Villa2_Door_As.Add(boxCollider.gameObject);
                count++;
            }

        }
        print(count + " broken objects");

        /*foreach(GameObject Villa2_Door_A in Villa2_Door_As)
        {
            Vector3 scale = Villa2_Door_A.transform.localScale;

            if (scale.x <= 0) scale.x *= -1;
            if (scale.y <= 0) scale.y *= -1;
            if (scale.z <= 0) scale.z *= -1;
            Villa2_Door_A.transform.localScale = scale;

            Villa2_Door_A.transform.localEulerAngles = new Vector3(
                Villa2_Door_A.transform.localEulerAngles.x,
                Villa2_Door_A.transform.localEulerAngles.y + 180,
                Villa2_Door_A.transform.localEulerAngles.z);
        }*/
    }
}
