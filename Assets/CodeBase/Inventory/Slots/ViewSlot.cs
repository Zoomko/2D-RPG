using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Assets.CodeBase.Inventory
{
    [RequireComponent(typeof(Image))]
    public class ViewSlot : MonoBehaviour, IPointerClickHandler
    {
        public event Action<int, Vector2> Clicked;

        private int _id;
        private int _count;   
        private Image _spriteRenderer;
        private TextMeshProUGUI _textMesh;

        private Color _filledColor = new Color(1f,1f,1f,1f);
        private Color _emptyColor = new Color(1f,1f,1f,0f);

        public int Id  => _id;
        public int Count => _count;

        private void Awake()
        {
            _spriteRenderer = GetComponent<Image>();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();           
        }

        public void SetSlot(int id, int count, Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
            if (id == 0)
                _spriteRenderer.color = _emptyColor;
            else
                _spriteRenderer.color = _filledColor;
            _spriteRenderer.sprite = sprite;
            _id = id;
            ChangeCount(count);
            
        }
        public void ChangeCount(int count)
        {
            _count += count;
            if (_count == 1 || _count == 0)
            {
                _textMesh.text = string.Empty;
            }
            else
            {
                _textMesh.text = _count.ToString();
            }
        }
        public void RemoveSlot()
        {
            _id = 0;
            _count = 0;
            _spriteRenderer.sprite = null;
            _spriteRenderer.color = _emptyColor;
            _textMesh.text = string.Empty;          
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(Id != 0)
                Clicked?.Invoke(_id, eventData.position);            
        }
    }
}
