using System;
using _4GewinntLib.Interfaces;

namespace _4GewinntLib.Classes
{
    public class Stone : IStone
    {
        private IPlayer _owner;
        private IPlace _position;

        public Stone(IPlayer Player, IPlace Position)
        {
            _owner = Player;
            _position = Position;
        }
        public IPlayer Owner
        {
            get
            {
                return this._owner;
            }
        }

        public IPlace Positon
        {
            get
            {
                return _position;
            }
        }
    }
}
