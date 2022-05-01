using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrieYourself
{
    public class MaskPickup : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(0,0,0.1f);
        }

        void OnTriggerEnter(Collider other){
            if(other.tag== "Player"){
                GameObject mask = GameObject.Find("P_Mask_Mouse");
                mask.GetComponent<MeshRenderer>().enabled = true;
                Destroy(this.gameObject);
            }
        }

    }
}
