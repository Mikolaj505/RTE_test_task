using Fusion;
using MKubiak.RTETestTask.Input;
using MKubiak.RTETestTask.Weapons;

namespace MKubiak.RTETestTask
{
    public class PlayerWeaponsController : NetworkBehaviour
    {
        private PlayerFacade _playerFacade;
        private PlayerInputController _inputController;
        private IWeaponController[] _weaponControllers;
        private IWeaponController ActiveWeapon => _weaponControllers[0]; //TODOMK: for now just return first as we only have one.

        private void Awake()
        {
            _playerFacade = GetComponent<PlayerFacade>();
            _inputController = _playerFacade.Input;
            _weaponControllers = GetComponentsInChildren<IWeaponController>();
        }

        public IWeaponController GetWeapon(int weaponID)
        {
            foreach (var weaponController in _weaponControllers)
            {
                if (weaponController.GetWeaponConfig().ID == weaponID)
                {
                    return weaponController;
                }
            }

            return null;
        }

        public override void FixedUpdateNetwork()
        {
            if (_inputController.WasActivated(PlayerInputAction.Fire))
            {
                ActiveWeapon.OnFireDown();
            }
        }
    }
}