using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 velocity = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //guardar offset para saber distancia inicial entre camara y player
        Vector3 cameraPos = transform.localPosition;
        Vector3 playerPos = player.transform.localPosition;
        offset = cameraPos - playerPos;
    }


    // Update is called once per frame
    void Update()
    {
        LookPlayer();
        ClampCamera();
    }

    //Hace que la camara siga al jugador
    void LookPlayer()
    {
        Vector3 cameraPos = transform.localPosition;
        Vector3 playerPos = player.transform.localPosition;
        
        //smoothdamp -> (vector origen, vector destino, ref vector3 velocidad, tiempo)
        transform.localPosition = Vector3.SmoothDamp(cameraPos, new Vector3(playerPos.x + offset.x, playerPos.y + offset.y, cameraPos.z), ref velocity, 0.0f);
        
    }

    //Marca los limites hasta los que la camara sigue al player
    void ClampCamera()
    {
        Vector3 cameraPos = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(cameraPos.x, -20, 20), Mathf.Clamp(cameraPos.y, -20, 20), cameraPos.z);
    }
}
