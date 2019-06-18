using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField]
    CustomRenderTexture texture;

    void Start()
    {
        texture.Initialize();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedGameObject = hit.collider.gameObject;
                Vector3 localHitPos = clickedGameObject.transform.InverseTransformPoint(hit.point);
                BoxCollider box = clickedGameObject.GetComponent<BoxCollider>();
                float local_x = localHitPos.x / box.bounds.size.x + 0.5f;// 正規化されたローカル空間でのクリックした位置
                float local_z = localHitPos.z / box.bounds.size.z + 0.5f;// [0.0, 1.0]

                const float SIZE = 3.0f;// デカールのワールド空間での大きさ
                float tex_scale = box.bounds.size.x / SIZE;// テクスチャ空間での大きさ(の逆数)

                texture.material.SetFloat("_TexScale", tex_scale);
                texture.material.SetFloat("_OffsetX", 1.0f - local_x);// UVとローカル座標が反対だったので補正
                texture.material.SetFloat("_OffsetZ", 1.0f - local_z);
                texture.Update();

                Debug.Log(local_x + " " + local_z + " " + tex_scale);
            }
        }

    }
}
