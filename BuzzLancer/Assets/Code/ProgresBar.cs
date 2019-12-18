using UnityEngine;

namespace Assets.Code
{
    public class ProgresBar
    {
        private readonly GameObject _gameObject;

        private float _value;

        public Color BeckgroundColor { get; set; }

        public Color ForegroundColor { get; set; }

        public float MaxValue { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public bool IsEnabled { get { return _gameObject.activeSelf; } set { _gameObject.SetActive(value); } }

        public float Value
        {
            get { return _value; }
            set
            {
                _value = Mathf.Clamp(value, 0, MaxValue);
            }
        }

        public ProgresBar()
        {
            _gameObject = new GameObject();
            _gameObject.AddComponent<ProgresBarRenderer>().Init(this);
        }

        public void Destroy()
        {
            Object.Destroy(_gameObject);

        }
    }
}