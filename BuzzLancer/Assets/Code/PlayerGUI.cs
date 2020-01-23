using UnityEngine;

namespace Assets.Code
{
    public class PlayerGUI
    {
        private readonly PlayerController _controller;
        private readonly Player _player;
        private readonly LevelManager _levelManager;

        private readonly ProgresBar _velocityProgresBar;
        private readonly ProgresBar _healthProgresBar;
        private readonly ProgresBar _timeProgresBar;

        public float CurrentCursorSize { get; private set; }


        public PlayerGUI(Player player, PlayerController controller)
        {
            _levelManager = (LevelManager)Object.FindObjectOfType(typeof(LevelManager));
            _controller = controller;
            _player = player;

            _velocityProgresBar = new ProgresBar
            {
                Size = new Vector2(250, 10),
                Position = new Vector2(10, Screen.height - 10 - 10),
                BeckgroundColor=new Color(199f/255,231f/255,255f/255),
                ForegroundColor=new Color(0f/255,145f/255,255f/255)
            };

            _healthProgresBar = new ProgresBar
            {
                Size = _velocityProgresBar.Size,
                Position=new Vector2(_velocityProgresBar.Position.x, _velocityProgresBar.Position.y - _velocityProgresBar.Size.y -10),
                BeckgroundColor=new Color(255f/255,199f/255,208f/255),
                ForegroundColor=new Color(194f/255,62f/255,62f/255)
            };

            _timeProgresBar = new ProgresBar
            {
                Size = new Vector2(Screen.width / 2f, 10),
                Position = new Vector2(Screen.width / 2f - (Screen.width / 4f),10),
                ForegroundColor=new Color(247f/255,244f/255,32f/255),
                BeckgroundColor=new Color(1,1,1)
            };

            CurrentCursorSize = 20;
        }

        public void Update()
        {
            _velocityProgresBar.MaxValue = _controller.MaxVariableVelocity + _controller.AfterburnerModifier + _controller.MinimumVelocity;
            _velocityProgresBar.Value = _controller.CurrentVelocity;

            _healthProgresBar.MaxValue = _player.MaxHealth;
            _healthProgresBar.Value=_player.Health;

            _timeProgresBar.MaxValue = Mathf.Max(_timeProgresBar.MaxValue, _levelManager.TimeLeft);
            _timeProgresBar.Value = _levelManager.TimeLeft;
        }

        public void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 200, 40), string.Format("{0} points", GameManagerInstance.Instance.Points));

            GUI.DrawTexture(
                new Rect(
                    _controller.MousePosition.x -(CurrentCursorSize/2),
                    Screen.height - _controller.MousePosition.y-(CurrentCursorSize/2),
                    CurrentCursorSize,
                    CurrentCursorSize),
                GameResorces.TargetPeticle);
        }
    }
}