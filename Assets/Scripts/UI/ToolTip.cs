using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI header_;

    public TextMeshProUGUI content_;

    public LayoutElement layout_;

    public int character_wrap_limit;

    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
        {
            header_.gameObject.SetActive(false);
        }
        else
        {
            header_.gameObject.SetActive(true);
            header_.text = header;
        }

        content_.text = content;

        int header_length = header_.text.Length;
        int content_length = content_.text.Length;

        layout_.enabled = (header_length > character_wrap_limit || content_length > character_wrap_limit) ? true : false;
    }

    private void Update()
    {
        Vector2 pos = Input.mousePosition;

        float offset_x = 55;
        float offset_y = -35;

        Vector2 offset = new Vector2(offset_x, offset_y);

        transform.position = pos + offset;
    }
}
