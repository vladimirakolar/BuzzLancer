using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public class ProgresBarRenderer : MonoBehaviour
    {
        private ProgresBar _bar;

        public void Init(ProgresBar bar)
        {
            _bar = bar;
        }

        public void OnGUI()
        {
            var oldColor = GUI.color;

            GUI.color = _bar.BeckgroundColor;
            GUI.DrawTexture(new Rect(_bar.Position.x, _bar.Position.y, _bar.Size.x, _bar.Size.y),GameResorces.Square);

            GUI.color = _bar.ForegroundColor;
            GUI.DrawTexture(new Rect(_bar.Position.x, _bar.Position.y, _bar.Value*_bar.Size.x/_bar.MaxValue, _bar.Size.y), GameResorces.Square);

            GUI.color = oldColor;
        }
    }
}
