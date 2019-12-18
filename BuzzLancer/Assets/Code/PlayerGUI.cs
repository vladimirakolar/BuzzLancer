using UnityEngine;

namespace Assets.Code
{
    public class PlayerGUI
    {
        private readonly PlayerController _controller;
        private readonly Player _player;

        private readonly ProgresBar _velocityProgresBar;


        public PlayerGUI(PlayerController controller, Player player)
        {
            _controller = controller;
            _player = player;

            _velocityProgresBar = new ProgresBar
            {
                Size = new Vector2(250, 10),
                Position = new Vector2(10, Screen.height - 10 - 10),
                BeckgroundColor=new Color(199,231,255),
                ForegroundColor=new Color(0,145,255)
            };
        }
    }
}