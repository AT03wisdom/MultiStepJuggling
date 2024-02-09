using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
   {
 
        // プレイヤーは初期位置にワープさせる
        // それ以外のオブジェクトは破壊する
        if(other.CompareTag("Player"))
        {
            PlayerMotionScript player = other.gameObject.GetComponent<PlayerMotionScript>();
            player.Respawn(); 
        }
        else
        {
            Destroy(other.gameObject);
        }
   }
}
