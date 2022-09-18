using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MeshRenderer _meshRenderer;
    private float _xScroll;
    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        _xScroll = Time.time * _speed;
        var offset = new Vector2(_xScroll, 0);
        _meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
