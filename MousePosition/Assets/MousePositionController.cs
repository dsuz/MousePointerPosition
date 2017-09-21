using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePositionController : MonoBehaviour {
    /// <summary>2Dの座標を表示するテキスト</summary>
    [SerializeField]
    private Text m_positionText2d;

    /// <summary>3Dの座標を表示するテキスト</summary>
    [SerializeField]
    private Text m_positionText3d;

    /// <summary>3D座標について、カメラからどれくらい離れるかを指定する。これが0であると3D座標は常にカメラのある座標になってしまう</summary>
    [SerializeField]
    private float m_zAxisOffset = 10f;

    /// <summary>右クリックで動かせる2Dオブジェクト(UI)</summary>
    [SerializeField]
    private RectTransform m_2dObject;

    /// <summary>左クリックで動かせる3Dオブジェクト(GameObject)</summary>
    [SerializeField]
    private GameObject m_3dObject;

    void Start () {
        /*  テキストを初期化する  */
        m_positionText2d.text = "";
        m_positionText3d.text = "";
    }
	
	void Update () {
        // マウスポインターの座標を取得する
        Vector3 position = Input.mousePosition;
        m_positionText2d.text = position.ToString();

        // マウスポインターの座標を空間の座標に変換する
        Vector3 position3d = position;
        position3d.z = m_zAxisOffset;
        position3d = Camera.main.ScreenToWorldPoint(position3d);
        m_positionText3d.text = position3d.ToString();

        /*  左右のクリックで設定されたオブジェクトをその場所に移動する   */
        if (Input.GetMouseButton(0))
            if (m_3dObject) m_3dObject.transform.position = position3d;

        if (Input.GetMouseButton(1))
            if (m_2dObject) m_2dObject.position = position;
    }
}
